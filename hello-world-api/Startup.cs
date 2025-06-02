using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Http;

namespace hello_world_api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // Add services to the container
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers(); // Replaces AddMvc()
        }

        // Configure the HTTP request pipeline
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env) // <- Updated type here
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    var port = Environment.GetEnvironmentVariable("PORT") ?? "5000";
                    await context.Response.WriteAsync($"Hello World running on port {port}!");
                });

                endpoints.MapControllers(); // for API endpoints if you have any
            });
        }
    }
}
