using FluentNHibernate.Mapping;

namespace lab2.Models
{
    public class Unit
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
    }

    public class UnitMap : ClassMap<Unit>
    {
        UnitMap()
        {
            Table("unit");
            Id(x => x.Id).GeneratedBy.Sequence("Unit_id_seq");
            Map(x => x.Name).Column("name");
        }
    }
}