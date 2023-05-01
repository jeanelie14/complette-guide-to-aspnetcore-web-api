using System;
using System.Threading;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.DependencyInjection;
using my_books.Data.Models;

namespace my_books.Data
{
    public class AppDbInitializer
    {
        public  static void seed (IApplicationBuilder applicationBuilder)
        {
            using (var  serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
              
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();

                if (!context.Books.Any())
                {
                    context.Books.AddRange(new Book()
                    {
                        Title = "1st Book Title",
                        Description = "1st Book Description",
                        IsRead = true,
                        DateRead = DateTime.Now.AddDays(-10),
                        Rate = 5,
                        Genre = "Masculin",
                      //  Author = "Jean Elie",
                        CoverUrl = "https ......",
                        DateAdded = DateTime.Now
                        },
                        new Book()
                        {
                        Title = "2st Book Title",
                        Description = "2st Book Description",
                        IsRead = true,
                        DateRead = DateTime.Now.AddDays(-9),
                        Rate = 5,
                        Genre = "Femiin",
                       // Author = "Jean Elie",
                        CoverUrl = "https ......",
                        DateAdded = DateTime.Now


                    });
                    context.SaveChanges();
                }
            }
        }
    }
}
