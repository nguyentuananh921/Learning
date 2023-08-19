using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Core.Application.Interfaces.Infrastructure.Persistence
{
    public interface IApplicationDbContext
    {
        DbSet<Product> Products { get; set; }
        DbSet<Book> Books { get; set; }
        DbSet<BookCategory> BookCategories { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
