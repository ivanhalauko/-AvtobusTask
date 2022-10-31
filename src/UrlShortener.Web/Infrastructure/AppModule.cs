using System;
using Autofac;
using UrlShortener.Web.Interfaces;
using UrlShortener.Web.Services;

namespace UrlShortener.Web.Infrastructure
{
    public class AppModule : Module
    {
        private readonly Uri _baseUri;

        public AppModule(Uri baseUri)
        {
            _baseUri = baseUri;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<MapperConfig>().As<IMapperConfig>().WithParameter("profile", new MapperProfile());
            builder.RegisterType<UrlShortenerService>().As<IUrlShortenerApiClient>().WithParameter("baseUri", _baseUri);
        }
    }
}
