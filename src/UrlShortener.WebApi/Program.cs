////using Autofac;
////using Autofac.Extensions.DependencyInjection;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using UrlShortener.DataAccess.Context;
using UrlShortener.DataAccess.Infrastructure;
using UrlShortener.DataAccess.Interfaces;
using UrlShortener.DataAccess.Models;
using UrlShortener.DataAccess.Repository;
using UrlShortener.WebApi.Infrastructure;
using UrlShortener.WebApi.Interfaces;

namespace UrlShortener.WebApi
{
    public class Program
    {
        protected Program()
        {
        }

        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            ////var dbConnectionstring = builder.Configuration.GetConnectionString("DbConnectionstring");
            ////builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
            ////builder.Host.ConfigureContainer<ContainerBuilder>(builder =>
            ////{
            ////    // Add your Autofac DI registrations here
            ////    ////builder.RegisterModule(new DataAccessModule(dbConnectionstring));
            ////    builder.RegisterModule(new DataAccessModule());
            ////    builder.RegisterModule(new AppModule());
            ////});

            builder.Services.AddControllers();
            builder.Services.AddSwaggerGen();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddScoped<IMapperConfig>(s => new MapperConfig(new MapperProfile()));
            ////builder.Services.AddScoped<UrlShortDbContext>(s => new UrlShortDbContext(dbConnectionstring));
            ////builder.Services.AddScoped<IEfGenericRepository<UrlModel>>(s => new EfGenericRepository<UrlModel>(dbConnectionstring));

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "UrlShortener.RestAPI v1"));
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}