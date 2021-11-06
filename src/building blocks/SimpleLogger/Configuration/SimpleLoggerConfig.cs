using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using SimpleLogger.Application;
using SimpleLogger.Enums;
using SimpleLogger.Services;
using SimpleLogger.Services.Handler;
using System.Collections.Generic;

namespace SimpleLogger.Configuration
{
    public static class SimpleLoggerConfig
    {
        public static void AddSimple(this IServiceCollection services, ProjectType type, string projectName)
        {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            var project = new Dictionary<ProjectType, string>
            {
                {type, projectName.Split(',')[0] }
            };

            services.AddScoped<ISimpleLogger, Application.SimpleLogger>();

            services.AddHttpClient<ISimpleLoggerService, SimpleLoggerService>()
                .AddHttpMessageHandler<HttpClientAuthorizationDelegatingHandler>();
            //.AddPolicyHandler(PollyExtensions.EsperarTentar())
            //.AddTransientHttpErrorPolicy(
            //    p => p.CircuitBreakerAsync(5, TimeSpan.FromSeconds(30)));

            services.AddSingleton("https://localhost:1234");

            services.AddSingleton(project);
        }
    }
}
