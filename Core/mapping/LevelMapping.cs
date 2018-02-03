using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using Los.Core;

namespace Core.mapping
{
    public class LevelMapping : ClassMap<Level>
    {
        public LevelMapping()
        {
            Table("level");
            Id(x => x.Id, "level_id");
            Map(x => x.Code, "code");
            Map(x => x.Name, "name");
            HasOne(x => x.PreviousLevel).ForeignKey("lev_level_id");
        }
    }
}
