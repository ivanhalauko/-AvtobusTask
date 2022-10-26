using System;
using System.ComponentModel.DataAnnotations;

namespace UrlShortener.Web.Models
{
    public class LinksInformationViewModel
    {
        public long Id { get; set; }

        [Display(Name = "Long URL")]
        public string Url { get; set; }

        [Display(Name = "Short URL")]
        public string ShortUrl { get; set; }

        [Display(Name = "Creation date")]
        public DateTime CreationDate { get; set; }

        [Display(Name = "Quantity clicks")]
        public int QuantityClick { get; set; }
    }
}
