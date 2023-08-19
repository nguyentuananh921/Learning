using Core.Domain.Entities;
using Infrastructure.Identity.Identity;
using Infrastructure.Persistence.Contexts;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Seed
{
    public static class SeedBookData
    {
        public static async Task InitializeBookCategoriesData(ApplicationDbContext context)
        {
            //await context.Database.MigrateAsync();
            context.Database.EnsureCreated();
            if (!context.BookCategories.Any())
            {
                var categoryslist = new List<BookCategory>
                    {
                        new BookCategory { Id = 1, Name = "Action", DisplayOrder = 1 },
                        new BookCategory { Id = 2, Name = "SciFi", DisplayOrder = 2 },
                        new BookCategory { Id = 3, Name = "History", DisplayOrder = 3 }
                    };
                await context.AddRangeAsync(categoryslist);
                await context.SaveChangesAsync();
            }
            
        }
        public static async Task InitializeBookData(ApplicationDbContext context)
        {
            await context.Database.MigrateAsync();
            context.Database.EnsureCreated();
            if (!context.Books.Any())
            {
                var samplebooks = new List<Book>
                    {
                        new Book
                        {
                            Title = "Fortune of Time",
                            Author = "Billy Spark",
                            Description = "Praesent vitae sodales libero. Praesent molestie orci augue, vitae euismod velit sollicitudin ac. Praesent vestibulum facilisis nibh ut ultricies.\r\n\r\nNunc malesuada viverra ipsum sit amet tincidunt. ",
                            ISBN = "SWD9999001",
                            ListPrice = 99,
                            Price = 90,
                            Price50 = 85,
                            Price100 = 80,
                            BookCategoryID = 1,
                            ImageUrl = ""
                        },
                        new Book
                    {
                        Id = 2,
                        Title = "Dark Skies",
                        Author = "Nancy Hoover",
                        Description = "Praesent vitae sodales libero. Praesent molestie orci augue, vitae euismod velit sollicitudin ac. Praesent vestibulum facilisis nibh ut ultricies.\r\n\r\nNunc malesuada viverra ipsum sit amet tincidunt. ",
                        ISBN = "CAW777777701",
                        ListPrice = 40,
                        Price = 30,
                        Price50 = 25,
                        Price100 = 20,
                        BookCategoryID = 1,
                        ImageUrl = ""
                    },
                        new Book
                    {
                        Id = 3,
                        Title = "Vanish in the Sunset",
                        Author = "Julian Button",
                        Description = "Praesent vitae sodales libero. Praesent molestie orci augue, vitae euismod velit sollicitudin ac. Praesent vestibulum facilisis nibh ut ultricies.\r\n\r\nNunc malesuada viverra ipsum sit amet tincidunt. ",
                        ISBN = "RITO5555501",
                        ListPrice = 55,
                        Price = 50,
                        Price50 = 40,
                        Price100 = 35,
                        BookCategoryID = 1,
                        ImageUrl = ""
                    },
                        new Book
                    {
                        Id = 4,
                        Title = "Cotton Candy",
                        Author = "Abby Muscles",
                        Description = "Praesent vitae sodales libero. Praesent molestie orci augue, vitae euismod velit sollicitudin ac. Praesent vestibulum facilisis nibh ut ultricies.\r\n\r\nNunc malesuada viverra ipsum sit amet tincidunt. ",
                        ISBN = "WS3333333301",
                        ListPrice = 70,
                        Price = 65,
                        Price50 = 60,
                        Price100 = 55,
                        BookCategoryID = 2,
                        ImageUrl = ""
                    },
                        new Book
                    {
                        Id = 5,
                        Title = "Rock in the Ocean",
                        Author = "Ron Parker",
                        Description = "Praesent vitae sodales libero. Praesent molestie orci augue, vitae euismod velit sollicitudin ac. Praesent vestibulum facilisis nibh ut ultricies.\r\n\r\nNunc malesuada viverra ipsum sit amet tincidunt. ",
                        ISBN = "SOTJ1111111101",
                        ListPrice = 30,
                        Price = 27,
                        Price50 = 25,
                        Price100 = 20,
                        BookCategoryID = 2,
                        ImageUrl = ""
                    },
                        new Book
                    {
                        Id = 6,
                        Title = "Leaves and Wonders",
                        Author = "Laura Phantom",
                        Description = "Praesent vitae sodales libero. Praesent molestie orci augue, vitae euismod velit sollicitudin ac. Praesent vestibulum facilisis nibh ut ultricies.\r\n\r\nNunc malesuada viverra ipsum sit amet tincidunt. ",
                        ISBN = "FOT000000001",
                        ListPrice = 25,
                        Price = 23,
                        Price50 = 22,
                        Price100 = 20,
                        BookCategoryID = 3,
                        ImageUrl = ""
                    }
                    };
                await context.AddRangeAsync(samplebooks);
                await context.SaveChangesAsync();
            }
        }
    }
}
