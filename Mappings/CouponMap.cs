using Entities;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mappings
{
 public class CouponMap : ClassMap<Coupon>
    {
        public CouponMap()
        {
            Table("Coupon");
            Id(x => x.Id).GeneratedBy.Identity();
            Map(x => x.Status);
            Map(x => x.CustomerId);
            Map(x => x.Discount);
        }
    }
}
