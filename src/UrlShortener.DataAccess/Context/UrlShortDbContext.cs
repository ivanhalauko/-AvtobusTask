using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using UrlShortener.DataAccess.Models;

namespace UrlShortener.DataAccess.Context
{
    public class UrlShortDbContext : DbContext
    {
        private readonly string _connectionString;

        public UrlShortDbContext()
        {
        }

        public UrlShortDbContext(string connectionString)
        {
            _connectionString = connectionString;
        }

        public DbSet<UrlModel> ShortUrl { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySql(_connectionString);
            }
        }
    }
}
