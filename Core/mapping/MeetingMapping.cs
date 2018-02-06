using FluentNHibernate.Mapping;
using Los.Core;

namespace Core.mapping
{
    public class MeetingMapping : ClassMap<Meeting>
    {
        public MeetingMapping()
        {
            Id(x => x.Id, "meeting_id");
            HasOne(x => x.Lesson).ForeignKey("les_lesson_id");
            HasOne(x => x.Course).ForeignKey("cla_class_id");
            Map(x => x.MeetingDate, "meeting_date");
        }
    }
}