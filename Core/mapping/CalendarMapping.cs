using FluentNHibernate.Mapping;
using Los.Core;

namespace Core.mapping
{
    public class CalendarMapping : ClassMap<Calendar>
    {
        public CalendarMapping()
        {
            Id(x => x.Id, "calendar_id");
            Map(x => x.Name);
            Map(x => x.DateStart, "date_start");
            Map(x => x.DateEnd, "date_end");
        }
    }
}