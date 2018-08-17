using System;
using System.Reflection;
using AutoMapper;
using FluentValidation.AspNetCore;
using Infra.Data.Context;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NJsonSchema;
using NSwag.AspNetCore;
using Infra.API;

namespace API.Standard
{
    public static class Extensions
    {
        public static IApplicationBuilder ConfigureApi(this IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseExceptionHandler("/Error/Handle");
            
            app.UseCors(builder =>
            {
                builder.AllowAnyMethod();
                builder.AllowAnyOrigin();
                builder.WithHeaders("Origin", "X-Requested-With", "Content-Type", "Accept");
            });

            using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                // var context = serviceScope.ServiceProvider.GetRequiredService<CustomerContext>();
                // context.Database.Migrate();
            }
            app.ConfigureApplication(env, "Customers", "v1");
            app.UseSwaggerUi(typeof(Extensions).GetTypeInfo().Assembly, settings =>
            {
                settings.GeneratorSettings.DefaultPropertyNameHandling = PropertyNameHandling.CamelCase;
                settings.PostProcess = document =>
                {
                    document.Info.Version = "v1";
                    document.Info.Title = "Customers";
                    document.Info.Description = "Customers";
                    document.Info.TermsOfService = "None";                    
                };
            });
            return app;
        }

        public static IServiceCollection ConfigureApi(this IServiceCollection services, IConfiguration configuration, Type startup)
        {
            var dbConnection = configuration.GetConnectionString("DB_URL") ?? Environment.GetEnvironmentVariable("DB_URL");
            // services.AddDbContext<CustomerContext>(options => options.UseSqlServer(
            //   $"Server={dbConnection};Database=Customers;User Id=sa;Password=customersPass2018;MultipleActiveResultSets=true"
            // ));
            services.ConfigureServices(configuration, "Customers", "Customers", "v1", startup);
            services
                .AddMvc()
                .AddFluentValidation(fvc => fvc.RegisterValidatorsFromAssemblyContaining(startup));

            services.AddAutoMapper();
            services.RegisterServices();

            return services;
        }
    }
}