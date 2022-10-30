using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using UrlShortener.Web.DtoModels;
using UrlShortener.Web.Interfaces;
using UrlShortener.Web.Models;
using UrlShortener.Web.Utils;

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
                return RedirectToAction(nameof(HomeController.Error),
                                        nameof(HomeController).Replace("Controller", ""));
            }
        }

        public IActionResult CreateShortUrl() => View();

        [HttpPost]
        public IActionResult CreateShortUrl(string creationDate, LinksInformationViewModel linkFromView, string shortUrl = null)
        {
            try
            {
                if (linkFromView.Url != null && shortUrl == null)
                {
                    linkFromView.ShortUrl = GenerateShortUrl();
                    linkFromView.QuantityClick = 0;
                    linkFromView.CreationDate = DateTime.Now;
                    return View(linkFromView);
                }

                var linkShortUrlDto = _mapperConfig.Mapper.Map<LinksInformationViewModel, LinkShorterDtoModel>(linkFromView);
                linkShortUrlDto.CreationDate = DateTime.Parse(creationDate);
                _urlShortenerService.ResponseCreate(linkShortUrlDto);
                return RedirectToAction(nameof(HomeController.MainPage),
                                        nameof(HomeController).Replace("Controller", ""));
            }
            catch (Exception)
            {
                return RedirectToAction(nameof(HomeController.Error),
                                        nameof(HomeController).Replace("Controller", ""));
            }
        }

        private string GenerateShortUrl()
        {
            var key = KeyGenerator.Generate(10);
            var shortUrl = new Uri($"{Request.Scheme}://{Request.Host.Value}{Request.PathBase}/{key}").ToString();
            var fromDb = _urlShortenerService.GetByShortUrl(shortUrl);
            while (fromDb.StatusCode == System.Net.HttpStatusCode.OK)
            {
                key = KeyGenerator.Generate(10);
                shortUrl = new Uri($"{Request.Scheme}://{Request.Host.Value}{Request.PathBase}/{key}").ToString();
                fromDb = _urlShortenerService.GetByShortUrl(shortUrl);
            }

            var result = shortUrl;
            return result;
        }

        [HttpGet]
        public IActionResult RedirectTo(string shortUrl)
        {
            var linkShortenerDto = _urlShortenerService.GetByShortUrl(shortUrl).Data;
            linkShortenerDto.QuantityClick++;
            _urlShortenerService.ResponseUpdate(linkShortenerDto);
            return Redirect(linkShortenerDto.Url.ToString());
        }

        public IActionResult UpdateUrl(string shortUrl)
        {
            var linkShortener = _urlShortenerService.GetByShortUrl(shortUrl).Data;
            var entityViewModel = _mapperConfig.Mapper.Map<LinkShorterDtoModel, LinksInformationViewModel>(linkShortener);
            return View(entityViewModel);
        }

        [HttpPost]
        public IActionResult UpdateUrl(string creationDate, LinksInformationViewModel linkFromView, string shortUrl = null)
        {
            try
            {
                if (linkFromView.Url != null && shortUrl == null)
                {
                    linkFromView.ShortUrl = GenerateShortUrl();
                    linkFromView.QuantityClick = 0;
                    linkFromView.CreationDate = DateTime.Now;
                    return View(linkFromView);
                }

                var linkShortUrlDto = _mapperConfig.Mapper.Map<LinksInformationViewModel, LinkShorterDtoModel>(linkFromView);
                linkShortUrlDto.CreationDate = DateTime.Parse(creationDate);
                _urlShortenerService.ResponseUpdate(linkShortUrlDto);
                return RedirectToAction(nameof(HomeController.MainPage),
                                        nameof(HomeController).Replace("Controller", ""));
            }
            catch (Exception)
            {
                return RedirectToAction(nameof(HomeController.Error),
                                        nameof(HomeController).Replace("Controller", ""));
            }
        }

        [HttpGet]
        public IActionResult DeleteUrl(string shortUrl)
        {
            var linkShortenerDto = _urlShortenerService.GetByShortUrl(shortUrl).Data;
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
                return RedirectToAction(nameof(HomeController.Error),
                                        nameof(HomeController).Replace("Controller", ""));
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
