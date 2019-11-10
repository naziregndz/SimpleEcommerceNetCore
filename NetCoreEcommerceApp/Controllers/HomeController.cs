using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Entities;
using Microsoft.AspNetCore.Mvc;
using NetCoreEcommerceApp.Models;
using Newtonsoft.Json;

namespace NetCoreEcommerceApp.Controllers
{
    public class HomeController : Controller
    {
        public async Task<ActionResult> Index()
        {
            List<Product> productList = new List<Product>();
            //string apiUrl = ConfigurationManager.AppSettings["baseurl"] + "/api/Home/";
            string apiUrl = "http://localhost:5000/api/Home";
            var client = new HttpClient();
            HttpResponseMessage responseMessage = await client.GetAsync(apiUrl);
            if (responseMessage.IsSuccessStatusCode)
            {
                var responseData = responseMessage.Content.ReadAsStringAsync().Result;
                productList = JsonConvert.DeserializeObject<List<Product>>(responseData);
            }
            return View(productList);
        }
    }
}
