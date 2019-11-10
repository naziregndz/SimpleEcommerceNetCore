using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using Mappings;
using Microsoft.Extensions.Configuration;
using NHibernate;
using NHibernate.Tool.hbm2ddl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreWebAPI
{
    public class SessionFactoryBuilder
    {
        public static ISession OpenSession()
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
               .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
               .AddJsonFile("appsettings.json")
               .Build();

            string connectionString = "Server=DESKTOP-0K6VAA6\\SQLEXPRESS;Database=NGT_DB_ECOMM;Trusted_Connection=True;MultipleActiveResultSets=true";
            var sessionFactory = Fluently.Configure()
                .Database(MsSqlConfiguration.MsSql2012
                 .ConnectionString(connectionString).ShowSql()
                )
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<AddressMap>())
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<CouponMap>())
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<CartMap>())
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<ProductMap>())
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<ProductTypeMap>())
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<CustomerMap>())
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<OrderMap>())
                .ExposeConfiguration(cfg => new SchemaExport(cfg)
                .Create(false, false))
                .BuildSessionFactory();
            return sessionFactory.OpenSession();
        }
    }
}
