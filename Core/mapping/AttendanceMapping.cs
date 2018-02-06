using FluentNHibernate.Mapping;
using Los.Core;

namespace Core.mapping
{
    public class AttendanceMapping : ClassMap<Attendance>
    {
        public AttendanceMapping()
        {
            Id(x => x.Id, "attendance_id");
            HasOne(x => x.Student).ForeignKey("rel_relation_id");
            HasOne(x => x.Meeting).ForeignKey("mee_meeting_id");
            Map(x => x.Note);
            Map(x => x.Status);
        }
    }
}