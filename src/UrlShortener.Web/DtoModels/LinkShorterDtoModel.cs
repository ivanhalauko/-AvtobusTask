using System;

namespace UrlShortener.Web.DtoModels
{
    public class LinkShorterDtoModel
    {
        public long Id { get; set; }

        public string Url { get; set; }

        public string ShortUrl { get; set; }

        public DateTime CreationDate { get; set; }

        public int QuantityClick { get; set; }
    }
}
