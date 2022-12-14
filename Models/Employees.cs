using FluentNHibernate.Mapping;
using System;
using FluentNHibernate;
using NHibernate;

namespace lab2.Models
{
    public class Employees : IEntity
    {
        public virtual int Id { get; set; }
        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set; }

        public virtual string Patronymic { get; set; }

        // public virtual string Address { get; set; }
        public virtual Address Address { get; set; }
        public virtual DateTime BirthDate { get; set; }
        public virtual float Salary { get; set; }
        public virtual Post Post { get; set; }
        
        // public virtual Order Order { get; set; }
    }

    class EmployeesMap : ClassMap<Employees>
    {
        public EmployeesMap()
        {
            Table("employees");
            Id(x => x.Id).Column("id").GeneratedBy.Sequence("employees_id_seq");
            Map(x => x.FirstName).Column("first_name");
            Map(x => x.LastName).Column("last_name");
            Map(x => x.Patronymic).Column("patronymic");
            References(x => x.Address).Column("address");
            Map(x => x.BirthDate).Column("birth_date");
            Map(x => x.Salary).Column("salary");
            References(x => x.Post).NotFound.Ignore().Column("post");
            // References(x => x.Order).NotFound.Ignore();
        }
    }

    // public class EmployeesRepository : IRepositoryBase<Employees>
    // {
    //     private ISession Session;
    //
    //     public EmployeesRepository(ISession session)
    //     {
    //         Session = session;
    //     }
    //
    //     public IQuery FindByCondition(string expression, int count)
    //     {
    //         return Session.CreateQuery(expression).SetMaxResults(count);
    //     }
    //
    //     public void Create(Employees entity)
    //     {
    //         Session.Save(entity);
    //         Session.Flush();
    //     }
    //
    //     public void Update(Employees entity)
    //     {
    //        Session.Update(entity);
    //        Session.Flush();
    //     }
    //
    //     public void Delete(Employees entity)
    //     {
    //         Session.Delete(entity);
    //         Session.Flush();
    //     }
    //
    //     public Employees Find(int id)
    //     {
    //         throw new NotImplementedException();
    //     }
    // }
}