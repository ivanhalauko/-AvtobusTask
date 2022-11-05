using Microsoft.EntityFrameworkCore;
using UrlShortener.WebApi.Context;
using UrlShortener.WebApi.Data;
using UrlShortener.WebApi.Infrastructure;
using UrlShortener.WebApi.Interfaces;
using UrlShortener.WebApi.Models;
using UrlShortener.WebApi.Repository;

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
            var dbConnectionstring = builder.Configuration.GetConnectionString("DbConnectionstring");
            builder.Services.AddControllers();
            builder.Services.AddSwaggerGen();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddScoped<IMapperConfig>(s => new MapperConfig(new MapperProfile()));
            builder.Services.AddScoped<UrlShortDbContext>(s => new UrlShortDbContext(dbConnectionstring));
            builder.Services.AddScoped<IEfGenericRepository<UrlModel>>(s => new EfGenericRepository<UrlModel>(dbConnectionstring));

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
            using (var scope = app.Services.CreateScope())
            {
                UrlShortDbContext context = scope.ServiceProvider.GetRequiredService<UrlShortDbContext>();
                context.Database.Migrate();
                DbUrlObjects.Initial(context);
            }

            app.Run();
        }
    }
}