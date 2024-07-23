using FluentNHibernate.Mapping;
using ApiMyContabs.Repository.Entity;

namespace ApiMyContabs.Repository.Mapping
{
    public class AddressMapping :ClassMap<Address>
    {
        public AddressMapping()
        {
            Table("t_address");
            Id(x => x.Id).Column("Id");
            Map(x=>x.StreetName).Column("StreetName");
            Map(x => x.Neigborhood).Column("Neigborhood");
            Map(x => x.City).Column("City");
            Map(x => x.HouseNumber).Column("HouseNumber");
            References(x => x.Spender).Column("Spender_Id");
        }
    }
}
