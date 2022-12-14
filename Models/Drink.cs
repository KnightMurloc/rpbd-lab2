using System.Collections.Generic;
using FluentNHibernate.Mapping;

namespace lab2.Models
{
    public class Drink : IEntity
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual int Strength { get; set; }
        public virtual int Size { get; set; }
        public virtual string Container { get; set; }
        private IList<DrinkRecipes> _ingredients;

        public virtual IList<DrinkRecipes> Ingredients
        {
            get
            {
                return _ingredients ??= new List<DrinkRecipes>();
            }
            set => _ingredients = value;
        }
    }

    public class DrinkMap : ClassMap<Drink>
    {
        DrinkMap()
        {
            Id(x => x.Id);
            Map(x => x.Name);
            Map(x => x.Strength);
            Map(x => x.Size);
            Map(x => x.Container);
            HasMany(x => x.Ingredients)
                .Cascade.SaveUpdate()
                .Cascade.DeleteOrphan();
        }
    }
}