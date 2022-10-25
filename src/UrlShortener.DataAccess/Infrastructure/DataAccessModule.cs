using System;
using System.Collections.Generic;
using System.Text;
using Autofac;
using UrlShortener.DataAccess.Context;
using UrlShortener.DataAccess.Interfaces;
using UrlShortener.DataAccess.Models;
using UrlShortener.DataAccess.Repository;

namespace UrlShortener.DataAccess.Infrastructure
{
    public class DataAccessModule : Module
    {
        private readonly string _connectionString;

        public DataAccessModule(string connectionString)
        {
            _connectionString = connectionString;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<EfGenericRepository<UrlModel>>().As<IEfGenericRepository<UrlModel>>().InstancePerLifetimeScope();

            builder.RegisterType<UrlShortDbContext>().As<UrlShortDbContext>().WithParameter("connectionString", _connectionString).InstancePerLifetimeScope();
        }
    }
}
