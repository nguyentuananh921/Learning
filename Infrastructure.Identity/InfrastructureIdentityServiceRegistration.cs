using Infrastructure.Identity.Context;
using Infrastructure.Identity.Identity;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Identity
{
    public static class InfrastructureIdentityServiceRegistration
    {
        public static IServiceCollection ConfigureIdentityServices(this IServiceCollection services, 
            IConfiguration configuration)
        {
            #region Identity Netcore
            services.AddDbContext<IdentityDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("IdentityConnection"),
                b => b.MigrationsAssembly(typeof(IdentityDbContext).Assembly.FullName)));

            services.AddIdentity<ApplicationUser, IdentityRole>(options=>
                                options.SignIn.RequireConfirmedAccount=true)
                .AddEntityFrameworkStores<IdentityDbContext>()
                .AddDefaultTokenProviders();
            #region Identity UI
            /*https://www.youtube.com/watch?v=AopeJjkcRvU&t=34s
            Time:8:05
             
            services.ConfigureApplicationCookie(options => {
                options.LoginPath = $"/Identity/Account/Pages/Login";
                options.LogoutPath = $"/Identity/Account/Pages/Logout";
                options.AccessDeniedPath = $"/Identity/Pages/Account/AccessDenied";
            });*/
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                    .AddCookie(options =>
                    {
                        options.LoginPath = "/login";
                        options.AccessDeniedPath = "/login";
                    });
            #endregion



            #endregion
            //services.AddTransient<IAuthService, AuthService>();
            //services.AddTransient<IUserService, UserService>();


            //services.Configure<JwtSettings>(configuration.GetSection("JwtSettings"));
            //services.AddAuthentication(options =>
            //{
            //    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            //    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            //})
            //    .AddJwtBearer(o =>
            //    {
            //        o.TokenValidationParameters = new TokenValidationParameters
            //        {
            //            ValidateIssuerSigningKey = true,
            //            ValidateIssuer = true,
            //            ValidateAudience = true,
            //            ValidateLifetime = true,
            //            ClockSkew = TimeSpan.Zero,
            //            ValidIssuer = configuration["JwtSettings:Issuer"],
            //            ValidAudience = configuration["JwtSettings:Audience"],
            //            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JwtSettings:Key"]))
            //        };
            //    });
            return services;
        }
    }
}