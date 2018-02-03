using FluentNHibernate.Mapping;
using Los.Core;
using NHibernate.Type;

namespace Los.CoreCore
{
    public class RelationMapping : ClassMap<Relation>
    {
        public RelationMapping()
        {
            Table("relation");
            Id(x => x.Id).Column("relation_id");
            Map(x => x.Surname).Column("lastname").Not.Nullable();
            Map(x => x.Firstname).Column("firstname").Not.Nullable();
            Map(x => x.Birthday).Column("birthday");
            Map(x => x.PhoneHome).Column("phone_home");
            Map(x => x.PhoneMobile).Column("phone_mobile");
            Map(x => x.GenderValue).Column("gender");
            Map(x => x.Approved).Column("approved");
            Map(x => x.IsCareLeader).Column("is_leader");
            Map(x => x.CareLeaderId).Column("leader_relation_id");
            HasOne(x => x.CareLeader).ForeignKey("leader_relation_id");
        }
    }
}