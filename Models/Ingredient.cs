using FluentNHibernate.Mapping;

namespace lab2.Models
{
    public class Ingredient : IEntity
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual Unit Unit { get; set; }
    }

    public class IngredientMap : ClassMap<Ingredient>
    {
        IngredientMap()
        {
            Table("ingredients");
            Id(x => x.Id).GeneratedBy.Sequence("ingredients_id_seq");
            Map(x => x.Name).Column("name");
            References(x => x.Unit).NotFound.Exception().Column("unit");
        }
    }
}