using Entities;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mappings
{
    public class CartMap : ClassMap<Cart>
    {
        public CartMap()
        {
            Table("Cart");
            Id(x => x.Id).GeneratedBy.Identity();
            Map(x => x.ProductId);
            Map(x => x.Status);
            Map(x => x.CustomerId);
            Map(x => x.Quantity);
            Map(x => x.UnitPrice);
            Map(x => x.TotalPrice);
            Map(x => x.ProductName);
        }
    }
}
