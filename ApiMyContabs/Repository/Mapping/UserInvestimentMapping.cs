using FluentNHibernate.Mapping;
using ApiMyContabs.Repository.Entity;

namespace ApiMyContabs.Repository.Mapping
{
    public class UserInvestimentMapping :ClassMap<UserInvestiment>
    {
        public UserInvestimentMapping()
        {
            Table("t_userinvestiment");
            Id(x => x.Id).Column("Id");
            Map(x => x.InvestimentValue).Column("InvestimentValue");
            Map(x => x.InvestimentDate).Column("InvestimentDate");
            References(x => x.User).Column("User_Id");
        }
    }
}
