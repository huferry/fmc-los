using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Los.Core;

namespace LoSAdmin.Reports
{
    public class StudentEnrolInvitation
    {
        private Relation relation;
        private Course[] courses;

        public StudentEnrolInvitation(Relation relation)
        {
            this.relation = relation;
            courses = Course.GetNextPossibleCoursesByRelation(relation).ToArray();
        }

        public string Name
        {
            get { return relation.Firstname + " " + relation.Surname; }
        }

        public string CourseName
        {
            get 
            {
                string n = "";
                foreach (Course c in courses)
                    n += "[  ] " + c.Name + "\r\n";
                return n;
            }
        }

        public string Level
        {
            get { return courses[0].Level.Name; }
        }

        public string Birthday
        {
            get { return relation.Birthday?.ToString("dd/MMM/yyyy"); }
        }

        public string Period
        {
            get
            {
                return courses[0].DateStart.ToString("dd/MMM/yyyy") + " to " + courses[0].DateEnd.ToString("dd/MMM/yyyy");
            }
        }

        public string CareLeader
        {
            get
            {
                return relation.CareLeaderId?.ToString();
            }
        }
    }
}
