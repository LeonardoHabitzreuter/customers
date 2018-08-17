using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.ResponseCompression;
using CrossCutting.Mediator;
using System;

namespace Infra.API
{
    public static class Extensions
    {
        public static IApplicationBuilder ConfigureApplication(this IApplicationBuilder app, IHostingEnvironment env, string apiName, string apiVersion)
        {
            app.UseResponseCompression();

            app.UseCors(c =>
            {
                c.AllowAnyHeader();
                c.AllowAnyMethod();
                c.AllowAnyOrigin();
            });
            app.UseMvcWithDefaultRoute();

            return app;
        }

        public static IServiceCollection ConfigureServices
            (
                this IServiceCollection services, 
                IConfiguration configuration,                 
                string serviceId, 
                string apiName, 
                string apiVersion,
                Type startupType 
            )
        {
            services.Configure<GzipCompressionProviderOptions>(options => options.Level = System.IO.Compression.CompressionLevel.Optimal);
            services.AddResponseCompression(options =>
            {
                options.EnableForHttps = true;
            });

            services.ConfigureDomainEvents(startupType);
            return services;
        }
    }
}