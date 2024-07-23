using FluentNHibernate.Mapping;
using ApiMyContabs.Repository.Entity;
using NHibernate.Linq;

namespace ApiMyContabs.Repository.Mapping
{
    public class BankAccountMapping : ClassMap<BankAccount>
    {
        public BankAccountMapping()
        {
            Table("t_bankaccount"); 
            Id(x => x.Id).Column("Id");
            Map(x=>x.Name).Column("Name");
            Map(x=>x.Limit).Column("Limit");
            References(x => x.Spender).Column("Spender_Id");
        }
    }
}
