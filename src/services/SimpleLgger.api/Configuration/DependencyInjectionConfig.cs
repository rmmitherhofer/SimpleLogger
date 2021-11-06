﻿using MediatR;
using Microsoft.Extensions.DependencyInjection;
using SimpleLogger.api.Data;

namespace SimpleLogger.api.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            //services.AddScoped<IMediatorHandler, MediatorHandler>();
            //services.AddScoped<IRequestHandler<RegistrarClienteCommand, ValidationResult>, ClienteCommandHandler>();

            //services.AddScoped<INotificationHandler<ClienteRegistradoEvent>, ClienteEventHandler>();

            //services.AddScoped<IClienteRepository, ClienteRepository>();
            services.AddScoped<LoggerContext>();

            //services.AddHostedService<RegistroClienteIntegrationHandler>();
        }
    }
}
