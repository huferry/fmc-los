using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using Los.Core;

namespace Core.mapping
{
    public class CourseMapping : ClassMap<Course>
    {
        public CourseMapping()
        {
            Table("class");
            Id(x => x.Id).Column("class_id");
            Map(x => x.LevelId).Column("level_id");
            Map(x => x.Name).Not.Nullable();
            Map(x => x.Description);
            Map(x => x.DateStart).Column("date_begin");
            Map(x => x.DateEnd).Column("date_end");
            Map(x => x.OpenEnrollment).Column("open_enrollment");
            HasMany(x => x.Students).KeyColumn("cla_class_id").Cascade.None();
        }
    }
}
