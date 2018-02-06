using System;
using System.Collections.Generic;
using System.Linq;
using Core;

namespace Los.Core
{
    public class DayAttendance
    {
        private List<Attendance> attendances = new List<Attendance>();
        private DayMeeting dayMeeting;
        private Relation student;

        internal DayAttendance(DayMeeting dayMeeting, IEnumerable<Attendance> attendances, Relation student)
        {
            this.dayMeeting = dayMeeting;
            this.attendances.AddRange(attendances.ToArray());
            this.student = student;
        }

        public DayAttendance(Course course, Relation student, DateTime date)
        {
            // retrieve all meetings from course with the given date
            dayMeeting = DayMeeting.GetByCourseDate(course, date);
            if (dayMeeting == null)
                throw new Exception("The course does not have a meeting for the given date.");

            // check student in course
            if (!course.HasStudent(student))
                throw new Exception("Student is not part of the course.");

            // check existing status
            attendances.AddRange(
                Attendance.GetByCourseStudent(course, student)
                    .Where(x => dayMeeting.Contains(x.Meeting.Id))
                    .ToArray());

            // adding not existing status
            var existing = attendances.Select(x => x.Meeting.Id).ToArray();
            foreach (var meeting in dayMeeting.Meetings)
            {
                if (!existing.Contains(meeting.Id))
                {
                    attendances.Add(new Attendance
                    {
                        Meeting = meeting,
                        Status = AttendanceStatus.Unknown,
                        Student = student
                    });
                }
            }
        }

        public DateTime MeetingDate => dayMeeting.MeetingDate;

        public Relation Student => student;

        public AttendanceStatus AttendanceStatus
        {
            get
            {
                var statuses = attendances.Select(x => x.Status).ToArray();
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
                var note = "";
                foreach (var attNote in attendances.Select(x => x.Note).Distinct())
                    note += attNote + "\r\n";
                return note;
            }

            set
            {
                foreach (var att in attendances)
                    att.Note = value;
            }
        }

        public void Update()
        {
            var status = AttendanceStatus;
            var notes = attendances.Select(x => x.Note).Distinct();
            var note = "";
            foreach (var n in notes)
                note += n + "\r\n";

            foreach (var att in attendances)
            {
                att.Status = status;
                att.Note = note;
                Repository.Save(att);
            }
        }

        public static IEnumerable<DayAttendance> GetByCourse(Course course)
        {
            var attendances = Attendance.GetByCourse(course).ToList();
            var daymeetings = DayMeeting.GetByCourse(course).ToList();
            var courseStudents = course.GetStudents().ToList();

            foreach (var daymeet in daymeetings)
            {
                var dayAtt = attendances.Where(x => daymeet.Contains(x.Meeting.Id)).ToArray();
                var students = courseStudents.Where(s => dayAtt.Select(x => x.Student.Id).Contains(s.Id));

                foreach (var s in students)
                {
                    var studentAtt = dayAtt.Where(x => x.Student.Id == s.Id);
                    yield return new DayAttendance(daymeet, studentAtt, s);
                }
            }
        }

        public static DayAttendance Find(IEnumerable<DayAttendance> dayAttendances, Relation student,
            DayMeeting dayMeeting)
        {
            return dayAttendances
                .SingleOrDefault(x => (x.Student.Id == student.Id) && (x.dayMeeting.Equals(dayMeeting)));
        }
    }
}