using Core.Application.Interfaces.Infrastructure.Persistence.Repository.Common;
using Core.Application.Interfaces.Infrastructure.Persistence.Repository;
using Infrastructure.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Application.Interfaces.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Core.Domain.Entities;

namespace Infrastructure.Persistence.Repositories.Common
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        public IDeveloperRepository DeveloperRepository;
        public IProjectRepository ProjectRepository;
        
        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            DeveloperRepository = new DeveloperRepository(_context);
            ProjectRepository = new ProjectRepository(_context);
            
        }

        public IDeveloperRepository Developers { get; private set; }

        public IProjectRepository Projects { get; private set; }

        public int Complete()
        {
            return _context.SaveChanges();
        }
        public void Dispose()
        {
            _context.Dispose();
        }

        public Task Rollback()
        {
            throw new NotImplementedException();
        }

        public Task<int> Save(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<int> SaveAndRemoveCache(CancellationToken cancellationToken, params string[] cacheKeys)
        {
            throw new NotImplementedException();
        }

        public Task<int> SaveChangesAsync()
        {
            throw new NotImplementedException();
        }
    }
}
