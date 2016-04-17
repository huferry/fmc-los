using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Los.Core
{
    public class DayMeeting
    {
        List<Meeting> meetings = new List<Meeting>();
        DateTime date;

        internal DayMeeting(IEnumerable<Meeting> meetings, DateTime date)
        {
            this.meetings.AddRange(meetings.ToArray());
            this.date = date;
        }

        public bool Contains(Meeting meeting)
        {
            return meetings.Contains(meeting);
        }

        internal bool Contains(int meeting_id)
        {
            return meetings.Where(x => x.Id == meeting_id).Count() > 0;
        }

        public DateTime MeetingDate
        {
            get { return date; }
        }

        public IEnumerable<Meeting> Meetings
        {
            get { return meetings; }
        }

        public override bool Equals(object obj)
        {
            if (this == obj)
                return true;

            if (obj is DayMeeting)
            {
                return (obj.GetHashCode() == this.GetHashCode());
            }
            return false;
        }

        public override int GetHashCode()
        {
            int code = 1;
            var mid = meetings.Select(x => x.Id).OrderBy(x => x).ToArray();
            for (int i = 0; i < mid.Length ; i++)
            {
                code += (i+1)* mid[i];
            }
            code = code * this.date.Date.ToLongDateString().GetHashCode();
            return code;
        }

        public override string ToString()
        {
            return date.ToString("dd/MMM/yyyy");
        }

        static public IEnumerable<DayMeeting> GetByCourse(Course course)
        {
            var dates = course.Meetings.Select(x => x.MeetingDate.Date).Distinct().OrderBy(x => x.Ticks).ToList();
            foreach (DateTime d in dates)
            {
                yield return new DayMeeting(course.Meetings.Where(x => x.MeetingDate.Date == d.Date), d);
            }
        }

        static public DayMeeting GetByCourseDate(Course course, DateTime date)
        {
            var search = course.Meetings.Where(x => x.MeetingDate.Date == date.Date);
            if (search.Count() > 0)
                return new DayMeeting(search, date);
            return null;          
        }
    }
}
