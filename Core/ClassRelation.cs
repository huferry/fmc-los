using System.Linq;
using Los.Core;

namespace Core
{
    public class ClassRelation
    {
        public virtual Course Course { get; set; }
        public virtual Relation Student { get; set; }
        public virtual int? System { get; set; }
        public virtual bool IsFinished { get; set; }

#pragma warning disable 659
        public override bool Equals(object obj)
#pragma warning restore 659
        {
            var other = obj as ClassRelation;
            return other?.Course.Id == Course.Id && other.Student.Id == Student.Id;
        }

        public override int GetHashCode()
        {
            return Course.Id * 1000 + Student.Id;
        }

        public static void SetFinished(Course course, Relation relation, bool isFinished)
        {
            var classRel = Repository.Query<ClassRelation>()
                .SingleOrDefault(c => c.Student.Id == relation.Id && c.Course.Id == course.Id);

            if (classRel != null)
            {
                classRel.IsFinished = isFinished;
                Repository.Save(classRel);
            }
        }
    }
}