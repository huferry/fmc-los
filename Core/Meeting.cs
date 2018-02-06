using System;
using System.Collections.Generic;
using System.Linq;
using Core;

namespace Los.Core
{
    public class Meeting
    {
        public virtual int Id { get; set; }

        public virtual Lesson Lesson { get; set; }

        public virtual Course Course { get; set; }

        public virtual DateTime MeetingDate { get; set; }

        public virtual bool CanDelete()
        {
            var attendees = Repository
                .Session
                .CreateSQLQuery(
                    $"SELECT COUNT(att.attendance_id) att_count FROM attendance att WHERE att.mee_meeting_id = {Id}")
                .UniqueResult<int>();
            return attendees > 0;
        }

        internal static IEnumerable<Meeting> GetByCourse(Course course)
        {
            return Repository
                .Query<Meeting>()
                .Where(x => x.Course.Id == course.Id)
                .ToArray();
        }
    }
}