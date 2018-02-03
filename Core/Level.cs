using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Los.Core
{
    public class Level : IComparable
    {
        private int level_id;
        private int previous_level_id;
        private string name;
        private string code;
        private List<Lesson> lessons = null;

        private Level(DataRow row)
        {
            level_id = row.Field<int>("level_id");
            if (row.IsNull("lev_level_id"))
                previous_level_id = -1;
            else
                previous_level_id = row.Field<int>("lev_level_id");
            name = row.Field<string>("name");
            code = row.Field<string>("code");
        }

        #region Properties

        public int Id
        {
            get { return level_id; }
        }

        public string Name
        { get { return name; } }

        public string Code
        {
            get { return code; }
        }

        #endregion

        public override string ToString()
        {
            return name;
        }

        public override int GetHashCode()
        {
            return level_id;
        }

        public Level Next
        {
            get
            {
                var next = Level.All.Where(x => x.previous_level_id == level_id);
                if (next.Count() > 0)
                    return next.First();
                else
                    return null;
            }
        }

        private IEnumerable<Lesson> GetLessons()
        {
            return Lesson.GetByLevel(this).OrderBy(x => x.Order);
        }

        public IEnumerable<Lesson> Lessons
        {
            get
            {
                if (lessons == null)
                {
                    lessons = new List<Lesson>();
                    lessons.AddRange(GetLessons());
                }
                return lessons;
            }
        }

        #region static data

        static private List<Level> levels = null;

        static private IEnumerable<Level> GetAll()
        {
            foreach (DataRow row in Database.Select("SELECT lev.* FROM level lev ORDER BY lev.lev_level_id"))
            {
                yield return new Level(row);
            }
        }

        static public IEnumerable<Level> All
        {
            get
            {
                if (levels == null)
                {
                    levels = GetAll().ToList();
                }
                return levels;
            }
                
        }

        static public Level Lowest
        {
            get
            {
                return All.OrderBy(x => x).First();
            }
        }

        static internal Level ById(int level_id)
        {
            return All.Where(x => x.level_id == level_id).First();
        }

        #endregion


        #region IComparable Members

        public int CompareTo(object obj)
        {
            if (obj == null)
                throw new Exception("Cannot compare Level with null");

            if (obj is Level)
            {
                return levels.IndexOf(this).CompareTo(levels.IndexOf(obj as Level));
            }

            throw new Exception("Cannot compare Level object to class " + obj.GetType().ToString());
        }

        #endregion
    }
}
