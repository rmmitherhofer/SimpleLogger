using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SimpleLogger.Application
{
    public interface ISimpleLogger
    {
        Task Publish(HttpContext httpContext, Exception exception, string timer);
        Task Publish(HttpContext httpContext, IEnumerable<Exception> exception, string timer);
        Task Publish(HttpContext httpContext, IDictionary<string, string> notifications, string timer);
    }
}
