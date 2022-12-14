using FluentNHibernate.Mapping;

namespace lab2.Models
{
    public class SnackRecipes
    {
        public virtual int Id { get; set; }
        public virtual Ingredient Ingredient { get; set; }
        public virtual int Count { get; set; }
    }

    public class SnackRecipesMap : ClassMap<SnackRecipes>
    {
        SnackRecipesMap()
        {
            Id(x => x.Id);
            References(x => x.Ingredient).Cascade.None();
            Map(x => x.Count);
        }
    }
}