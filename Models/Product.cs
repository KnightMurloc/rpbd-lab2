using FluentNHibernate.Mapping;

namespace lab2.Models
{
    public class Product : IEntity
    {
        public virtual int Id { get; set; }
        public virtual Ingredient Ingredient { get; set; }
        public virtual float Price { get; set; }
        public virtual string DeliveryTerms { get; set; }
        public virtual string PaymentTerms { get; set; }
        public virtual Provider Provider { get; set; }
        public virtual string Name { get; set; }
    }

    public class ProductMap : ClassMap<Product>
    {
        public ProductMap()
        {
            Table("products");
            Id(x => x.Id)
                .GeneratedBy.Sequence("products_id_seq");
            References(x => x.Ingredient)
                .Cascade.Delete()
                .Column("ingredient");
            Map(x => x.Price).Column("price");
            Map(x => x.DeliveryTerms).Column("delivery_terms");
            Map(x => x.PaymentTerms).Column("payment_terms");
            References(x => x.Provider)
                .NotFound.Ignore()
                .Column("provider");
            Map(x => x.Name).Column("name");
        }
    }
}