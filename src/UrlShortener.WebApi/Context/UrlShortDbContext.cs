using Microsoft.EntityFrameworkCore;
using UrlShortener.WebApi.Models;

namespace UrlShortener.WebApi.Context
{
    public class UrlShortDbContext : DbContext
    {
        private readonly string _connectionString;

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public UrlShortDbContext(string connectionString)
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        {
            _connectionString = connectionString;
        }

        public DbSet<UrlModel> ShortUrl { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySql(
                    _connectionString,
                    new MySqlServerVersion(new Version(8, 0, 11)));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UrlModel>().ToTable("url").HasKey(p => new { p.Id });
        }
    }
}
