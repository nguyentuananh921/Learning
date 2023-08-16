using Infrastructure.Identity.Context;
using Infrastructure.Identity.Identity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Identity.Seed
{
    /* Seed Identity Netcore 8.
     * https://www.youtube.com/watch?v=sO8zUaWvOxo
     * https://github.com/medhatelmasry/SeedIdentity
     */
    public class SeedIdentityData
    {
        public static async Task Initialize(IdentityDbContext context,
        UserManager<ApplicationUser> userManager,
        RoleManager<IdentityRole> roleManager)
        {

            context.Database.EnsureCreated();
            #region Seed Role
            if (await roleManager.FindByNameAsync("SuperAdmin") == null)
            {
                await roleManager.CreateAsync(new IdentityRole("SuperAdmin"));
            }

            if (await roleManager.FindByNameAsync("Admin") == null)
            {
                await roleManager.CreateAsync(new IdentityRole("Admin"));
            }
            if (await roleManager.FindByNameAsync("Moderator") == null)
            {
                await roleManager.CreateAsync(new IdentityRole("Moderator"));
            }
            if (await roleManager.FindByNameAsync("Basic") == null)
            {
                await roleManager.CreateAsync(new IdentityRole("Basic"));
            }
            #endregion
            #region Seed Basic User            
            if (await userManager.FindByNameAsync("BasicUser") == null)
            {
                var basicUser = new ApplicationUser
                {
                    UserName = "BasicUser",
                    Email = "basicuser@gmail.com",
                    FirstName = "John",
                    LastName = "Doe",
                    EmailConfirmed = true,
                    PhoneNumberConfirmed = true
                };
                await userManager.CreateAsync(basicUser, "123Pa$$word!");
                await userManager.AddToRoleAsync(basicUser, "Basic"); //Add User to BasicRole
            }
            #endregion
            #region Seed Admin User
            if (await userManager.FindByNameAsync("nguyentuananh921@gmail.com") == null)
            {
                var superAdmin = new ApplicationUser
                {
                    UserName = "nguyentuananh921@gmail.com",
                    Email = "nguyentuananh921@gmail.com",
                    FirstName = "Mukesh",
                    LastName = "Murugan",
                    EmailConfirmed = true,
                    PhoneNumberConfirmed = true
                };
                await userManager.CreateAsync(superAdmin, "123Pa$$word!");
                await userManager.AddToRoleAsync(superAdmin, "Basic");
                await userManager.AddToRoleAsync(superAdmin, "Moderator");
                await userManager.AddToRoleAsync(superAdmin, "Admin");
                await userManager.AddToRoleAsync(superAdmin, "SuperAdmin");

            }
            #endregion            
        }
    }
}
