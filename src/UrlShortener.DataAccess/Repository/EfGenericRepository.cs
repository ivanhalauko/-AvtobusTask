using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using UrlShortener.DataAccess.Context;
using UrlShortener.DataAccess.Interfaces;

namespace UrlShortener.DataAccess.Repository
{
    public class EfGenericRepository<T> : IEfGenericRepository<T>
        where T : class, IEntity
    {
        public EfGenericRepository(UrlShortDbContext urlShortDbContext)
        {
            UrlShortDbContext = urlShortDbContext;
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
            await UrlShortDbContext.SaveChangesAsync();
            var result = await UrlShortDbContext.FindAsync<T>(entity.Id);
            return result;
        }

        public async Task DeleteAsync(T entity)
        {
            UrlShortDbContext.Set<T>().Remove(entity);
            await UrlShortDbContext.SaveChangesAsync();
        }
    }
}
