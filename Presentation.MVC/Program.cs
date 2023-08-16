using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Infrastructure.Identity.Identity;

using Infrastructure.Identity;
using Infrastructure.Share;
using Infrastructure.Identity.Seed;
using Infrastructure.Identity.Context;

var builder = WebApplication.CreateBuilder(args);

#region Service from other layer
    builder.Services.ConfigureInfrastructureShareServices(builder.Configuration);
    builder.Services.ConfigureIdentityServices(builder.Configuration);
//builder.Services.ConfigurePersistenceServices(builder.Configuration);
#endregion

builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();
#region MapControllerRoute
        app.MapControllerRoute(
                           name: "Admin",
                           pattern: "{area:exists}/{controller}/{action=Index}/{id?}");
        app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
#endregion

app.MapRazorPages();
#region Seed Identity Data
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<IdentityDbContext>();
    context.Database.Migrate();
    var userMgr = services.GetRequiredService<UserManager<ApplicationUser>>();
    var roleMgr = services.GetRequiredService<RoleManager<IdentityRole>>();
    SeedIdentityData.Initialize(context, userMgr, roleMgr).Wait();
}
#endregion

app.Run();
