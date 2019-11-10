using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Product
    {
        public virtual int Id { get; set; }
        public virtual string ProductTypeId { get; set; }
        public virtual string ProductName { get; set; }
        public virtual decimal Price { get; set; }
        public virtual int Stock { get; set; }
        public virtual string Description { get; set; }
    }
}
