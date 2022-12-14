using FluentNHibernate.Mapping;

namespace lab2.Models
{
    public class DrinkOrder : IEntity
    {
        public virtual int Id { get; set; }
        public virtual Drink Drink { get; set; }
        public virtual Employees Waiter { get; set; }
        public virtual int Table { get; set; }
    }

    public class DrinkOrderMap : ClassMap<DrinkOrder>
    {
        DrinkOrderMap()
        {
            Table("drink_orders");
            Id(x => x.Id).GeneratedBy.Sequence("drink_orders_id_seq");
            References(x => x.Drink).Column("drink");
            References(x => x.Waiter).Column("waiter");
            Map(x => x.Table).Column("table_");
        }
    }
}