using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreWebAPI.Operations.Parameters
{
    public class RequestParameters
    {
        public class LoginRequest
        {
            public string email { get; set; }
            public string password { get; set; }
        }

        public class AddToCartRequest
        {
            public int productId { get; set; }
            public string email { get; set; }
        }
        public class CartDetailRequest
        {
            public int customerId { get; set; }
        }

        public class CreateOrderRequest
        {
            public int customerId { get; set; }

            public int addressId { get; set; }
        }
    }
}
