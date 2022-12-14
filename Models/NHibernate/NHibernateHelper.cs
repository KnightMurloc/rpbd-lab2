using System;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Tool.hbm2ddl;

namespace lab2.Models.NHibernate
{
    public class NHibernateHelper
    {
        public static ISession OpenSession() {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
            ISessionFactory sessionFactory = Fluently.Configure()
                // .Database(MsSqlConfiguration.MsSql2008.ConnectionString(@"Server=..\SQLENTERPRISE; initial catalog= Biblioteca; Integrated Security=SSPI;").ShowSql()
                // )
                .Database(PostgreSQLConfiguration.Standard.ConnectionString(@"server=localhost;Port=5432;Database=lab2;User Id=postgres;Password=miku;").ShowSql())
                .Mappings(m =>m.FluentMappings.AddFromAssemblyOf<Employees>())
                .Mappings(m =>m.FluentMappings.AddFromAssemblyOf<Order>())
                .Mappings(m =>m.FluentMappings.AddFromAssemblyOf<Ingredient>())
                .Mappings(m =>m.FluentMappings.AddFromAssemblyOf<Provider>())
                .Mappings(m =>m.FluentMappings.AddFromAssemblyOf<BankDetail>())
                // .Mappings(m => m.FluentMappings)
                .ExposeConfiguration(cfg => new SchemaUpdate(cfg).Execute(false, true))
                .BuildSessionFactory();
            

            return sessionFactory.OpenSession();
        }
    }
}