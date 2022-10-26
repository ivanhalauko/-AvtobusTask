using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using RestSharp;
using UrlShortener.Web.DtoModels;
using UrlShortener.Web.RestClientWrapper;

namespace UrlShortener.Web.Services
{
    public class UrlShortenerService : UrlShortenerApiClient
    {
        public UrlShortenerService(Uri baseUri)
            : base(baseUri)
        {
        }

        ////public RestResponse<LinkShorterDtoModel> ResponseCreate(LinkShorterDtoModel linkEntity)
        ////{
        ////    var endPoint = $"/api/LinkShorter";
        ////    RestRequest restRequest = new RestRequest(endPoint, Method.Post);
        ////    restRequest.AddHeader("Content-Type", "application/json");
        ////    var jsonLink = JsonConvert.SerializeObject(linkEntity);
        ////    restRequest.AddBody(jsonLink, "application/json");
        ////    var responseCreate = RestClientApi.ExecutePostAsync<LinkShorterDtoModel>(restRequest).Result;
        ////    return responseCreate;
        ////}

        public RestResponse<IEnumerable<LinkShorterDtoModel>> ResponseGetAll()
        {
            var endPoint = $"/api/LinkShorter";
            RestRequest restRequest = new RestRequest(endPoint, Method.Get);
            var responseGetAll = RestClientApi.ExecuteGetAsync<IEnumerable<LinkShorterDtoModel>>(restRequest).Result;
            return responseGetAll;
        }

        ////public RestResponse<IEnumerable<LinkShorterDtoModel>> ResponseGetByShort(string shortLink)
        ////{
        ////    var endPoint = $"/api/LinkShorter/{shortLink}";
        ////    RestRequest restRequest = new RestRequest(endPoint, Method.Get);
        ////    var responseGetAll = RestClientApi.ExecuteGetAsync<IEnumerable<LinkShorterDtoModel>>(restRequest).Result;
        ////    return responseGetAll;
        ////}

        ////public RestResponse<LinkShorterDtoModel> ResponseUpdate(string shortLink, LinkShorterDtoModel linkEntity)
        ////{
        ////    var endPoint = $"/api/LinkShorter/{shortLink}";
        ////    RestRequest restRequest = new RestRequest(endPoint, Method.Put);
        ////    restRequest.AddBody(linkEntity);
        ////    var responseUpdate = RestClientApi.ExecuteGetAsync<LinkShorterDtoModel>(restRequest).Result;
        ////    return responseUpdate;
        ////}

        ////public RestResponse<LinkShorterDtoModel> ResponseDelete(string shortLink)
        ////{
        ////    var endPoint = $"/api/LinkShorter/{shortLink}";
        ////    RestRequest restRequest = new RestRequest(endPoint, Method.Delete);
        ////    var responseDelete = RestClientApi.ExecuteGetAsync<LinkShorterDtoModel>(restRequest).Result;
        ////    return responseDelete;
        ////}
    }
}
