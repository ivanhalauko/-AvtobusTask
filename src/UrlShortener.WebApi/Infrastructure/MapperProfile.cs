using AutoMapper;
using UrlShortener.DataAccess.Models;
using UrlShortener.WebApi.DtoModels;

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
