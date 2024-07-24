using FluentNHibernate.Mapping;
using ApiMyContabs.Repository.Entity;

namespace ApiMyContabs.Repository.Mapping
{
    public class UserBankAccountMapping : ClassMap<UserBankAccount>
    {
        public UserBankAccountMapping() 
        {
            Table("t_userbankaccount");
            Id(x => x.Id).Column("id");
            Map(x=>x.Name).Column("name");
            Map(x => x.Limit).Column("limit");
            References(x => x.User).Column("user_id");
        }
    }
}
