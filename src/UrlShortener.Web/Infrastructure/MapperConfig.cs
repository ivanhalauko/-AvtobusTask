using AutoMapper;
using UrlShortener.Web.Interfaces;

namespace UrlShortener.Web.Infrastructure
{
    public class MapperConfig : IMapperConfig
    {
        public MapperConfig(Profile profile)
        {
            Mapper = new MapperConfiguration(m => m.AddProfile(profile)).CreateMapper();
        }

        public IMapper Mapper
        {
            get;
            private set;
        }
    }
}
