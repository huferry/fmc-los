using System;
using System.Collections.Generic;
using System.Linq;
using Core;
using NHibernate.Linq;

namespace Los.Core
{
    public class Course
    {
        private List<Meeting> meetings;

        public virtual bool IsActive => DateEnd.Date >= DateTime.Today.Date;

        public virtual IEnumerable<Relation> GetStudents()
        {
            return Students.Select(r => r.Student);
        }

        public static IEnumerable<Course> GetActiveCourses(TimeSpan beforeBegin)
        {
            return Repository.Session.Query<Course>().Where(x => x.DateEnd >= DateTime.Today.Subtract(beforeBegin));
        }

        public static IEnumerable<Course> GetActiveCourses()
        {
            return GetActiveCourses(TimeSpan.FromTicks(0));
        }

        public static IEnumerable<Course> GetActiveCourses(Level level)
        {
            return GetActiveCourses().Where(x => x.LevelId == level.Id);
        }

        public static IEnumerable<Course> GetEndedCouses()
        {
            return Repository.GetAll<Course>().Where(x => x.DateEnd < DateTime.Today);
        }

        public static IEnumerable<Course> GetByStudent(Relation student)
        {
            return Repository
                .Query<ClassRelation>()
                .Where(cr => cr.Student.Id == student.Id)
                .Select(cr => cr.Course)
                .ToArray();
        }

        public static Course GetLastClosedCourseByRelation(Relation student)
        {
            return GetByStudent(student)
                .Where(x => !x.IsActive)
                .OrderBy(x => x.DateEnd)
                .LastOrDefault();
        }

        public static Course GetLastFinishedCourseByRelation(Relation student)
        {
            return GetByStudent(student)
                .Where(x => x.GetStudentStatus(student).IsFinished)
                .OrderBy(x => x.Level)
                .LastOrDefault();
        }

        public static Course GetActiveByRelation(Relation student)
        {
            return GetByStudent(student).FirstOrDefault(x => x.IsActive);
        }

        public static IEnumerable<Course> GetNextPossibleCoursesByLevel(TimeSpan before, Level level)
        {
            return GetActiveCourses(before).Where(x => x.OpenEnrollment && (x.Level == level));
        }

        private static IEnumerable<Course> GetDummy()
        {
            return new Course[] { };
        }

        public static IEnumerable<Course> GetNextPossibleCoursesByRelation(Relation student)
        {
            if (student == null)
            {
                return null;
            }

            // if a student has an active class, cannot enrol another
            if (GetActiveByRelation(student) != null)
                return GetDummy();

            // fetch the last coursed followed by the student
            var last = GetLastFinishedCourseByRelation(student);
            var nextLevel = Level.Lowest;

            // check if there is a next level
            if (last != null)
            {
                nextLevel = last.Level.Next;
            }
            else
            {
                var closed = GetLastClosedCourseByRelation(student);
                if (closed != null)
                    nextLevel = closed.Level;
            }

            // find the available course
            return GetNextPossibleCoursesByLevel(TimeSpan.FromDays(150), nextLevel)
                .Where(x => !x.HasStudent(student));
        }

        public virtual bool CanRemoveStudent(Relation student)
        {
            var status = Students.FirstOrDefault(cr => cr.Student.Id == student.Id);

            return status != null && !status.IsFinished;
        }

        public virtual bool HasStudent(Relation relation)
        {
            return Students.Any(cr => cr.Student.Id == relation.Id);
        }

        #region Properties

        public virtual int Id { get; set; }
        public virtual int LevelId { get; set; }
        public virtual string Name { get; set; }
        public virtual string Description { get; set; }
        public virtual DateTime DateStart { get; set; }
        public virtual DateTime DateEnd { get; set; }
        public virtual bool OpenEnrollment { get; set; }

        public virtual bool Ended => DateEnd >= DateTime.Now;

        public virtual Level Level => Level.ById(LevelId);

        public virtual IList<ClassRelation> Students { get; set; }

        public virtual ClassRelation GetStudentStatus(Relation student)
        {
            return Students.FirstOrDefault(r => r.Student.Id == student.Id);
        }

        public virtual void EnrolStudent(Relation rel)
        {
            if (Students.All(c => c.Student.Id != rel.Id))
            {
                Students.Add(new ClassRelation
                {
                    Student = rel,
                    Course = this
                });
                Repository.Save(this);
            }
        }

        public virtual void RemoveStudent(Relation rel)
        {
            var status = Students.FirstOrDefault(c => c.Student.Id == rel.Id);

            if (status == null)
            {
                throw new Exception("Relation is not a student in the course");
            }

            if (status.IsFinished)
            {
                throw new Exception("Student has already finished the course, and cannot be removed from the course.");
            }

            Students.Remove(status);
            Repository.Save(this);
        }

        public override string ToString()
        {
            return Name;
        }

        public virtual bool CanDelete()
        {
            return Id > 0 && !Students.Any();
        }

        public virtual IEnumerable<Meeting> Meetings
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

        public virtual Meeting GetMeetingByLesson(Lesson lesson)
        {
            return Meetings.FirstOrDefault(x => x.Lesson.Id == lesson.Id);
        }

        public virtual Meeting AddMeetingByLesson(Lesson lesson, DateTime date)
        {
            if (GetMeetingByLesson(lesson) != null)
            {
                throw new Exception("Meeting for the lesson already exists");
            }

            var meeting = new Meeting
            {
                Course = this,
                Lesson = lesson,
                MeetingDate = date
            };

            meetings.Add(Repository.Save(meeting));

            return meeting;
        }

        public virtual bool IsMeetingComplete()
        {
            // search for unplanned lessons
            foreach (var les in Level.Lessons)
            {
                if (Meetings.All(x => x.Lesson.Id != les.Id))
                {
                    return false;
                }
            }

            return true;
        }

        public virtual IEnumerable<Meeting> InitiateWeeklyMeetings(DateTime startDate)
        {
            if ((meetings != null) && (meetings.Count > 0))
                throw new Exception("Cannot initiate weekly meetings when some meetings are already planned.");

            meetings = new List<Meeting>();

            // get blocking days for 1 year forward
            var blockingDays = Calendar.GetBlockingDates(startDate.AddMonths(-2), startDate.AddYears(1));

            var lessons = Lesson.GetByLevel(Level).OrderBy(x => x.Order).ToArray();

            var meetingDate = startDate.Date.AddDays(-7);
            var lastOrder = lessons.FirstOrDefault()?.Order - 1 ?? 0;

            foreach (var lesson in lessons)
            {
                if (lastOrder != lesson.Order)
                {
                    meetingDate = meetingDate.AddDays(7);

                    // find a new date
                    while (blockingDays.ContainsKey(meetingDate))
                    {
                        meetingDate = meetingDate.AddDays(7);
                    }
                }

                // create meeting for l and meeting_date
                meetings.Add(Repository.Save(new Meeting
                {
                    Course = this,
                    Lesson = lesson,
                    MeetingDate = meetingDate
                }));

                lastOrder = lesson.Order;
            }

            return meetings;
        }

        #endregion
    }
}