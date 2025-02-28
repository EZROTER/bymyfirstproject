using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using EmailCleimSystem.Models;

namespace EmailCleimSystem.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            // Kullanıcının IP adresini alma
            string userIP = GetUserIP();
            
            // IP'yi bir değişkene atama (veritabanına kaydedebilir veya başka işlemler yapabilirsiniz)
            ViewBag.UserIP = userIP;
            
            return View();
        }
        
        private string GetUserIP()
        {
            // Proxy arkasında ise X-Forwarded-For header'ını kontrol et
            string ip = HttpContext.Request.Headers["X-Forwarded-For"].FirstOrDefault();
            
            // X-Forwarded-For yoksa doğrudan IP'yi al
            if (string.IsNullOrEmpty(ip))
            {
                ip = HttpContext.Connection.RemoteIpAddress?.ToString();
            }
            
            // Localhost ise
            if (ip == "::1")
            {
                ip = "127.0.0.1";
            }
            
            return ip;
        }
    }
}
