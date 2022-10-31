using AutoMapper;

namespace UrlShortener.WebApi.Interfaces
{
    public interface IMapperConfig
    {
        IMapper Mapper { get; }
    }
}
