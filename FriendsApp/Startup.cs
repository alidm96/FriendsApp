using FriendsApp.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FriendsApp
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
            services.AddSwaggerGen();

            services.AddEntityFrameworkSqlServer()
                .AddDbContext<Data.Context.FriendsDbContext>(config => {
                    config.UseSqlServer(Configuration["ConnectionStrings:DefaultConnection"]);
                });

            services.AddScoped(typeof(IFriendsRepository), typeof(FriendsRepository));

            services.AddScoped(typeof(IFriendsService), typeof(FriendsService));

            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/Swagger/v1/Swagger.json", "Friends api");
            });

            app.Map("/total-friends", (context) =>
            {
                context.Run(async (httpcontext) => { await httpcontext.Response.WriteAsync("<h1> Total Friends: " + FriendsApp.Controllers.FriendsController.FriendsCount + "</h1>"); });
            });

            app.Map("/friends-json", (context) =>
            {
                context.Run(async (httpcontext) => {
                    await httpcontext.Response.WriteAsync(FriendsApp.Controllers.FriendsController.FriendsJSON);
                });
            });

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

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
