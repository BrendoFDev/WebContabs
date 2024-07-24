using FluentNHibernate.Mapping;
using ApiMyContabs.Repository.Entity;

namespace ApiMyContabs.Repository.Mapping
{
    public class UserBillMapping :ClassMap<UserBill>
    {
        public UserBillMapping() 
        {
            Table("t_userbill");
            Id(x => x.Id).Column("id");
            Map(x=>x.Description).Column("description");
            Map(x => x.TotalValue).Column("totalvalue");
            Map(x => x.InstallmentAmount).Column("installmentvalue");
            Map(x => x.InitialDate).Column("initialdate");
            Map(x => x.FinalDate).Column("finaldate");
            References(x => x.User).Column("user_id");
        }
     
    }
}
