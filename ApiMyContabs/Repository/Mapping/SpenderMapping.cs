using FluentNHibernate.Mapping;
using ApiMyContabs.Repository.Entity;

namespace ApiMyContabs.Repository.Mapping
{
    public class SpenderMapping :ClassMap<Spender>
    {
        public SpenderMapping() 
        {
            Table("t_spender");
            Id(x=>x.Id).Column("Id");
            Map(x=>x.Name).Column("Name");
            Map(x => x.Profile).Column("Profile");
            Map(x => x.PhoneNumber).Column("PhoneNumber");
            Map(x => x.Email).Column("Email");
        } 
    }
}
