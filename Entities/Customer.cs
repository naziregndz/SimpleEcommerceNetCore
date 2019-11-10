using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public class Customer
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual string Surname { get; set; }
        public virtual string Email { get; set; }
        public virtual string Password { get; set; }
        public virtual string Phone { get; set; }
        //Müşteriye ait diğer bilgilerde tutulabilir.

        //Email ve Phone bu tabloda tutulmazsa CustomerCommunication ve CommunicationType olarak 2 tablo ayrı tablo daha yapılabilir.
        //CommunicationType tablosunda iletişim tipleri, CustomerCommunication tablosunda ise müşterinin telefon ve email gibi bilgileri tutulabilir.
    }
}