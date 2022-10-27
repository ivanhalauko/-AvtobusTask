using AutoMapper;
using UrlShortener.WebApi.DtoModels;
using UrlShortener.WebApi.Models;

namespace UrlShortener.WebApi.Infrastructure
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            // API to DAL
            CreateMap<UrlModelDto, UrlModel>();

            // DAL to API
            CreateMap<UrlModel, UrlModelDto>();
        }
    }
}
