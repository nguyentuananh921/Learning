using Core.Domain.Entities;
using Infrastructure.Identity.Identity;
using Infrastructure.Persistence.Contexts;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Seed
{
    public class SeedDeveloperData
    {
        public static async Task InitializeDeveloper(ApplicationDbContext context)
        {
            context.Database.EnsureCreated();
            if (!context.Developers.Any()) 
            {
                var developer = new Developer { Followers = 35, Name = "Mukesh Murugan" };
                context.Add(developer);
                var project = new Project { Name = "codewithmukesh" };
                context.Add(project);
                await context.SaveChangesAsync();
            }            

        }
    }
}
