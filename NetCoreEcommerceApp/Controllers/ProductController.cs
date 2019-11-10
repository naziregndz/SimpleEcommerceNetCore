using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace NetCoreEcommerceApp.Controllers
{
    public class ProductController : Controller
    {
        [HttpGet]
        public IActionResult GetProductList()
        {
            return View();
        }
    }
}