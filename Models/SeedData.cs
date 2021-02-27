using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineBookstore.Models
{
    public class SeedData
    {
        public static void EnsurePopulated (IApplicationBuilder application)
        {
            OnlineBookstoreDbContext context = application.ApplicationServices.
                CreateScope().ServiceProvider.GetRequiredService<OnlineBookstoreDbContext>();

            if(context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();
            }

            //Manually seed the 10 books info
            if (!context.Books.Any())
            {
                context.Books.AddRange(
                    new Book
                    {
                        Title = "Les Miserables",
                        Author = "Victor Hugo",
                        Publisher = "Signet",
                        ISBN = "978-0451419439",
                        Classification = "Fiction",//normalized the Classification and Category
                        Category = "Classic",
                        Price = 9.95,
                        Pages = 1488
                    },

                    new Book
                    {
                        Title = "Team of Rivals",
                        Author = "Doris Kearns Goodwin",
                        Publisher = "Simon & Schuster",
                        ISBN = "978-0743270755",
                        Classification = "Non-Fiction",
                        Category = "Biography",
                        Price = 14.58,
                        Pages = 944
                    },
                    new Book
                    {
                        Title = "The Snowball",
                        Author = "Alice Schroeder",
                        Publisher = "Bantam",
                        ISBN = "978-0553384611",
                        Classification = "Non-Fiction",
                        Category = "Biography",
                        Price = 21.54,
                        Pages = 832
                    },
                    new Book
                    {
                        Title = "American Ulysses",
                        Author = "Ronald C. White",
                        Publisher = "Random House ",
                        ISBN = "978-0812981254",
                        Classification = "Non-Fiction",
                        Category = "Biography",
                        Price = 11.61,
                        Pages = 864
                    },
                    new Book
                    {
                        Title = "Unbroken",
                        Author = "Laura Hillenbrand",
                        Publisher = "Simon & Schuster",
                        ISBN = "978-0812974492",
                        Classification = "Non-Fiction",
                        Category = "Historical",
                        Price = 13.33,
                        Pages = 528

                    },
                    new Book
                    {
                        Title = "The Great Train Robbery",
                        Author = "Michael Crichton",
                        Publisher = "Vintage",
                        ISBN = "978-0804171281",
                        Classification = "Fiction",
                        Category = "Historical Fiction",
                        Price = 15.95,
                        Pages = 288
                    },
                    new Book
                    {
                        Title = "Deep Work",
                        Author = "Cal Newport",
                        Publisher = "Grand Central Publishing",
                        ISBN = "978-1455586691",
                        Classification = "Non-Fiction",
                        Category = "Self-Help",
                        Price = 14.99,
                        Pages = 304
                    },
                    new Book
                    {
                        Title = "It's Your Ship",
                        Author = "Michael Abrashoff",
                        Publisher = "Grand Central Publishing",
                        ISBN = "978-1455523023",
                        Classification = "Non-Fiction",
                        Category = "Self-Help",
                        Price = 21.66,
                        Pages = 240
                    },
                     new Book
                     {
                         Title = "The Virgin Way",
                         Author = "Richard Branson",
                         Publisher = "Portfolio",
                         ISBN = "978-1591847984",
                         Classification = "Non-Fiction",
                         Category = "Business",
                         Price = 29.16,
                         Pages = 400
                     },
                      new Book
                      {
                          Title = "Sycamore Row",
                          Author = "John Grisham",
                          Publisher = "Bantam",
                          ISBN = "978-0553393613",
                          Classification = "Fiction",
                          Category = "Thrillers",
                          Price = 15.03,
                          Pages = 642
                      },
                      new Book
                      {
                          Title = "Holiday That Never Ends",
                          Author = "Kōtarō Isaka",
                          Publisher = "New Star Press",
                          ISBN = "978-7513315340",
                          Classification = "Novel",
                          Category = "Adventure",
                          Price = 19,
                          Pages = 232
                      },
                      new Book
                      {
                          Title = "Robinson Crusoe",
                          Author = "Daniel Defoe",
                          Publisher = "William Taylor",
                          ISBN = "978-0393964523",
                          Classification = "Historical Fiction",
                          Category = "Adventure",
                          Price = 7.95,
                          Pages = 198
                      },
                      new Book
                      {
                          Title = "The Little Prince",
                          Author = " Antoine de Saint-Exupéry",
                          Publisher = "	Reynal & Hitchcock",
                          ISBN = "978-1784874179",
                          Classification = "Fantasy",
                          Category = "Novella",
                          Price = 7.95,
                          Pages = 198
                      }



                    );


                context.SaveChanges();
            }
        }
    }
}
