using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YouTubeSearch.Core.Repositories.Base
{
    public interface IRepository<T> where T : class
    {
        Task<IReadOnlyList<T>> GetAllAsync();
        Task<T> GetByIdAsync(long id);
        T Add(T entity);
        Task<T> AddAsync(T entity);
        T Update(T entity);
        Task DeleteAsync(T entity);
    }
}
