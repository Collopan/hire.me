using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Shortener.Models;

namespace Shortener.Controllers
{
    public class HomeController : Controller
    {

        Class _context = new Class();
        
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(string _URL, string _CustomURL)
        {
            ViewBag.CustomURL = _CustomURL;
            ViewBag.URL =  _context.Adicionar(_URL);
            ViewBag.short_URL = ViewBag.URL;
            
            return View("Index");
        }
       

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
