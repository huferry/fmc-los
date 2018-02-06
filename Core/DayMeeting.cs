using System;
using System.Collections.Generic;
using System.Linq;

namespace Los.Core
{
    public class DayMeeting
    {
        private readonly List<Meeting> meetings = new List<Meeting>();

        internal DayMeeting(IEnumerable<Meeting> meetings, DateTime date)
        {
            this.meetings.AddRange(meetings.ToArray());
            MeetingDate = date;
        }

        public DateTime MeetingDate { get; }

        public IEnumerable<Meeting> Meetings => meetings;

        public bool Contains(Meeting meeting)
        {
            return meetings.Contains(meeting);
        }

        internal bool Contains(int meetingId)
        {
            return meetings.Any(x => x.Id == meetingId);
        }

        public override bool Equals(object obj)
        {
            if (this == obj)
                return true;

            if (obj is DayMeeting)
            {
                return (obj.GetHashCode() == GetHashCode());
            }

            return false;
        }

        public override int GetHashCode()
        {
            var code = 1;
            var mid = meetings.Select(x => x.Id).OrderBy(x => x).ToArray();
            for (var i = 0; i < mid.Length; i++)
            {
                code += (i + 1) * mid[i];
            }

            code = code * MeetingDate.Date.ToLongDateString().GetHashCode();
            return code;
        }

        public override string ToString()
        {
            return MeetingDate.ToString("dd/MMM/yyyy");
        }

        public static IEnumerable<DayMeeting> GetByCourse(Course course)
        {
            var dates = course.Meetings.Select(x => x.MeetingDate.Date).Distinct().OrderBy(x => x.Ticks).ToList();
            foreach (var d in dates)
            {
                yield return new DayMeeting(course.Meetings.Where(x => x.MeetingDate.Date == d.Date), d);
            }
        }

        public static DayMeeting GetByCourseDate(Course course, DateTime date)
        {
            var search = course
                .Meetings
                .Where(x => x.MeetingDate.Date == date.Date)
                .ToArray();

            return search.Any()
                ? new DayMeeting(search, date)
                : null;
        }
    }
}