using FluentNHibernate.Mapping;
using ApiMyContabs.Repository.Entity;
using NHibernate.Mapping;

namespace ApiMyContabs.Repository.Mapping
{
    public class UserMapping : ClassMap<User>
    {
        public UserMapping()
        {
            Table("t_user");
            Id(x => x.Id).Column("Id");
            Map(x=>x.Name).Column("Name");
            Map(x => x.Email).Column("Email");
            Map(x=>x.Password).Column("Password");
        }
    }
}
