using FluentNHibernate.Mapping;
using ApiMyContabs.Repository.Entity;

namespace ApiMyContabs.Repository.Mapping
{
    public class UserInvestimentMapping :ClassMap<UserInvestiment>
    {
        public UserInvestimentMapping()
        {
            Table("t_userinvestiment");
            Id(x => x.Id).Column("id");
            Map(x => x.InvestimentValue).Column("investimentvalue");
            Map(x => x.InvestimentDate).Column("investimentdate");
            References(x => x.User).Column("user_id");
        }
    }
}
