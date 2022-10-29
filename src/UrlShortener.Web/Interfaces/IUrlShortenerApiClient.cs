using System.Collections.Generic;
using RestSharp;
using UrlShortener.Web.DtoModels;

namespace UrlShortener.Web.Interfaces
{
    public interface IUrlShortenerApiClient
    {
        public RestResponse<IEnumerable<LinkShorterDtoModel>> ResponseGetAll();

        public RestResponse<LinkShorterDtoModel> ResponseCreate(LinkShorterDtoModel linkEntity);

        public RestResponse<LinkShorterDtoModel> GetByShortUrl(string shortLink);

        public RestResponse ResponseDeleteById(int id);
    }
}
