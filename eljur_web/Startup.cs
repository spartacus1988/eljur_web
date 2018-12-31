using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
//using EFGetStarted.AspNetCore.ExistingDb.Models;
using Microsoft.EntityFrameworkCore;
using eljur_web.Models;

namespace eljur_web
{
    public class Startup
    {
  
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });


            //services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddMvc();

            var connection = @"Server=DESKTOP-I43QIPT\SQLEXPRESS;Database=StaffDb;Trusted_Connection=True;ConnectRetryCount=0";
            services.AddDbContext<StaffDbContext>(options => options.UseSqlServer(connection));

        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });

            app.Use(async (context, next) =>
            {
                await context.Response.WriteAsync("Hello!");
                await next();
            });
            app.Run(Handle);
        }

        public async Task Handle(HttpContext context)
        {
            //context.Response.ContentType = "text/html; charset =utf-8";
            //await context.Response.WriteAsync("Hello World!");
            await Task.FromResult(0);
        }

    }
}
