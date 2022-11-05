using Microsoft.EntityFrameworkCore;
using UrlShortener.WebApi.Context;
using UrlShortener.WebApi.Models;

namespace UrlShortener.WebApi.Data
{
    public class DbUrlObjects
    {
        private static Dictionary<string, UrlModel>? _urls;

        protected DbUrlObjects()
        {
        }

        public static Dictionary<string, UrlModel> Urls
        {
            get
            {
                if (_urls == null)
                {
                    var list = new UrlModel[]
                    {
                        new UrlModel
                        {
                            Url = "http://htmlbook.ru/content/svoystva-teksta",
                            ShortUrl = "https://localhost:44308/ajsdmcam8c",
                            CreationDate = new DateTime(2022, 10, 30, 20, 35, 03),
                            QuantityClick = 1,
                        },
                        new UrlModel
                        {
                            Url = "https://www.pragimtech.com/blog/blazor/asp.net-core-rest-api-dbcontext/",
                            ShortUrl = "https://localhost:44308/pwpt42amhs",
                            CreationDate = new DateTime(2022, 10, 30, 20, 48, 17),
                            QuantityClick = 2,
                        },
                    };

                    _urls = new Dictionary<string, UrlModel>();
                    foreach (var item in list)
                    {
                        if (item.Url is not null)
                        {
                            _urls.Add(item.Url, item);
                        }
                    }
                }

                return _urls;
            }
        }

        public static void Initial(UrlShortDbContext context)
        {
            if (!context.ShortUrl.Any())
            {
                context.ShortUrl.AddRange(Urls.Select(x => x.Value));
            }

            context.SaveChanges();
        }
    }
}
