using Core.Application.Interfaces.Infrastructure.Persistence;
using Core.Domain.Entities;
using Infrastructure.Identity.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Contexts
{
    public class ApplicationDbContext: DbContext,IApplicationDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<BookCategory> BookCategories { get; set; }     
        #region Repository Learn https://codewithmukesh.com/blog/repository-pattern-in-aspnet-core/
        public DbSet<Developer> Developers { get; set; }
        public DbSet<Project> Projects { get; set; }
        #endregion
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(builder);            
                        
            //builder.Entity<Product>(entity =>
            //{
            //    entity.ToTable(name: "Products");
            //    entity.Property(e => e.Id).ValueGeneratedNever().HasColumnName("Id");
            //    entity.Property(p => p.Rate).HasColumnType("decimal(10, 2)");
            //});
            //#region Developer and Project            
            
            //builder.Entity<Project>(entity =>
            //{
            //    entity.ToTable(name: "Projects");
            //    entity.Property(e => e.Id).ValueGeneratedNever().HasColumnName("Id");
            //});
            //#endregion
            //#region Books
            //builder.HasDefaultSchema("Books");
            //builder.Entity<Book>(entity =>
            //{
            //    entity.ToTable(name: "Books");
            //    entity.Property(e => e.Id).ValueGeneratedNever().HasColumnName("Id");
            //});
            
            //builder.Entity<BookCategory>(entity =>
            //{
            //    entity.ToTable(name: "BookCategories");
            //    entity.Property(e => e.Id).ValueGeneratedNever().HasColumnName("Id");
            //});
            //#endregion
            
        }

        
    }
}
