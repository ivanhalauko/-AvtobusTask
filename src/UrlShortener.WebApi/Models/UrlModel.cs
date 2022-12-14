using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using UrlShortener.WebApi.Interfaces;

namespace UrlShortener.WebApi.Models
{
    [Table("url")]
    public class UrlModel : IEntity
    {
        [Key]
        public long Id { get; set; }

        public string? Url { get; set; }

        public string? ShortUrl { get; set; }

        public DateTime CreationDate { get; set; }

        public int QuantityClick { get; set; }
    }
}
