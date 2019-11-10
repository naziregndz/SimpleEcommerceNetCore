using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
   public class Coupon
    {
        public virtual int Id { get; set; }
        public virtual int Status { get; set; }
        public virtual int CustomerId { get; set; }
        public virtual int Discount { get; set; }
        //public virtual int CouponTypeId { get; set; } //coupontypeid oluşturularak farklı kuponlar tanımlanabilir.
    }
}
