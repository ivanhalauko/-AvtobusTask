using System.Collections.Generic;
using RestSharp;
using UrlShortener.Web.DtoModels;

namespace UrlShortener.Web.Interfaces
{
    public interface IUrlShortenerApiClient
    {
        public RestResponse<IEnumerable<LinkShorterDtoModel>> ResponseGetAll();
    }
}
