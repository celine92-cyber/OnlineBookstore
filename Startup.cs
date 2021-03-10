using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using OnlineBookstore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineBookstore
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            this.Configuration = configuration;
        }

        public IConfiguration Configuration { get; set; }
        
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();

           //Connect the database
            services.AddDbContext<OnlineBookstoreDbContext>(options =>
           {
               options.UseSqlite(Configuration["ConnectionStrings:OnlineBookstoreConnection"]);
           });

            //Add Scope
            services.AddScoped<IOnlineBookstoreRepository, EFOnlineBookstoreRepository>();

            //Add Razor Pages
            services.AddRazorPages();

            services.AddDistributedMemoryCache();
            services.AddSession();//get information to stick
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseSession();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                //if the user passes category and page number Ex. Classic/1
                endpoints.MapControllerRoute("catpage",
                    "{category}/{pageNum:int}",
                    new { Controller = "Home", action = "Index" });

                //if the user passes category and page number with "P" Ex. Classic/P1
                endpoints.MapControllerRoute("catpage",
                    "{category}/P{pageNum:int}",
                    new { Controller = "Home", action = "Index" });

                //if the user passes Books/page number Ex.Books/2
                endpoints.MapControllerRoute("page",
                    "Books/{pageNum:int}",
                    new { Controller = "Home", action = "Index" });

                //if the user passes only the page number Ex./2
                endpoints.MapControllerRoute("page",
                    "{pageNum:int}",
                    new { Controller = "Home", action = "Index" });

                //if the user  passes /Books and category Ex. Books/Classic
                endpoints.MapControllerRoute("category",
                    "Books/{category}",
                    new { Controller = "Home", action = "Index", page = 1 });

                //if the user only passes category Ex. /Classic
                endpoints.MapControllerRoute("category",
                    "{category}",
                    new { Controller = "Home", action = "Index", page = 1 });

                //if the user passes Ex./P2
                //This used to work,but doesn't work now
                //If I delete the new endpoints /p2 will direct me to the right page
                endpoints.MapControllerRoute(
                   "pagination",
                   "P{pageNum}",
                   new { Controller = "Home", action = "Index" });

                endpoints.MapDefaultControllerRoute();

                endpoints.MapRazorPages();
            });

            SeedData.EnsurePopulated(app); //bring the seed data
        }
    }
}
