using FluentNHibernate.Mapping;
using ApiMyContabs.Repository.Entity;

namespace ApiMyContabs.Repository.Mapping
{
    public class SpenderMapping :ClassMap<Spender>
    {
        public SpenderMapping() 
        {
            Table("t_spender");
            Id(x=>x.Id).Column("id");
            Map(x=>x.Name).Column("name");
            Map(x => x.Profile).Column("profile");
            Map(x => x.PhoneNumber).Column("phonenumber");
            Map(x => x.Email).Column("email");
        } 
    }
}
