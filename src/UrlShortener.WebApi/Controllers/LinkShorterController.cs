﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UrlShortener.WebApi.DtoModels;
using UrlShortener.WebApi.Interfaces;
using UrlShortener.WebApi.Models;
using UrlShortener.WebApi.Repository;

namespace UrlShortener.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LinkShorterController : Controller
    {
        private readonly IMapperConfig _mapperConfig;
        private readonly IEfGenericRepository<UrlModel> _efGenericRepository;

        public LinkShorterController(
            IMapperConfig mapperConfig,
            IEfGenericRepository<UrlModel> repository)
        {
            _mapperConfig = mapperConfig;
            _efGenericRepository = repository;
        }

        ////public LinkShorterController(
        ////    IMapperConfig mapperConfig)
        ////{
        ////    _mapperConfig = mapperConfig;
        ////    _efGenericRepository = new EfGenericRepository<UrlModel>("user id=root;password=Mar_123;host=127.0.0.1;database=urlshortenerdatabase;");
        ////}

        // GET: LinkShorterController
        [HttpGet("GetAll")]
        public ActionResult<IEnumerable<UrlModelDto>> GetAll()
        {
            var links = _efGenericRepository.GetAllAsync().Result;
            var urlDtoList = _mapperConfig.Mapper.Map<IEnumerable<UrlModel>, IEnumerable<UrlModelDto>>(links);
            return urlDtoList is null ? NoContent() : Ok(urlDtoList.ToList());
        }

        ////// GET: LinkShorterController/Details/5
        ////public ActionResult Details(int id)
        ////{
        ////    return View();
        ////}

        ////// GET: LinkShorterController/Create
        ////public ActionResult Create()
        ////{
        ////    return View();
        ////}

        ////// POST: LinkShorterController/Create
        ////[HttpPost]
        ////[ValidateAntiForgeryToken]
        ////public ActionResult Create(IFormCollection collection)
        ////{
        ////    try
        ////    {
        ////        return RedirectToAction(nameof(Index));
        ////    }
        ////    catch
        ////    {
        ////        return View();
        ////    }
        ////}

        ////// GET: LinkShorterController/Edit/5
        ////public ActionResult Edit(int id)
        ////{
        ////    return View();
        ////}

        ////// POST: LinkShorterController/Edit/5
        ////[HttpPost]
        ////[ValidateAntiForgeryToken]
        ////public ActionResult Edit(int id, IFormCollection collection)
        ////{
        ////    try
        ////    {
        ////        return RedirectToAction(nameof(Index));
        ////    }
        ////    catch
        ////    {
        ////        return View();
        ////    }
        ////}

        ////// GET: LinkShorterController/Delete/5
        ////public ActionResult Delete(int id)
        ////{
        ////    return View();
        ////}

        ////// POST: LinkShorterController/Delete/5
        ////[HttpPost]
        ////[ValidateAntiForgeryToken]
        ////public ActionResult Delete(int id, IFormCollection collection)
        ////{
        ////    try
        ////    {
        ////        return RedirectToAction(nameof(Index));
        ////    }
        ////    catch
        ////    {
        ////        return View();
        ////    }
        ////}
    }
}
