using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;

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
        private AttendanceStatus status;
        private int id = -1;
        private int relation_id;
        private int meeting_id;
        private string note = "";

        internal int Id
        {
            get { return id; }
        }

        internal Attendance(DataRow row)
        {
            id = row.Field<int>("attendance_id");
            meeting_id = row.Field<int>("mee_meeting_id");
            relation_id = row.Field<int>("rel_relation_id");
            status = (AttendanceStatus)row.Field<int>("status");
            note = row.Field<string>("note");
        }

        internal Attendance(Meeting meeting, Relation relation, AttendanceStatus status)
        {
            // check 
            if (!meeting.Course.HasStudent(relation))
            {
                throw new Exception("Cannot set the attendance status from a student that is not enrolled to the course.");
            }            
            meeting_id = meeting.Id;
            relation_id = relation.Id;
            this.status = status;
        }

        internal int RelationId
        {
            get { return relation_id; }
        }

        internal int MeetingId
        {
            get { return meeting_id; }
        }

        public AttendanceStatus Status
        {
            get { return status; }
            set
            {
                status = value;
            }
        }

        public void Update()
        {
            if (id == -1)
                Insert();
            else
            {
                Database.Execute(
                    "UPDATE attendance " +
                    "SET status = @status, note = @note " +
                    "WHERE attendance_id = @id",
                    GetParams()
                    );
            }
        }

        private void Insert()
        {
            Database.Execute(
                "INSERT INTO attendance " +
                "(mee_meeting_id, rel_relation_id, status, note) " +
                "VALUES(@meeting_id, @relation_id, @status, @note)",
                GetParams()
                );

            var row = Database.Select("SELECT Max(attendance_id) new_id FROM attendance");
            id = row.First().Field<int>("new_id");
        }

        private IEnumerable<DbParameter> GetParams()
        {
            return new DbParameter[]
            {
                Database.CreateParameter("@id", id),
                Database.CreateParameter("@meeting_id", meeting_id),
                Database.CreateParameter("@relation_id", relation_id),
                Database.CreateParameter("@status", (int)status),
                Database.CreateParameter("@note", note)
            };
        }

        public string Note
        {
            get { return note; }
            set { note = value; }
        }

        static internal IEnumerable<Attendance> GetByCourse(Course course)
        {
            var rows = Database.Select("SELECT att.* FROM attendance att " +
                                       "JOIN meeting mee ON mee.meeting_id = att.mee_meeting_id " +
                                       "JOIN class cla ON cla.class_id = mee.cla_class_id " +
                                       "WHERE cla.class_id = " + course.Id.ToString());

            foreach (var row in rows)
            {
                yield return new Attendance(row);
            }
        }

        static internal IEnumerable<Attendance> GetByCourseStudent(Course course, Relation student)
        {
            var rows = Database.Select("SELECT att.* FROM attendance att " +
                                       "JOIN meeting mee ON mee.meeting_id = att.mee_meeting_id " +
                                       "JOIN class cla ON cla.class_id = mee.cla_class_id " +
                                       "WHERE cla.class_id = " + course.Id.ToString() + " and " +
                                       "att.rel_relation_id = " + student.Id.ToString());

            foreach (var row in rows)
            {
                yield return new Attendance(row);
            }
        }
    }
}
