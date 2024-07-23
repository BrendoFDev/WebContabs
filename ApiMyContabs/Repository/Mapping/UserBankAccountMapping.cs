using FluentNHibernate.Mapping;
using ApiMyContabs.Repository.Entity;

namespace ApiMyContabs.Repository.Mapping
{
    public class UserBankAccountMapping : ClassMap<UserBankAccount>
    {
        public UserBankAccountMapping() 
        {
            Table("t_userbankaccount");
            Id(x => x.Id).Column("Id");
            Map(x=>x.Name).Column("Name");
            Map(x => x.Limit).Column("Limit");
            References(x => x.User).Column("User_Id");
        }
    }
}
