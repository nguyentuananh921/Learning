using Core.Application.Interfaces.Infrastructure.Share;
using Infrastructure.Share.Service;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Share
{
    public static class InfrastructureShareServicesRegistration
    {
        public static IServiceCollection ConfigureInfrastructureShareServices(this IServiceCollection services, IConfiguration configuration)
        {
            //services.Configure<EmailSettings>(configuration.GetSection("EmailSettings"));
            #region AddService To Application Interface
            //services.AddScoped<IEmailSender, EmailSender>();
            services.AddScoped<IAppEmailSender, EmailSender>();
            services.AddScoped<IDateTime, DateTimeService>();
            #endregion


            return services;
        }
    }
}
