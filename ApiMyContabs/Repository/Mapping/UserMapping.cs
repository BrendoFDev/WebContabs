using FluentNHibernate.Mapping;
using ApiMyContabs.Repository.Entity;

namespace ApiMyContabs.Repository.Mapping
{
    public class UserMapping : ClassMap<User>
    {
        public UserMapping()
        {
            Table("t_user");
            Id(x => x.Id).Column("id").GeneratedBy.Sequence("t_user_id_seq");
            Map(x => x.Name).Column("name");
            Map(x => x.Email).Column("email");
            Map(x => x.Password).Column("password");
        }
    }
}