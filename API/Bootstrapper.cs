using AutoMapper;
using CrossCutting.Mediator;
using Domain.Handlers;
using Domain.Interfaces;
using Infra.Data.Context;
using Infra.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace API
{
    public static class Bootstrapper
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {           
            services.AddSingleton(Mapper.Configuration);
            services.AddScoped<IMapper>(sp => new Mapper(sp.GetRequiredService<IConfigurationProvider>(), sp.GetService));            
            services.AddScoped<DbContext, CustomerContext>();
            services.AddScoped<IDomainNotificationHandler, DomainNotificationHandler>();
            services.AddScoped<IDomainNotificationManager, DomainNotificationManager>();
            services.AddScoped<IMediatorHandler, MediatorHandler>();

            services.AddScoped<ICreateCustomerHandler, CreateCustomerHandler>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            return services;
        }
    }
}