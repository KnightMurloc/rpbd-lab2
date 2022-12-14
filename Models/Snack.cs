using System.Collections.Generic;
using FluentNHibernate.Mapping;

namespace lab2.Models
{
    public class Snack : IEntity
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual int Size { get; set; }
        private IList<SnackRecipes> _ingredients;

        public virtual IList<SnackRecipes> Ingredients
        {
            get
            {
                return _ingredients ??= new List<SnackRecipes>();
            }
            set => _ingredients = value;
        }
    }

    public class SnackMap : ClassMap<Snack>
    {
        SnackMap()
        {
            Id(x => x.Id);
            Map(x => x.Name);
            Map(x => x.Size);
            HasMany(x => x.Ingredients)
                .Cascade.SaveUpdate()
                .Cascade.DeleteOrphan();
        }
    }
}