using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Core;

namespace Los.Core
{
    public class Level : IComparable
    {
        private List<Lesson> lessons = null;

        #region Properties

        public virtual int Id { get; set; }

        public virtual string Name { get; set; }

        public virtual string Code { get; set; }

        public virtual Level PreviousLevel { get; set; }

        #endregion

        public override string ToString()
        {
            return Name;
        }

        public override int GetHashCode()
        {
            return Id;
        }

        public virtual Level Next => Level.All.FirstOrDefault(x => x.PreviousLevel.Id == Id);

        private IEnumerable<Lesson> GetLessons() => Lesson.GetByLevel(this).OrderBy(x => x.Order);

        public virtual IEnumerable<Lesson> Lessons
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

        private static List<Level> levels = null;

        public static IEnumerable<Level> All
        {
            get
            {
                if (levels == null)
                {
                    levels = Repository.GetAll<Level>().ToList();
                }
                return levels;
            }
                
        }

        public static Level Lowest
        {
            get
            {
                return All.OrderBy(x => x).First();
            }
        }

        internal static Level ById(int level_id)
        {
            return All.Where(x => x.Id == level_id).First();
        }

        #endregion


        #region IComparable Members

        public virtual int CompareTo(object obj)
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
