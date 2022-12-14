using System;
using FluentNHibernate.Conventions.Inspections;
using FluentNHibernate.Mapping;
using lab2.Models.NHibernate;
using NHibernate;
using NHibernate.Mapping;

namespace lab2.Models
{
    public class Order : IEntity
    {
        public virtual int Id { get; set; }
        public virtual string Reason { get; set; }
        public virtual int OrderNumber { get; set; }
        public virtual DateTime OrderDate { get; set; }
        public virtual Employees Employees { get; set; }
        public virtual Post Post { get; set; }
    }

    public class OrderMap : ClassMap<Order>
    {
        OrderMap()
        {
            Table("orders");
            Id(x => x.Id).GeneratedBy.Sequence("movements_id_seq");
            Map(x => x.Reason).Column("reason");
            Map(x => x.OrderNumber).Column("order_number");
            Map(x => x.OrderDate).Column("order_date");
            References(x => x.Employees).NotFound.Ignore().Column("employer");
            // References(x => x.Employees).Cascade.All().Column("employer");
            // References(x => x.Employees).Column("employer").Unique();
            // OneToOne
            // HasMany<Employees>(x => x.Employees).Cascade.AllDeleteOrphan();
            References(x => x.Post).NotFound.Ignore().Column("post");
        }
    }
    
    // public class OrderRepository : IRepositoryBase<Order>
    // {
    //     private ISession Session;
    //     private static OrderRepository instance = null; 
    //     
    //     private OrderRepository()
    //     {
    //         Session = NHibernateHelper.OpenSession();
    //     }
    //
    //     public static OrderRepository Instance
    //     {
    //         get
    //         {
    //             if (instance == null)
    //             {
    //                 instance = new OrderRepository();
    //             }
    //
    //             return instance;
    //         }
    //     }
    //     
    //     public IQuery FindByCondition(string expression, int count)
    //     {
    //         return Session.CreateQuery(expression).SetMaxResults(count);
    //     }
    //     
    //     public IQuery FindByCondition(string expression)
    //     {
    //         return Session.CreateQuery(expression);
    //     }
    //
    //     public void Create(Order entity)
    //     {
    //         throw new System.NotImplementedException();
    //     }
    //
    //     public void Update(Order entity)
    //     {
    //         Session.Update(entity);
    //         Session.Flush();
    //     }
    //
    //     public void Delete(Order entity)
    //     {
    //         throw new System.NotImplementedException();
    //     }
    //
    //     public Order Find(int id)
    //     {
    //         Order order = Session.Get<Order>(id);
    //         Session.Refresh(order);
    //         return order;
    //     }
    // }
}