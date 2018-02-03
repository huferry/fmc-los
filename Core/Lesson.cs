using System.Collections.Generic;
using System.Linq;
using Core;

namespace Los.Core
{
    public enum LessonType
    {
        Doctrine,
        Seminar
    }

    public class Lesson
    {
        public virtual int Id { get; set; }

        public virtual int Order { get; set; }

        public virtual string Code { get; set; }

        public virtual LessonType Type
        {
            get
            {
                switch (Code.ToUpper())
                {
                    case "SEM": return LessonType.Seminar;
                    default: return LessonType.Doctrine;
                }
            }
        }

        public virtual string Name { get; set; }

        public virtual Level Level { get; set; }

        public virtual bool HasHomework { get; set; }

        public virtual string Chapter =>
            string.Format("{0} {1}", Order, Type == LessonType.Doctrine ? "doc" : "sem");

        public virtual string GetCompleteName()
        {
            return string.Format("[{0} {1}] {2}", Type.ToString(), Order, Name);
        }

        public override bool Equals(object obj)
        {
            return (obj as Lesson)?.Id == Id;
        }

        public override int GetHashCode()
        {
            return Id;
        }

        internal static IEnumerable<Lesson> GetByLevel(Level level)
        {
            return Repository.Query<Lesson>().Where(l => l.Level.Id == level.Id);
        }
    }
}