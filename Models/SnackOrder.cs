using FluentNHibernate.Mapping;

namespace lab2.Models
{
    public class SnackOrder : IEntity
    {
        public virtual int Id { get; set; }
        public virtual Snack Snack { get; set; }
        public virtual Employees Waiter { get; set; }
        public virtual int Table { get; set; }
    }
    
    public class SnackOrderMap : ClassMap<SnackOrder>{
        public SnackOrderMap()
        {
            Table("snack_orders");
            Id(x => x.Id).GeneratedBy.Sequence("snack_orders_id_seq");
            References(x => x.Snack).Column("snack");
            References(x => x.Waiter).Column("waiter");
            Map(x => x.Table).Column("table_");
        }
    }
}