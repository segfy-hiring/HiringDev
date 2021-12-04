using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YouTubeSearch.Core.Repositories.Base;
using YouTubeSearch.Infrastructure;

namespace YouTubeSearch.Infrastructure.Repositories.Base
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly DatabaseContext _context;
        public Repository(DatabaseContext videoContext)
        {
            _context = videoContext;
        }
        public T Add(T entity)
        {
            _context.Set<T>().Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public async Task<T> AddAsync(T entity)
        {
            _context.Set<T>().Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
        public async Task DeleteAsync(T entity)
        {
            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();
        }
        public async Task<IReadOnlyList<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }
        public async Task<T> GetByIdAsync(long id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public T Update(T entity)
        {
            _context.Set<T>().Update(entity);
            _context.SaveChanges();
            return entity;
        }
    }
}
