using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;
using Core;

namespace Los.Core
{
    public class Meeting
    {
        private DateTime date = new DateTime(0);
        private Lesson lesson;
        private Course course;
        private int id = -1;        

        private Meeting(Course course, DataRow row)
        {
            this.lesson = Repository.Get<Lesson>(row.Field<int>("les_lesson_id"));
            this.course = course;
            id = row.Field<int>("meeting_id");
            date = row.Field<DateTime>("meeting_date");
        }

        internal Meeting(Course course, Lesson lesson, DateTime date)
        {
            this.lesson = lesson;
            this.course = course;
            this.date = date;
        }

        internal int Id
        {
            get { return id; }
        }

        public Lesson Lesson
        {
            get { return lesson; }
        }

        public Course Course
        {
            get { return course; }
        }

        public DateTime MeetingDate
        {
            get { return date; }
            set { date = value; }
        }

        public void Update()
        {
            if (id == -1)
                Insert();
            else
            {
                Database.Execute(
                    "UPDATE meeting SET meeting_date=@meeting_date WHERE meeting_id=@meeting_id;",
                    GetParameters()
                    );
            }
        }

        public void Insert()
        {
            Database.Execute(
                "INSERT INTO meeting (cla_class_id, les_lesson_id, meeting_date) VALUES (@class_id,@lesson_id,@meeting_date);",
                GetParameters()
                );
            var rows = Database.Select("SELECT MAX(mee.meeting_id) newid FROM meeting mee;");
            id = rows.First().Field<int>("newid");
        }

        public bool CanDelete()
        {
            var rows = Database.Select("SELECT COUNT(att.attendance_id) att_count FROM attendance att WHERE att.mee_meeting_id = " + id.ToString());
            return (rows.First().Field<long>(0) == 0);
        }

        public bool TryDelete()
        {
            if (CanDelete())
            {
                try
                {
                    Database.Execute("DELETE FROM meeting WHERE meeting_id=@meeting_id", GetParameters());
                    id = -1;
                    lesson = null;
                    course = null;
                    return true;
                }
                catch
                {
                    return false;
                }
            }
            return false;
        }

        private IEnumerable<DbParameter> GetParameters()
        {
            return new DbParameter[] 
            {
                Database.CreateParameter("@class_id", this.course.Id),
                Database.CreateParameter("@meeting_id", id),
                Database.CreateParameter("@lesson_id", lesson.Id),
                Database.CreateParameter("@meeting_date", this.date)
            };
        }

        static internal IEnumerable<Meeting> GetByCourse(Course course)
        {
            var rows = Database.Select("SELECT mee.* FROM meeting mee WHERE mee.cla_class_id = " + course.Id.ToString());
            foreach (DataRow r in rows)
                yield return new Meeting(course, r);
        }


    }
}
