using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using RestSharp;
using UrlShortener.Web.DtoModels;
using UrlShortener.Web.Interfaces;
using UrlShortener.Web.RestClientWrapper;

namespace UrlShortener.Web.Services
{
    public class UrlShortenerService : UrlShortenerApiClient, IUrlShortenerApiClient
    {
        public UrlShortenerService(Uri baseUri)
            : base(baseUri)
        {
        }

        public RestResponse<LinkShorterDtoModel> ResponseCreate(LinkShorterDtoModel linkEntity)
        {
            var endPoint = $"/api/LinkShorter/Create";
            RestRequest restRequest = new RestRequest(endPoint, Method.Post);
            restRequest.AddHeader("Content-Type", "application/json");
            var jsonLink = JsonConvert.SerializeObject(linkEntity);
            restRequest.AddBody(jsonLink, "application/json");
            var responseCreate = RestClientApi.ExecutePostAsync<LinkShorterDtoModel>(restRequest).Result;
            return responseCreate;
        }

        public RestResponse<IEnumerable<LinkShorterDtoModel>> ResponseGetAll()
        {
            var endPoint = $"/api/LinkShorter/GetAll";
            RestRequest restRequest = new RestRequest(endPoint, Method.Get);
            var responseGetAll = RestClientApi.ExecuteGetAsync<IEnumerable<LinkShorterDtoModel>>(restRequest).Result;
            return responseGetAll;
        }

        public RestResponse<LinkShorterDtoModel> ResponseGetByShortUrl(string shortLink)
        {
            var endPoint = $"/api/LinkShorter/GetByShortUrl/{shortLink}";
            RestRequest restRequest = new RestRequest(endPoint, Method.Get);
            var responseGetAll = RestClientApi.ExecuteGetAsync<LinkShorterDtoModel>(restRequest).Result;
            return responseGetAll;
        }

        ////public RestResponse<LinkShorterDtoModel> ResponseUpdate(string shortLink, LinkShorterDtoModel linkEntity)
        ////{
        ////    var endPoint = $"/api/LinkShorter/{shortLink}";
        ////    RestRequest restRequest = new RestRequest(endPoint, Method.Put);
        ////    restRequest.AddBody(linkEntity);
        ////    var responseUpdate = RestClientApi.ExecuteGetAsync<LinkShorterDtoModel>(restRequest).Result;
        ////    return responseUpdate;
        ////}

        public RestResponse ResponseDeleteById(int id)
        {
            var endPoint = $"/api/LinkShorter/DeleteById/{id}";
            ////var endPoint = $"/api/LinkShorter/DeleteById";

            RestRequest restRequest = new RestRequest(endPoint, Method.Delete);
            restRequest.AddHeader("accept", "*/*");
            ////restRequest.AddUrlSegment("id", id.ToString());
            ////restRequest.AddParameter("text/plain", null, ParameterType.RequestBody);
            ////restRequest.AddHeader("Content-Type", "application/json");
            var responseDelete = RestClientApi.Execute(restRequest);
            return responseDelete;
        }
    }
}
