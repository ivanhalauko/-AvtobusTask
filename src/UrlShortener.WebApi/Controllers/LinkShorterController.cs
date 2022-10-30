using Microsoft.AspNetCore.Mvc;
using UrlShortener.WebApi.DtoModels;
using UrlShortener.WebApi.Interfaces;
using UrlShortener.WebApi.Models;

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

        [HttpGet("GetAll")]
        public ActionResult<IEnumerable<UrlModelDto>> GetAll()
        {
            var links = _efGenericRepository.GetAllAsync().Result;
            var urlDtoList = _mapperConfig.Mapper.Map<IEnumerable<UrlModel>, IEnumerable<UrlModelDto>>(links);
            return urlDtoList is null ? NoContent() : Ok(urlDtoList.ToList());
        }

        [HttpPost("Create")]
        public ActionResult<string> Create([FromBody] UrlModelDto urlApi)
        {
            var url = _mapperConfig.Mapper.Map<UrlModelDto, UrlModel>(urlApi);
            var newUrlsId = _efGenericRepository.AddAsync(url).Result;
            var newUrl = _efGenericRepository.GetByIdAsync(newUrlsId).Result;
            return newUrl is null ? NoContent() : Ok(newUrl);
        }

        [HttpGet("GetByShortUrl")]
        public ActionResult<UrlModel> GetByShortUrlWithParams(string shortLink)
        {
            var link = _efGenericRepository.GetAllAsync().Result;
            var urlModel = link.FirstOrDefault(x => x.ShortUrl == shortLink);
            return urlModel is null ? NoContent() : Ok(urlModel);
        }

        [HttpDelete("DeleteById/{id}")]
        public ActionResult DeleteById(int id)
        {
            var existingUrl = _efGenericRepository.GetByIdAsync(id).Result.FirstOrDefault();
            if (existingUrl is null)
            {
                return NoContent();
            }

            _efGenericRepository.DeleteAsync(existingUrl);
            return Ok();
        }

        [HttpPut("Update")]
        public ActionResult<string> Update([FromBody] UrlModelDto urlApi)
        {
            var url = _mapperConfig.Mapper.Map<UrlModelDto, UrlModel>(urlApi);
            var newUrl = _efGenericRepository.UpdateAsync(url).Result;
            return newUrl is null ? NoContent() : Ok(newUrl);
        }
    }
}
