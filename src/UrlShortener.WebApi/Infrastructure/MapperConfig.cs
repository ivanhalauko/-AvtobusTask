using AutoMapper;
using UrlShortener.WebApi.Interfaces;

namespace UrlShortener.WebApi.Infrastructure
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
