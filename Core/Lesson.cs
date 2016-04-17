using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Los.Core
{

    public enum LessonType { Doctrine, Seminar };

    public class Lesson
    {
        private int id = -1;
		private int level_id = -1;
		private int order = -1;
        private string code = "";
        private string name = "";
        private bool homework = false;

        private Lesson()
        {
        }

        private Lesson(DataRow row)
        {
            id = row.Field<int>("lesson_id");
            level_id = row.Field<int>("lev_level_id");
            order = row.Field<int>("order");
            name = row.Field<string>("name");
            code = row.Field<string>("lesson_type_code");
            homework = row.Field<sbyte>("has_homework") > 0;
        }

        internal int Id
        {
            get { return id; }
        }

        public int Order
        {
            get { return order; }
        }

        public LessonType Type
        {
            get
            {
                switch (code.ToUpper())
                {
                    case "SEM": return LessonType.Seminar;
                    default: return LessonType.Doctrine;
                }
            }
        }

        public string Name
        {
            get { return name; }
        }

		public int LevelId {
			get { return this.level_id; }
		}

        public string GetCompleteName()
        {
            return string.Format("[{0} {1}] {2}", Type.ToString(), order, name);
        }

        public bool HasHomework
        {
            get { return homework; }
        }

        public string Chapter
        {
            get
            {
                return string.Format("{0} {1}", order, Type == LessonType.Doctrine ? "doc" : "sem");
            }
        }

        public override bool Equals(object obj)
        {
            return ((obj is Lesson) && ((obj as Lesson).id == this.id));
        }

        public override int GetHashCode()
        {
            return this.id;
        }

        static internal IEnumerable<Lesson> GetByLevel(Level level)
        {
            var rows = Database.Select("SELECT les.* FROM lesson les WHERE les.lev_level_id = " + level.Id.ToString());
            foreach (DataRow row in rows)
                yield return new Lesson(row);
        }

        static internal Lesson GetById(int lesson_id)
        {
            var row = Database.Select("SELECT les.* FROM lesson les WHERE les.lesson_id = " + lesson_id.ToString());
            if (row.Count() > 0)
                return new Lesson(row.First());
            else
                return new Lesson();

        }
    }
}
