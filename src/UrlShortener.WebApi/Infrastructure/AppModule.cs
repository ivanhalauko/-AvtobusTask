using Autofac;
using Microsoft.Extensions.DependencyInjection;
using UrlShortener.WebApi.Interfaces;

namespace UrlShortener.WebApi.Infrastructure
{
    public class AppModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<MapperConfig>().As<IMapperConfig>().WithParameter("profile", new MapperProfile());
            ////builder.RegisterType<EfGenericRepository<UrlModel>>().As<IEfGenericRepository<UrlModel>>().InstancePerLifetimeScope();
            ////builder.RegisterType<UrlShortDbContext>().As<UrlShortDbContext>().WithParameter("connectionString", _connectionString).InstancePerLifetimeScope();
        }
    }
}
