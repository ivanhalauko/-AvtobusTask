using UrlShortener.WebApi.Context;

namespace UrlShortener.WebApi.Interfaces
{
    public interface IEfGenericRepository<T>
        where T : class, IEntity
    {
        UrlShortDbContext UrlShortDbContext { get; set; }

        Task<int> AddAsync(T entity);

        Task DeleteAsync(T entity);

        Task<IQueryable<T>> GetAllAsync();

        Task<IQueryable<T>> GetByIdAsync(int id);

        Task<T> UpdateAsync(T entity);
    }
}
