using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using UrlShortener.Web.DtoModels;
using UrlShortener.Web.Infrastructure;
using UrlShortener.Web.Interfaces;
using UrlShortener.Web.Models;
using UrlShortener.Web.Services;

namespace UrlShortener.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUrlShortenerApiClient _urlShortenerService;
        private readonly ILogger<HomeController> _logger;
        private readonly IMapperConfig _mapperConfig;

        public HomeController(
            ILogger<HomeController> logger,
            IMapperConfig mapperConfig,
            IUrlShortenerApiClient urlShortenerService)
        {
            _urlShortenerService = urlShortenerService;
            _logger = logger;
            _mapperConfig = mapperConfig;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult MainPage()
        {
            try
            {
                var linkShortenerDtoList = _urlShortenerService.ResponseGetAll().Data.ToList();
                var entityViewModel = _mapperConfig.Mapper.Map<IEnumerable<LinkShorterDtoModel>, IEnumerable<LinksInformationViewModel>>(linkShortenerDtoList);
                return View(entityViewModel);
            }
            catch (Exception)
            {
                return RedirectToAction(nameof(HomeController.Index),
                                        nameof(HomeController).Replace("Controller", ""));
            }
        }

        public IActionResult CreateShortUrl() => View();

        [HttpPost]
        public IActionResult CreateShortUrl(LinksInformationViewModel linkFromView)
        {
            try
            {
                var linkShortUrlDto = new LinkShorterDtoModel
                {
                    Url = "sdsds",
                    ShortUrl = "dfdd",
                    CreationDate = new DateTime(2025, 10, 8, 0, 0, 0),
                    QuantityClick = 1,
                };

                _urlShortenerService.ResponseCreate(linkShortUrlDto);
                return RedirectToAction(nameof(HomeController.MainPage),
                                        nameof(HomeController).Replace("Controller", ""));
            }
            catch (Exception)
            {
                return RedirectToAction(nameof(HomeController.Index),
                                        nameof(HomeController).Replace("Controller", ""));
            }
        }

        [HttpGet]
        public IActionResult DeleteUrl(string shortUrl)
        {
            var linkShortenerDto = _urlShortenerService.ResponseGetByShortUrl(shortUrl).Data;
            var entityViewModel = _mapperConfig.Mapper.Map<LinkShorterDtoModel, LinksInformationViewModel>(linkShortenerDto);
            return View(entityViewModel);
        }

        [HttpPost]
        public IActionResult DeleteUrl(int id)
        {
            try
            {
                _urlShortenerService.ResponseDeleteById(id);
                return RedirectToAction(nameof(HomeController.MainPage),
                                        nameof(HomeController).Replace("Controller", ""));
            }
            catch (Exception)
            {
                return RedirectToAction(nameof(HomeController.Index),
                                        nameof(HomeController).Replace("Controller", ""));
            }
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
