using AutoMapper;
using UrlShortener.Web.DtoModels;
using UrlShortener.Web.Models;

namespace UrlShortener.Web.Infrastructure
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            // DtoModel to ViewModel
            CreateMap<LinkShorterDtoModel, LinksInformationViewModel>();

            // ViewModel to DtoModel
            CreateMap<LinksInformationViewModel, LinkShorterDtoModel>();
        }
    }
}
