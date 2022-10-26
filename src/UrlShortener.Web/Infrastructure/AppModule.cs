using Autofac;
using UrlShortener.Web.Interfaces;

namespace UrlShortener.Web.Infrastructure
{
    public class AppModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<MapperConfig>().As<IMapperConfig>().WithParameter("profile", new MapperProfile());
        }
    }
}
