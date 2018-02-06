using System.Collections.Generic;
using System.Linq;
using Core;

namespace Los.Core
{
    public enum AttendanceStatus
    {
        Unknown = 0,
        Present = 1,
        Leave = 2,
        Ill = 3
    }

    public class Attendance
    {
        public virtual int Id { get; set; }

        public virtual Relation Student { get; set; }

        public virtual Meeting Meeting { get; set; }

        public virtual AttendanceStatus Status { get; set; }

        public virtual string Note { get; set; } = string.Empty;

        internal static IEnumerable<Attendance> GetByCourse(Course course)
        {
            return Repository
                .Query<Attendance>()
                .Where(a => a.Meeting.Course.Id == course.Id)
                .ToArray();
        }

        internal static IEnumerable<Attendance> GetByCourseStudent(Course course, Relation student)
        {
            return GetByCourse(course)
                .Where(a => a.Student.Id == student.Id)
                .ToArray();
        }
    }
}