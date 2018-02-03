using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Los.Core;

namespace LoSAdmin.Reports
{
    class StudentAttendance
    {
        static private int count = 0;
        static private Course last_course = null;

        private Course course;
        private Relation relation;
        public int number;

        static public void Reset()
        {
            count = 0;
        }

        public StudentAttendance(Course course, Relation rel)
        {
            if (last_course != course)
            {
                count = 0;
                last_course = course;
            }

            this.course = course;
            this.relation = rel;
            number = ++count;
        }

        public string Course
        {
            get { return course.Name; }
        }

        public string Number
        {
            get { return number.ToString(); }
        }

        public string Name
        {
            get { return relation.ToString(); }
        }

        public string ObjectCode
        {
            get { return relation.Id.ToString(); }
        }
        
    }

    class ClassAttendance
    {
        private List<StudentAttendance> students = new List<StudentAttendance>();

        public ClassAttendance(Course course)
        {
            StudentAttendance.Reset();
            foreach (Relation rel in course.GetStudents().OrderBy(x => x.Firstname))
                students.Add(new StudentAttendance(course, rel));
        }

        public ClassAttendance(IEnumerable<Course> courses)
        {
            StudentAttendance.Reset();
            foreach (Course course in courses)
            {
                foreach (Relation rel in course.GetStudents().OrderBy(x => x.Firstname))
                    students.Add(new StudentAttendance(course, rel));
            }
        }

        public IEnumerable<StudentAttendance> GetStudents()
        {
            return students;
        }
    }
}
