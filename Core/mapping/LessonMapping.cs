using FluentNHibernate.Mapping;
using Los.Core;

namespace Core.mapping
{
    public class LessonMapping : ClassMap<Lesson>
    {
        public LessonMapping()
        {
            Table("lesson");
            Id(x => x.Id, "lesson_id");
            HasOne(x => x.Level).ForeignKey("lev_level_id");
            Map(x => x.Order, "order");
            Map(x => x.Name, "name");
            Map(x => x.Code, "lesson_type_code");
            Map(x => x.HasHomework, "has_homework");
        }
    }
}