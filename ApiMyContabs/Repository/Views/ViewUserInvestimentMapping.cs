using FluentNHibernate.Automapping;
using FluentNHibernate.Automapping.Alterations;
using FluentNHibernate.Mapping;

namespace ApiMyContabs.Repository.Views
{
    public class ViewUserInvestimentMapping : ClassMap<ViewUserInvestiment>
    {
        public void ViewUserInvestiment()
        {
            Table("ViewUserInvestiment");
            Map(x => x.UserId).Column("UserId");
            Map(x => x.UserName).Column("UserName");
            Map(x => x.TotalInvestiment).Column("TotalInvestiment");
            Map(x => x.TotalBills).Column("TotalBills");
            Map(x => x.MetaDescription).Column("MetaDescription");
            Map(x => x.MetaValue).Column("MetaValue");
            ReadOnly();
        }
    }
}
