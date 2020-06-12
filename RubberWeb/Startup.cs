using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RubberWeb.Services;
using System;
using System.Net.Http.Headers;

namespace RubberWeb
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            var connectionString = Configuration.GetConnectionString("Default");
            services
                .AddDbContext<AppDbContext>(options => options.UseNpgsql(connectionString));

            services
                .AddHttpClient("GrillBot", client =>
                {
                    var config = Configuration.GetSection("GrillBot");

                    client.BaseAddress = new Uri(config["BaseUrl"]);
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("GrillBot", config["Token"]);
                });

            services
                .AddScoped<GrillBotService>()
                .AddScoped<AppDbRepository>()
                .AddControllersWithViews();

            services
                .AddSpaStaticFiles(configuration => configuration.RootPath = "ClientApp/dist");
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();
            else
                app.UseExceptionHandler("/Error");

            app.UseStaticFiles();
            if (!env.IsDevelopment())
                app.UseSpaStaticFiles();

            app
                .UseRouting()
                .UseEndpoints(endpoints =>
                {
                    endpoints.MapControllerRoute(name: "default", pattern: "{controller}/{action=Index}/{id?}");
                })
                .UseSpa(spa =>
                {
                    spa.Options.SourcePath = "ClientApp";

                    if (env.IsDevelopment())
                        spa.UseAngularCliServer(npmScript: "start");
                });
        }
    }
}
