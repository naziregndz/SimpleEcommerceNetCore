using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
 public class Cart //Cart tablosu dışında CartDetail tablosu tutulabilir.
    {
        public virtual int Id { get; set; }   
        public virtual int Status { get; set; }
        public virtual int ProductId { get; set; }
        public virtual int CustomerId { get; set; }
        public virtual int Quantity { get; set; }
        public virtual decimal UnitPrice { get; set; }
        public virtual decimal TotalPrice { get; set; }
        public virtual string ProductName { get; set; } //productId ile Product tablosundan gelebilir.
    }
}
