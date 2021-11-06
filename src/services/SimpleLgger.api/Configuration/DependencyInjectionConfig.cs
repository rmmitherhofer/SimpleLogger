using Core.Mediator;
using FluentValidation.Results;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using SimpleLogger.api.Application.Commands;
using SimpleLogger.api.Application.Commands.Handler;
using SimpleLogger.api.Application.Queries;
using SimpleLogger.Business.Interfaces.Repository;
using SimpleLogger.Data;
using SimpleLogger.Data.Repository;

namespace SimpleLogger.api.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<IMediatorHandler, MediatorHandler>();

            services.AddScoped<IRequestHandler<InsertLogCommand, ValidationResult>, LogCommandHandler>();
            services.AddScoped<IRequestHandler<InsertProjectCommand, ValidationResult>, ProjectCommandHandler>();


            services.AddScoped<IProjectQueries, ProjectQueries>();
            services.AddScoped<ILogQueries, LogQueries>();

            services.AddScoped<ILogRepository, LogRepository>();
            services.AddScoped<IProjectRepository, ProjectRepository>();
            services.AddScoped<LoggerContext>();

            //services.AddHostedService<RegistroClienteIntegrationHandler>();
        }
    }
}
