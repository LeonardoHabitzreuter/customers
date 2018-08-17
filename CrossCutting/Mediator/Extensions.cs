using System;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace CrossCutting.Mediator
{
    public static class Extensions
    {
        public static IServiceCollection ConfigureDomainEvents(this IServiceCollection services, Type type)
        {
            services.AddMediatR(type);
            services.AddScoped<IMediatorHandler, MediatorHandler>();
            services.AddScoped<INotificationHandler<DomainNotification>, DomainNotificationHandler>();
            services.AddScoped<IDomainNotificationManager, DomainNotificationManager>();

            return services;
        }
    }
}