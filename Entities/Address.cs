using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public class Address
    {
        public virtual int Id { get; set; }
        public virtual string AddressTypeId { get; set; }
        public virtual string Country { get; set; }
        public virtual string City { get; set; } //City Tablosu yapıldıktan sonra TownId tutulabilir
        public virtual string Town { get; set; } //Town Tablosu yapıldıktan sonra TownId tutulabilir
        public virtual string ZipCode { get; set; }
        public virtual string AddressLine { get; set; }
        public virtual string AddressLine2 { get; set; }
        public virtual string AddressLine3 { get; set; }
    }
}
