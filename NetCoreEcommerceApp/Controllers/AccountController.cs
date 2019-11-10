using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace NetCoreEcommerceApp.Controllers
{
    public class AccountController : Controller
    {
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Login(string email, string password)
        {
            string response = string.Empty;
          //string apiUrl = ConfigurationManager.AppSettings["baseurl"] + "/api/Account/Login";
            string apiUrl = "http://localhost:5000/api/Account/Login";
            var client = new HttpClient();
            Hashtable htParameter = new Hashtable();
            htParameter.Add("email", email);
            htParameter.Add("password", password);
            var content = new StringContent(JsonConvert.SerializeObject(htParameter), Encoding.UTF8, "application/json");

            HttpResponseMessage responseMessage = await client.PostAsync(apiUrl, content);
            if (responseMessage.IsSuccessStatusCode)
            {
                var responseData = responseMessage.Content.ReadAsStringAsync().Result;
                response = JsonConvert.DeserializeObject<string>(responseData);
            }
            if (response.Contains("true"))
                return RedirectToAction("Index", "Home");
            return View(); // email ya da şifre yanlış hatası verilecek.
        }
    }
}