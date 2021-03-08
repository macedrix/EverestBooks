using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using OnlineBookStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

//Name of project, and will say what directory we are in
namespace OnlineBookStore
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddDbContext<BookStoreDBContext>(options =>
            {
                options.UseSqlite(Configuration["ConnectionStrings:OnlineBookStoreConnection"]);
            });

            services.AddScoped<IBookRepository, EFBookRepository>();

            services.AddRazorPages();

            services.AddDistributedMemoryCache();

            services.AddSession();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                //When developing, show me an ugly error screen so I know whats wrong
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


            //routing is figuring out how we are going to run the code based on what is in the url
            app.UseRouting();

            app.UseAuthorization();

            //based on a URL, what's the end result of that call. 
            app.UseEndpoints(endpoints =>
            {
                //If the user gives a category and a page
                endpoints.MapControllerRoute("categorypage",
                    "{category}/{pageNum:int}",
                    new { Controller = "Home", action = "Index" });

                //Add the page number to the url like /P1 or /P2 etc
                endpoints.MapControllerRoute("pagination",
                    "P{pageNum:int}",
                    new { Controller = "Home", action = "Index" });

                //If the user only passes in a category
                endpoints.MapControllerRoute("category",
                    "{category}",
                    new { Controller = "Home", action = "Index", pageNum = 1 });
              
                endpoints.MapDefaultControllerRoute();

                //Allow endpoints to point to razor pages
                endpoints.MapRazorPages();
            });

            SeedData.EnsurePopulated(app);
        }
    }
}
