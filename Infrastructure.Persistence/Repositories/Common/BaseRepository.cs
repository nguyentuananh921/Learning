using Core.Application.Interfaces.Infrastructure.Persistence.Repository.Common;
using Infrastructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Repositories.Common
{
    public class BaseRepository<T> : IAsyncRepository<T> where T : class
    {
        private readonly ApplicationDbContext _context;
        public BaseRepository(ApplicationDbContext dbContext)
        {
            _context = dbContext;
        }
        public IQueryable<T> Entities => _context.Set<T>();
        public async Task<T> AddAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            return entity;
        }

        public Task DeleteAsync(T entity)
        {
            _context.Set<T>().Remove(entity);
            return Task.CompletedTask;
        }

        public async Task<T> GetByIdAsync(Guid id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task<IReadOnlyList<T>> GetAllAsync()
        {
            return await _context
                .Set<T>()
                .ToListAsync();
        }
        public Task UpdateAsync(T entity)
        {
            throw new NotImplementedException();
        }

        //public IEnumerable<T> GetAll(string? includeProperties = null)
        //{
        //    IQueryable<T> query = dbSet;
        //    if (!string.IsNullOrEmpty(includeProperties))
        //    {
        //        foreach (var includeProp in includeProperties
        //            .Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
        //        {
        //            query = query.Include(includeProp);
        //        }
        //    }
        //    return query.ToList();
        //}
    }
}
