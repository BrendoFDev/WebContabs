using FluentNHibernate.Mapping;
using ApiMyContabs.Repository.Entity;

namespace ApiMyContabs.Repository.Mapping
{
    public class UserMetaMapping : ClassMap<UserMeta>
    {
        public UserMetaMapping() 
        {
            Table("t_usermeta");
            Id(x => x.Id).Column("id");
            Map(x=>x.Description).Column("description");
            Map(x => x.MetaValue).Column("metavalue");
            References(x => x.User).Column("user_id");
        }
    }
}
