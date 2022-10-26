using Autofac;
using UrlShortener.WebApi.Interfaces;

namespace UrlShortener.WebApi.Infrastructure
{
    public class AppModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<MapperConfig>().As<IMapperConfig>().WithParameter("profile", new MapperProfile());
        }
    }
}
