using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
  public class Order //Order tablosu dışında OrderDetail tablosu tutulabilir.
    {
        public virtual int Id { get; set; }
        public virtual int Status { get; set; }
        public virtual int CustomerId { get; set; }
        public virtual int ProductId { get; set; }
        public virtual int AddressId { get; set; }
        public virtual decimal UnitPrice { get; set; }
        public virtual decimal TotalPrice { get; set; }
        public virtual DateTime InsertDatetime { get; set; }
    }
}
