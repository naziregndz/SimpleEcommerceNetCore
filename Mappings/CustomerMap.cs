using System;
using FluentNHibernate.Mapping;
using Entities;

namespace Mappings
{
    public class CustomerMap : ClassMap<Customer>
    {
        public CustomerMap()
        {
            Table("Customer");
            Id(x => x.Id).GeneratedBy.Identity();
            Map(x => x.Name);
            Map(x => x.Surname);
            Map(x => x.Email);
            Map(x => x.Password);
            Map(x => x.Phone);
        }
    }
}
