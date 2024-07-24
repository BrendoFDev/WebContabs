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
            Id(x => x.Id).Column("id");
            Map(x=>x.Name).Column("name");
            Map(x=>x.Limit).Column("limit");
            References(x => x.Spender).Column("spender_id");
        }
    }
}
