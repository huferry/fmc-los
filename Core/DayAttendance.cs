using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Los.Core
{
    public class DayAttendance
    {
        List<Attendance> attendances = new List<Attendance>();
        DayMeeting day_meeting;
        Relation student;

        internal DayAttendance(DayMeeting day_meeting, IEnumerable<Attendance> attendances, Relation student)
        {
            this.day_meeting = day_meeting;
            this.attendances.AddRange(attendances.ToArray());
            this.student = student;
        }

        public DayAttendance(Course course, Relation student, DateTime date)
        {
            // retrieve all meetings from course with the given date
            day_meeting = DayMeeting.GetByCourseDate(course, date);
            if (day_meeting == null)
                throw new Exception("The course does not have a meeting for the given date.");

            // check student in course
            if (!course.HasStudent(student))
                throw new Exception("Student is not part of the course.");

            // check existing status
            this.attendances.AddRange(
                Attendance.GetByCourseStudent(course, student)
                .Where(x => day_meeting.Contains(x.MeetingId))
                .ToArray());

            // adding not existing status
            var existing = attendances.Select(x => x.MeetingId).ToArray();
            foreach (Meeting m in day_meeting.Meetings)
            {
                if (!existing.Contains(m.Id))
                {
                    attendances.Add(new Attendance(m, student, AttendanceStatus.Unknown));
                }
            }
        }

        public DateTime MeetingDate
        {
            get { return day_meeting.MeetingDate; }
        }

        public Relation Student
        {
            get { return student; }
        }

        public AttendanceStatus AttendanceStatus
        {
            get
            {
                var statuses = attendances.Select(x => x.Status);
                if (statuses.Contains(AttendanceStatus.Present))
                    return AttendanceStatus.Present;

                if (statuses.Contains(AttendanceStatus.Leave))
                    return AttendanceStatus.Leave;

                if (statuses.Contains(AttendanceStatus.Ill))
                    return AttendanceStatus.Ill;

                return AttendanceStatus.Unknown;
            }

            set
            {
                foreach (var att in attendances)
                    att.Status = value;
            }
        }

        public string Note
        {
            get
            {
                string note = "";
                foreach (string att_note in attendances.Select(x=>x.Note).Distinct())
                    note += att_note + "\r\n";
                return note;
            }

            set
            {
                foreach (Attendance att in attendances)
                    att.Note = value;
            }
        }

        public void Update()
        {
            AttendanceStatus status = this.AttendanceStatus;
            var notes = attendances.Select(x => x.Note).Distinct();
            var note = "";
            foreach (var n in notes)
                note += n + "\r\n";

            foreach (Attendance att in attendances)
            {
                att.Status = status;
                att.Note = note;
                att.Update();
            }
        }

        static public IEnumerable<DayAttendance> GetByCourse(Course course)
        {
            var attendances = Attendance.GetByCourse(course).ToList();
            var daymeetings = DayMeeting.GetByCourse(course).ToList();
            var course_students = course.GetStudents().ToList();
            
            foreach (DayMeeting daymeet in daymeetings)
            {
                var day_att = attendances.Where(x => daymeet.Contains(x.MeetingId));
                var students = course_students.Where(s => day_att.Select(x => x.RelationId).Contains(s.Id));

                foreach(var s in students)
                {
                    var student_att = day_att.Where(x => x.RelationId == s.Id);
                    yield return new DayAttendance(daymeet, student_att, s);
                }
            }
        }

        static public DayAttendance Find(IEnumerable<DayAttendance> day_attendances, Relation student, DayMeeting day_meeting)
        {
            var search = day_attendances.Where(x => (x.Student.Id == student.Id) && (x.day_meeting.Equals(day_meeting)));
            if (search.Count() > 1)
                throw new Exception("Multiple objects are found.");

            if (search.Count() == 0)
                return null;

            return search.First();
        }
    }
}
