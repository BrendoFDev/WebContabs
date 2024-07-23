using FluentNHibernate.Mapping;
using ApiMyContabs.Repository.Entity;

namespace ApiMyContabs.Repository.Mapping
{
    public class UserBillMapping :ClassMap<UserBill>
    {
        public UserBillMapping() 
        {
            Table("t_userbill");
            Id(x => x.Id).Column("Id");
            Map(x=>x.Description).Column("Description");
            Map(x => x.TotalValue).Column("TotalValue");
            Map(x => x.InstallmentAmount).Column("InstallmentValue");
            Map(x => x.InitialDate).Column("InitialDate");
            Map(x => x.FinalDate).Column("FinalDate");
            References(x => x.User).Column("User_Id");
        }
     
    }
}
