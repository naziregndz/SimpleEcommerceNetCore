using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Entities;
using Microsoft.AspNetCore.Mvc;
using NetCoreEcommerceApp.Models;
using Newtonsoft.Json;

namespace NetCoreEcommerceApp.Controllers
{
    public class OrderController : Controller
    {
        public async Task<ActionResult> Index()//parametre olarak customerId alacak.
        {
            List<Cart> response = new List<Cart>();
            //string apiUrl = ConfigurationManager.AppSettings["baseurl"] + "/api/Order/GetCartDetail";
            string apiUrl = "http://localhost:5000/api/Order/GetCartDetail";
            var client = new HttpClient();
            Hashtable htParameter = new Hashtable();
            htParameter.Add("customerId", 1); //test için 1 olarak gönderildi. session bazlı customerId gelecek şekilde olacak.
            var content = new StringContent(JsonConvert.SerializeObject(htParameter), Encoding.UTF8, "application/json");

            HttpResponseMessage responseMessage = await client.PostAsync(apiUrl, content);
            if (responseMessage.IsSuccessStatusCode)
            {
                var responseData = responseMessage.Content.ReadAsStringAsync().Result;
                response = JsonConvert.DeserializeObject<List<Cart>>(responseData);
            }
            return View(response);
        }

        public async Task<ActionResult> AddToCart(int productId,string email)
        {
            List<Cart> response = new List<Cart>();
            //string apiUrl = ConfigurationManager.AppSettings["baseurl"] + "/api/Order/AddToCart";
            string apiUrl = "http://localhost:5000/api/Order/AddToCart";
            var client = new HttpClient();
            Hashtable htParameter = new Hashtable();
            htParameter.Add("productId", productId);
            htParameter.Add("email", email);
            var content = new StringContent(JsonConvert.SerializeObject(htParameter), Encoding.UTF8, "application/json");

            HttpResponseMessage responseMessage = await client.PostAsync(apiUrl, content);
            if (responseMessage.IsSuccessStatusCode)
            {
                var responseData = responseMessage.Content.ReadAsStringAsync().Result;
                response = JsonConvert.DeserializeObject<List<Cart>>(responseData);
            }
            return View(response);
        }
    }
}
