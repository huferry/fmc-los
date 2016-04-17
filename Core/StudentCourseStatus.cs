using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;

namespace Los.Core
{
    public class StudentCourseStatus
    {
        private int class_id = -1;
        private int relation_id = -1;
        private bool finished = false;
        private bool enrolled = false;
        private int system = 0;

        internal StudentCourseStatus()
        {
            // create null status
        }

        internal StudentCourseStatus(DataRow row)
        {
            class_id = row.Field<int>("cla_class_id");
            relation_id = row.Field<int>("rel_relation_id");
            finished = (row.Field<sbyte>("finished") != 0);
            system = row.IsNull("system") ? 0 : row.Field<int>("system");
            enrolled = true;
        }

        public bool Finished
        {
            get { return finished; }
        }

        public bool Enrolled
        {
            get
            {
                return enrolled;
            }
        }

        public int System
        {
            get { return system; }
            set
            {
                if (value != system)
                {
                    system = value;
                    DbParameter[] parameters = new DbParameter[]
                    {
                        Database.CreateParameter("@class", class_id),
                        Database.CreateParameter("@relation", relation_id),
                        Database.CreateParameter("@system", system)
                    };
                    Database.Execute("UPDATE class_relation SET system=@system WHERE cla_class_id=@class AND rel_relation_id=@relation", parameters);
                }
            }
        }

        static internal StudentCourseStatus GetStatus(int class_id, int relation_id)
        {
            var row = Database.Select("SELECT * FROM class_relation WHERE cla_class_id=" + class_id.ToString() +
                                      " AND rel_relation_id=" + relation_id.ToString());

            if (row.Count() > 0)
                return new StudentCourseStatus(row.First());
            else
                return new StudentCourseStatus();
        }

        static public void SetFinished(Course course, Relation relation, bool finished)
        {
            DbParameter[] parameters = new DbParameter[]
            {
                Database.CreateParameter("@class", course.Id),
                Database.CreateParameter("@relation", relation.Id),
                Database.CreateParameter("@finished", finished ? (sbyte)1 : (sbyte)0)
            };

            var row = Database.Select(
                string.Format("SELECT finished FROM class_relation WHERE cla_class_id={0} AND rel_relation_id={1}", 
                              course.Id, relation.Id));
  
            if (row.Count() > 0) 
            {
                if ((row.First().Field<sbyte>("finished")==1) != finished)
                    Database.Execute("UPDATE class_relation SET finished=@finished WHERE cla_class_id=@class AND rel_relation_id=@relation", parameters);
            }
            else
            {                
                throw new Exception("Relation is not registered in the class");
            }
        }
    }
}
