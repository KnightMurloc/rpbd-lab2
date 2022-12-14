using FluentNHibernate.Mapping;

namespace lab2.Models
{
    public class DrinkRecipes
    {
        public virtual int Id { get; set; }
        public virtual Ingredient Ingredient { get; set; }
        public virtual int Count { get; set; }
    }

    public class DrinkRecipesMap : ClassMap<DrinkRecipes>
    {
        DrinkRecipesMap()
        {
            Id(x => x.Id);
            References(x => x.Ingredient).Cascade.None();
            Map(x => x.Count);
        }
    }
}