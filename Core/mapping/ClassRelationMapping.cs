using FluentNHibernate.Mapping;
using Los.Core;

namespace Core.mapping
{
    public class ClassRelationMapping : ClassMap<ClassRelation>
    {
        public ClassRelationMapping()
        {
            Table("class_relation");

            CompositeId()
                .KeyReference(x => x.Course, "cla_class_id")
                .KeyReference(x => x.Student, "rel_relation_id");

            Map(x => x.IsFinished, "finished");
            Map(x => x.System, "system");
        }
    }
}