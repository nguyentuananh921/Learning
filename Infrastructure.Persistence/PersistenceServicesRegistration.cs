using Core.Application.Interfaces.Infrastructure.Persistence;
using Core.Application.Interfaces.Infrastructure.Persistence.Repository.Common;
using Infrastructure.Persistence.Contexts;
using Infrastructure.Persistence.Repositories.Common;
using Infrastructure.Persistence.Seed;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Persistence
{
    public static class PersistenceServicesRegistration
    {
        public static IServiceCollection ConfigurePersistenceServices(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(option =>
                option.UseSqlServer(
                    configuration.GetConnectionString("DefaultConnection"),
                    b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));

            services.AddScoped<IApplicationDbContext>(provider => provider.GetService<ApplicationDbContext>());
            //services.AddScoped<ApplicationDbContext>(provider => provider.GetService<ApplicationDbContext>());

            #region Repository           

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            #endregion

            return services;

        }
    }
}
