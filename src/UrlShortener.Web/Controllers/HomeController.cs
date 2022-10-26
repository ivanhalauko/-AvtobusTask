using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using UrlShortener.Web.Models;
using UrlShortener.Web.Services;

namespace UrlShortener.Web.Controllers
{
    public class HomeController : Controller
    {
#pragma warning disable S1075 // URIs should not be hardcoded
        private const string BaseURI = "https://localhost:44322";
#pragma warning restore S1075 // URIs should not be hardcoded
        private readonly UrlShortenerService _urlShortenerService;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _urlShortenerService = new UrlShortenerService(new Uri(BaseURI));
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult MainPage()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
