using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mission9.Models;

namespace Mission9
{
    public class Startup
    {

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public IConfiguration Configuration { get; set; }
        public Startup(IConfiguration temp)
        {
            Configuration = temp;
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();

            services.AddDbContext<Mission9Context>(options =>
            {
                options.UseSqlite(Configuration["ConnectionStrings:Mission9DBConnection"]);
            });
            //registers singleton instances of the ef repositories whenever an instance of the i repository interfaces are requested. 
            services.AddScoped<IMission9Repository, EFMission9Repository>();
            services.AddScoped<IPurchaseRepository, EFPurchaseRepository>();

            services.AddRazorPages();

            services.AddDistributedMemoryCache();
            services.AddSession();

            services.AddScoped<Basket>(x => SessionBasket.GetBasket(x));
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            //uses wwwroot
            app.UseStaticFiles();
            // uses sesssion, proper routing, and the detailed endpoints.
            app.UseSession();

            app.UseRouting();

            app.Use(async (context, next) =>
            {
                context.Response.Headers.Add("X-Xss-Protection", "1");
                await next();
            });

            app.UseEndpoints(endpoints =>
            {
                //Created and ordered new endpoints to make the urls make sense and have the correct behavior for the user when they click on different buttons. 
                
                endpoints.MapControllerRoute("categorypage", "{bookCategory}/Page{pageNum}", new { Controller = "Home", action = "Index" });

                endpoints.MapControllerRoute(
                    name: "Paging",
                    pattern: "Page{pageNum}",
                    defaults: new { Controller = "Home", action = "Index", pageNum = 1});

                endpoints.MapControllerRoute("category", "{bookCategory}", new { Controller = "Home", action = "Index", pageNum = 1});
                

                endpoints.MapDefaultControllerRoute();

                endpoints.MapRazorPages();
            });
        }
    }
}
