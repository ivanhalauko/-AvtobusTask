using System;
using RestSharp;

namespace UrlShortener.Web.RestClientWrapper
{
    public class UrlShortenerApiClient
    {
        public UrlShortenerApiClient(Uri baseUri)
        {
            BaseUri = baseUri;
            RestClientApi = new RestClient(BaseUri);
        }

        public Uri BaseUri { get; set; }

        public RestClient RestClientApi { get; set; }
    }
}
