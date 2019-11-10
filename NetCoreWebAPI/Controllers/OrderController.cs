using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NetCoreWebAPI.Operations;
using static NetCoreWebAPI.Operations.Parameters.RequestParameters;

namespace NetCoreWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        [HttpPost("GetCartDetail")]
        public ActionResult<string> GetCartDetail(CartDetailRequest request)
        {
            return Ok(OrderOperations.GetCartDetail(request.customerId));
        }

        [HttpPost("AddToCart")]
        public ActionResult<string> AddToCart(AddToCartRequest request)
        {
            return Ok(OrderOperations.AddToCart(request.productId,request.email));
        }

        [HttpPost("CreateOrder")]
        public ActionResult<string> CreateOrder(CreateOrderRequest request)
        {
            return Ok(OrderOperations.CreateOrder(request.customerId, request.addressId));
        }
    }
}
