using AutoMapper;

namespace UrlShortener.Web.Interfaces
{
    public interface IMapperConfig
    {
        IMapper Mapper { get; }
    }
}
