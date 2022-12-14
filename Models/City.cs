using FluentNHibernate.Mapping;

namespace lab2.Models
{
    public class City : IEntity
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
    }

    public class CityMap : ClassMap<City>
    {
        public CityMap()
        {
            Table("city");
            Id(x => x.Id).GeneratedBy.Sequence("city_id_seq");
            Map(x => x.Name).Column("name");
        }
    }
}