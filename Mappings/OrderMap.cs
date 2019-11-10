using Entities;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mappings
{

    public class OrderMap : ClassMap<Order>
    {
        public OrderMap()
        {
            Table("[Order]");
            Id(x => x.Id).GeneratedBy.Identity();
            Map(x => x.Status);
            Map(x => x.CustomerId);
            Map(x => x.ProductId);
            Map(x => x.AddressId);
            Map(x => x.UnitPrice);
            Map(x => x.TotalPrice);
            Map(x => x.InsertDatetime);
        }
    }
}

