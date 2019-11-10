using Entities;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mappings
{
    public class ProductTypeMap : ClassMap<ProductType>
    {
        public ProductTypeMap()
        {
            Table("ProductType");
            Id(x => x.Id).GeneratedBy.Identity();
            Map(x => x.Desciption);
        }
    }
}

