using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using UrlShortener.WebApi.Context;
using UrlShortener.WebApi.Interfaces;

namespace UrlShortener.WebApi.Repository
{
    public class EfGenericRepository<T> : IEfGenericRepository<T>
        where T : class, IEntity
    {
        public EfGenericRepository(string connectionString)
        {
            UrlShortDbContext = new UrlShortDbContext(connectionString);
        }

        public UrlShortDbContext UrlShortDbContext { get; set; }

        public async Task<IQueryable<T>> GetAllAsync()
        {
            var entities = UrlShortDbContext.Set<T>().AsNoTracking();
            await UrlShortDbContext.SaveChangesAsync();
            return entities;
        }

        public async Task<IQueryable<T>> GetByIdAsync(int id)
        {
            var entities = UrlShortDbContext.Set<T>().Where(x => x.Id == id).AsNoTracking();
            await UrlShortDbContext.SaveChangesAsync();
            return entities;
        }

        public async Task<int> AddAsync(T entity)
        {
            var entit = UrlShortDbContext.Set<T>().AddAsync(entity).Result;
            await UrlShortDbContext.SaveChangesAsync();
            return (int)entit.Entity.Id;
        }

        public async Task<T> UpdateAsync(T entity)
        {
            UrlShortDbContext.Set<T>().Update(entity);
            var result = await UrlShortDbContext.FindAsync<T>(entity.Id);
            await UrlShortDbContext.SaveChangesAsync();
#pragma warning disable CS8603 // Possible null reference return.
            return result;
#pragma warning restore CS8603 // Possible null reference return.
        }

        public async Task DeleteAsync(T entity)
        {
            UrlShortDbContext.Set<T>().Remove(entity);
            await UrlShortDbContext.SaveChangesAsync();
        }
    }
}
