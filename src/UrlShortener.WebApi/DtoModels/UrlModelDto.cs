namespace UrlShortener.WebApi.DtoModels
{
    public class UrlModelDto
    {
        public long Id { get; set; }

        public string? Url { get; set; }

        public string? ShortUrl { get; set; }

        public DateTime CreationDate { get; set; }

        public int QuantityClick { get; set; }
    }
}
