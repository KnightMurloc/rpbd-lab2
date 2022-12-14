using FluentNHibernate.Mapping;

namespace lab2.Models
{
    public class Provider : IEntity
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        // public virtual string PostAddress { get; set; }
        public virtual Address PostAddress { get; set; }
        public virtual string PhoneNumber { get; set; }
        public virtual string Fax { get; set; }
        public virtual string Email { get; set; }
    }

    public class ProviderMap : ClassMap<Provider>
    {
        public ProviderMap()
        {
            Table("provider");
            Id(x => x.Id).GeneratedBy.Sequence("provider_id_seq");
            Map(x => x.Name).Column("name");
            References(x => x.PostAddress).Column("post_address");
            Map(x => x.PhoneNumber).Column("phone_number");
            Map(x => x.Fax).Column("fax");
            Map(x => x.Email).Column("email");
        }
    }
}