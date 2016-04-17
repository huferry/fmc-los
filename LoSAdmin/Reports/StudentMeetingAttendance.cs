using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Los.Core;

namespace LoSAdmin.Reports
{
    public class StudentMeetingAttendance
    {
        private string name;
        private DateTime date;
        private string status;
        private string course;
        private string course_desc;

        internal StudentMeetingAttendance(Course course, DayAttendance day_att)
        {
            this.name = day_att.Student.ToString();            
            this.date = day_att.MeetingDate;
            this.course = course.Name + "/" + CreateSeason(course);
            var status = course.GetStudentStatus(day_att.Student);
            this.status = day_att.AttendanceStatus == AttendanceStatus.Unknown ? 
                "" : day_att.AttendanceStatus.ToString().ToLower();
            if (status.System > 1)
                this.name += string.Format(" [sys/{0}]", status.System);
            this.course_desc = course.Description;            
        }

        internal StudentMeetingAttendance(Course course, Relation rel, DateTime date)
        {
            this.name = rel.ToString();
            this.date = date.Date;
            this.course = course.Name + "/" + CreateSeason(course);
            this.status = "";
            var status = course.GetStudentStatus(rel);
            if (status.System > 1)
                this.name += string.Format(" [sys/{0}]", status.System);
            this.course_desc = course.Description;
        }

        private string CreateSeason(Course course)
        {
            if (course.DateStart < (new DateTime(course.DateStart.Year, 7, 31)))
            {
                return "Spring " + course.DateStart.Year.ToString();
            }
            else
            {
                return "Fall " + course.DateStart.Year.ToString();
            }
        }

        public string Course
        {
            get { return course; }
        }

        public string CourseDesc
        {
            get { return course_desc; }
        }

        public string Name
        {
            get { return name; }
        }

        public DateTime Date
        {
            get { return date; }
        }

        public string Status
        {
            get { return status; }
        }
        
    }

    public class CourseStudentMeetingAttendance
    {
        static public IEnumerable<StudentMeetingAttendance> GetByCourse(Course course)
        {
            List<StudentMeetingAttendance> list = new List<StudentMeetingAttendance>();
            
            var atts = DayAttendance.GetByCourse(course).OrderBy(x => x.MeetingDate.Ticks);
            foreach (var a in atts)
            {
                list.Add( new StudentMeetingAttendance(course, a) );                
            }

            if (atts.Count() > 0)
            {
                // adding student that does not have status
                var student_in_list = atts.Select(x => x.Student.GetHashCode()).Distinct().ToList();
                var all_students = course.GetStudents().ToList();                
                foreach (Relation r in all_students)
                {
                    if (!student_in_list.Contains(r.GetHashCode()))
                    {
                        list.Add(new StudentMeetingAttendance(course, r, atts.First().MeetingDate));
                    }
                }                 
            }

            return list.OrderBy(x => x.Name);
        }

        static public IEnumerable<StudentMeetingAttendance> GetByCourses(IEnumerable<Course> courses)
        {
            List<StudentMeetingAttendance> all = new List<StudentMeetingAttendance>();
            try
            {
                FormWaiting.ShowMessage("Generating report...");
                int i = 0;
                foreach (Course course in courses)
                {
                    FormWaiting.SetProgress(i++ * 100 / courses.Count());
                    all.AddRange(GetByCourse(course).ToArray());
                }
            }
            finally
            {
                FormWaiting.Finished();
            }
            return all;
        }
    }
}
