using FluentNHibernate.Mapping;

namespace lab2.Models
{
    public class Address
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
    }
    
    public class AddressMap : ClassMap<Address>
    {
        public AddressMap()
        {
            Table("address");
            Id(x => x.Id).GeneratedBy.Sequence("address_id_seq");
            Map(x => x.Name).Column("name");
        }
    }
}