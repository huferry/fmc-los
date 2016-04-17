using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;

namespace Los.Core
{
    public class Course
    {
        private int id = -1;
        private int level_id = -1;
        private string name;
        private string description;
        private DateTime start;
        private DateTime end;
        private bool open_enrollment = false;
        private List<Meeting> meetings = null;
        private Dictionary<int, StudentCourseStatus> student_course_status = new Dictionary<int, StudentCourseStatus>();

        private Course(DataRow row)
        {
            id = row.Field<int>("class_id");
            level_id = row.Field<int>("level_id");
            name = row.Field<string>("name");
            description = row.Field<string>("description");
            start = row.Field<DateTime>("date_begin");
            end = row.Field<DateTime>("date_end");
            open_enrollment = row.Field<bool>("open_enrollment");
        }

        #region Properties

        internal int Id
        {
            get { return id; }
        }

        internal int LevelId
        {
            get { return level_id; }
        }

        public string Name
        {
            get { return name; }
            set
            {
                name = value;
            }
        }

        public string Description
        {
            get { return description; }
            set
            {
                description = value;
            }
        }

        public DateTime DateStart
        {
            get { return start; }
            set
            {
                start = value;
            }
        }

        public DateTime DateEnd
        {
            get { return end; }
            set
            {
                end = value;
            }
        }

        public bool Ended
        {
            get { return end.Ticks >= DateTime.Now.Ticks; }
        }

        public Level Level
        {
            get
            {
                return Level.ById(level_id);
            }
        }

        public bool OpenEnrollment
        {
            get { return open_enrollment; }
        }

        public StudentCourseStatus GetStudentStatus(Relation student)
        {
            if (!student_course_status.Keys.Contains(student.Id))
            {
                student_course_status.Add(student.Id, StudentCourseStatus.GetStatus(this.id, student.Id));
            }
            return student_course_status[student.Id];
        }

        public void EnrolStudent(Relation rel)
        {
            // check current enrolment
            var enrolled = GetStudents().Where(x => x.Id == rel.Id).Count() > 0;
            if (!enrolled)
            {
                Database.Execute(string.Format("INSERT INTO class_relation (cla_class_id, rel_relation_id, finished) " +
                    "VALUES ({0},{1},0)", id, rel.Id), null);
            }                
        }

        public void RemoveStudent(Relation rel)
        {
            StudentCourseStatus status = GetStudentStatus(rel);
            if (!status.Enrolled)
            {
                throw new Exception("Relation is not a student in the course");
            }

            if (status.Finished)
            {
                throw new Exception("Student has already finished the course, and cannot be removed from the course.");
            }

            // really remove student from course
            DbParameter[] pars = new DbParameter[]
            {
                Database.CreateParameter("@classid", id),
                Database.CreateParameter("@relid", rel.Id)
            };
            Database.Execute("DELETE FROM class_relation WHERE cla_class_id = @classid AND rel_relation_id = @relid", pars);
        }

        public bool CanRemoveStudent(Relation rel)
        {
           StudentCourseStatus status = GetStudentStatus(rel);
           return status.Enrolled && !status.Finished;
        }

        public bool HasStudent(Relation student)
        {
            return Relation.GetByCourse(this).Where(x => x.Id == student.Id).Count() != 0;
        }

        public override string ToString()
        {
            return name;
        }

        public bool CanDelete()
        {
            return (id != -1) && (GetStudents().Count() == 0);
        }

        public void Delete()
        {
            if (GetStudents().Count() > 0)
            {
                throw new Exception("Cannot delete a course when there is a student is enrolled to the course");
            }

            if (id <= 0)
            {
                throw new Exception("Course has been previously deleted");
            }

            // delete from database
            Database.Execute("DELETE FROM class WHERE class_id = " + id.ToString(), null);
            id = -1;
        }

        public IEnumerable<Meeting> Meetings
        {
            get
            {
                if (meetings == null)
                {
                    meetings = new List<Meeting>();
                    meetings.AddRange(Meeting.GetByCourse(this));
                }
                return meetings;
            }
        }

        public Meeting GetMeetingByLesson(Lesson lesson)
        {
            var meeting = Meetings.Where(x => x.Lesson.Id == lesson.Id);
            if (meeting.Count() > 0)
                return meeting.First();
            else
                return null;
        }

        public Meeting AddMeetingByLesson(Lesson lesson, DateTime date)
        {
            if (GetMeetingByLesson(lesson) != null)
                throw new Exception("Meeting for the lesson already exists");

            Meeting m = new Meeting(this, lesson, date);
            meetings.Add(m);
            return m;
        }

        public bool IsMeetingComplete()
        {
            var meetings = this.Meetings;

            // search for unplanned lessons
            foreach (Lesson les in this.Level.Lessons)
            {
                var unplanned = meetings.Where(x => x.Lesson.Id == les.Id).Count() == 0;
                if (unplanned)
                    return false;
            }
            return true;
        }        

        public IEnumerable<Meeting> InitiateWeeklyMeetings(DateTime startDate)
        {
            if ((meetings != null) && (this.meetings.Count > 0))
                throw new Exception("Cannot initiate weekly meetings when some meetings are already planned.");

            meetings = new List<Meeting>();

            // get blocking days for 1 year forward
            var blocking_days = Calendar.GetBlockingDates(startDate.AddMonths(-2), startDate.AddYears(1));

            var lessons = Lesson.GetByLevel(Level).OrderBy(x => x.Order);

            if (lessons.Count() > 0)
            {
                var meeting_date = startDate.Date.AddDays(-7);
                int last_order = lessons.First().Order - 1;

                foreach (Lesson l in lessons)
                {                    
                    if (last_order != l.Order)
                    {
                        meeting_date = meeting_date.AddDays(7);

                        // find a new date
                        while (blocking_days.ContainsKey(meeting_date))
                        {
                            meeting_date = meeting_date.AddDays(7);
                        }
                    }

                    // create meeting for l and meeting_date
                    meetings.Add(new Meeting(this, l, meeting_date));                    

                    last_order = l.Order;
                }
            }            
            return meetings;
        }

        #endregion

        public void Update()
        {
            Database.Execute(
                "UPDATE class SET description=@description WHERE class_id=@id", GetParameters());
        }

        private DbParameter[] GetParameters()
        {
            return new DbParameter[] {
                Database.CreateParameter("@description", description),
                Database.CreateParameter("@id", id)
            };
        }

        public bool IsActive
        {
            get
            {
                return (end.Date >= DateTime.Today.Date);
            }
        }

        public IEnumerable<Relation> GetStudents()
        {
            return Relation.GetByCourse(this);
        }

        static public IEnumerable<Course> GetAll()
        {
            var rows = Database.Select("SELECT * FROM class");
            foreach (DataRow row in rows)
                yield return new Course(row);
        }

        static public IEnumerable<Course> GetActiveCourses(TimeSpan beforeBegin)
        {
            return GetAll().Where(x => x.end >= DateTime.Today.Subtract(beforeBegin));
        }

        static public IEnumerable<Course> GetActiveCourses()
        {
            return GetActiveCourses(TimeSpan.FromTicks(0));
        }

        static public IEnumerable<Course> GetActiveCourses(Level level)
        {
            return GetActiveCourses().Where(x => x.level_id == level.Id);
        }

        static public IEnumerable<Course> GetEndedCouses()
        {
            return GetAll().Where(x => x.end < DateTime.Today);
        }

        static public IEnumerable<Course> GetByStudent(Relation student)
        {
            var rows = Database.Select(
                        "SELECT cla.* " +
                        "FROM class cla " +
                        "JOIN class_relation clr ON clr.cla_class_id=cla.class_id " + 
                        "WHERE clr.rel_relation_id=" + student.Id.ToString());
            foreach (DataRow r in rows)
                yield return new Course(r);
        }

        static public Course GetLastClosedCourseByRelation(Relation student)
        {
            var courses = GetByStudent(student).Where(x => !x.IsActive).OrderBy(x => x.end);
            if (courses.Count() > 0)
                return courses.Last();
            else
                return null;
        }

        static public Course GetLastFinishedCourseByRelation(Relation student)
        {
            var courses = GetByStudent(student).Where(x => x.GetStudentStatus(student).Finished).OrderBy(x => x.Level);
            if (courses.Count() > 0)
                return courses.Last();
            else
                return null;
        }

        static public Course GetActiveByRelation(Relation student)
        {
            var courses = GetByStudent(student).Where(x => x.IsActive);
            if (courses.Count() > 0)
                return courses.First();
            else
                return null;
        }        

        /*
        static public Course GetNextPossibleCourseByRelation(Relation student)
        {
            // fetch the last coursed followed by the student
            var last = GetLastFinishedCourseByRelation(student);

            // check if there is a next level
            if ((last != null) && (last.Level.Next == null))
                return null;

            // find courses with lowest level
            if (last == null)
            {
                var courses = GetActiveCourses(TimeSpan.FromDays(150)).Where(x => x.open_enrollment && (x.Level == Level.Lowest));
            }

            // find the available course
            var courses = GetActiveCourses(TimeSpan.FromDays(150)).Where(x => x.open_enrollment && (x.Level == last.Level.Next));

            if (courses.Count() > 0)
                return courses.First();
            else
                return null;
        }
         */

        static public IEnumerable<Course> GetNextPossibleCoursesByLevel(TimeSpan before, Level level)
        {
            return GetActiveCourses(before).Where(x => x.open_enrollment && (x.Level == level));
        }

        static private IEnumerable<Course> GetDummy()
        {
            return new Course[] { };
        }

        static public IEnumerable<Course> GetNextPossibleCoursesByRelation(Relation student)
        {
            // if a student has an active class, cannot enrol another
            if (GetActiveByRelation(student) != null)
                return GetDummy();

            // fetch the last coursed followed by the student
            var last = GetLastFinishedCourseByRelation(student);
            Level next_level = Level.Lowest;

            // check if there is a next level
            if (last != null)
            {
                next_level = last.Level.Next;
            }
            else
            {
                var closed = GetLastClosedCourseByRelation(student);
                if (closed != null)
                    next_level = closed.Level;
            }

            // find the available course
            var courses = GetNextPossibleCoursesByLevel(TimeSpan.FromDays(150), next_level);

            return courses.Where(x => !x.HasStudent(student));
        }

        static internal Course GetLastCourse()
        {
            var row = Database.Select("select cla1.* from class cla1 where cla1.class_id = (select max(cla2.class_id) from class cla2)");
            return new Course(row.First());
        }

        static public Course AddNew(Level level, string name, string desc, DateTime start, DateTime end)
        {
            DbParameter[] pars = new DbParameter[]
            {
                Database.CreateParameter("@level",level.Id),
                Database.CreateParameter("@name", name),
                Database.CreateParameter("@desc", desc),
                Database.CreateParameter("@start", start),
                Database.CreateParameter("@end", end)
            };
            Database.Execute("INSERT INTO class (level_id, name, description, date_begin, date_end, open_enrollment) " +
                "VALUES (@level, @name, @desc, @start, @end, 1)", pars);

            return GetLastCourse();
        }        

    }
}
