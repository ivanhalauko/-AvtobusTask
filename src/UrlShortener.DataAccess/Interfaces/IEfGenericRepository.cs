using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UrlShortener.DataAccess.Context;

namespace UrlShortener.DataAccess.Interfaces
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
