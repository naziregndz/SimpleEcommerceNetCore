using Entities;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mappings
{
    public class ProductMap : ClassMap<Product>
    {
        public ProductMap()
        {
            Table("Product");
            Id(x => x.Id).GeneratedBy.Identity();
            Map(x => x.ProductTypeId);
            Map(x => x.ProductName);
            Map(x => x.Price);
            Map(x => x.Stock);
            Map(x => x.Description);
        }
    }
}
