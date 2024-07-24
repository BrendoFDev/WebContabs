using FluentNHibernate.Mapping;
using ApiMyContabs.Repository.Entity;

namespace ApiMyContabs.Repository.Mapping
{
    public class AddressMapping :ClassMap<Address>
    {
        public AddressMapping()
        {
            Table("t_address");
            Id(x => x.Id).Column("id");
            Map(x=>x.StreetName).Column("streetname");
            Map(x => x.Neigborhood).Column("Neigborhood");
            Map(x => x.City).Column("city");
            Map(x => x.HouseNumber).Column("housenumber");
            References(x => x.Spender).Column("spender_id");
        }
    }
}
