using FluentNHibernate.Mapping;
using ApiMyContabs.Repository.Entity;

namespace ApiMyContabs.Repository.Mapping
{
    public class UserMetaMapping : ClassMap<UserMeta>
    {
        public UserMetaMapping() 
        {
            Table("t_usermeta");
            Id(x => x.Id).Column("Id");
            Map(x=>x.Description).Column("Description");
            Map(x => x.MetaValue).Column("MetaValue");
            References(x => x.User).Column("User_Id");
        }
    }
}
