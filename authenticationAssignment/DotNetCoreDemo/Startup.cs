using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCoreDemo
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddSession();
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

            app.UseRouting();

            app.UseAuthorization();
            app.UseSession();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
            app.Map("/abc", appMap =>
            {
                appMap.Run(async context => {
                    await context.Response.WriteAsync("mapRequest called");
                });
            });
           /* app.Use(async (context, next) => {
                await context.Response.WriteAsync("This is my 1st middleware start");
                await next();
                await context.Response.WriteAsync("This is my 1st middleware end");
            });
            app.Use(async (context, next) => {
                await context.Response.WriteAsync("This is my 2nd middleware start");
                await next();
                await context.Response.WriteAsync("This is my  2nd middleware end");
            });*/
            //custom middleware
            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("This is my 3rd middleware start");
                await context.Response.WriteAsync("This is my 3rd middleware end");
                //terminal middleware
            });
            
        }
    }
}
