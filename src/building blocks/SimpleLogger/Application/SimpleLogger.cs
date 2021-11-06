using Microsoft.AspNetCore.Http;
using SimpleLogger.Enums;
using SimpleLogger.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SimpleLogger.Models;
using System.Net;
using System.IO;
using SimpleLogger.Services;

namespace SimpleLogger.Application
{
    public class SimpleLogger : ISimpleLogger
    {
        private readonly IAspNetUser _aspNetUser;
        private readonly ISimpleLoggerService _service;
        private readonly KeyValuePair<ProjectType, string> _project;

        public SimpleLogger(IAspNetUser aspNetUser, 
                            ISimpleLoggerService service, 
                            IDictionary<ProjectType, string> project)
        {
            _aspNetUser = aspNetUser;
            _service = service;
            _project = project.First();
            
        }

        public Task Publish(HttpContext httpContext, Exception exception, string timer)
        {
            var log = Create(httpContext, timer);

            InsertErrors(log, exception);

            _service.Insert(log);

            return Task.CompletedTask;
        }
        public Task Publish(HttpContext httpContext, IEnumerable<Exception> exceptions, string timer)
        {
            var log = Create(httpContext, timer);

            InsertErrors(log, exceptions);

            _service.Insert(log);

            return Task.CompletedTask;
        }
        public Task Publish(HttpContext httpContext, IDictionary<string, string> notifications, string timer)
        {
            var log = Create(httpContext, timer);

            InsertErrors(log, notifications);

            _service.Insert(log);

            return Task.CompletedTask;
        }

        private Log Create(HttpContext httpContext, string timer)
        {
            string hostName = Dns.GetHostName();
            var hostEntry = Dns.GetHostEntry(hostName);

            var log = new Log
            {
                Path = httpContext.Request.Path,
                Timer = timer,
            };

            log.Project = new Project
            {
                Type = _project.Key,
                Name = _project.Value
            };

            var ip = hostEntry.AddressList.Length;
            log.Client = new Client
            {
                Id = _aspNetUser.GetUserId(),
                UserAgent = httpContext.Request.Headers["User-Agent"],
                HostName = hostEntry.HostName,
                ClientAddress = hostEntry.AddressList[ip - 1].ToString(),
                OperatorAddress = hostEntry.AddressList[ip - 2].ToString(),
                ExtenalAddress = hostEntry.AddressList[ip - 3].ToString(),
            };

            log.Request = new Request
            {
                Method = httpContext.Request.Method,
                Uri = $"{httpContext.Request.Scheme}://{httpContext.Request.Host}{httpContext.Request.Path}{(httpContext.Request.QueryString.HasValue ? httpContext.Request.QueryString.Value : string.Empty)}",
                UserAgent = httpContext.Request.Headers["User-Agent"],
                Headers = GetHeader(httpContext.Request.Headers),
                Body = GetBody(httpContext.Request),
                Sise = GetSise(httpContext.Request)           
            };

            log.Response = new Response
            {
                StatusCode = (HttpStatusCode)httpContext.Response.StatusCode,
                Headers = GetHeader(httpContext.Response.Headers),
                Sise = GetSise(httpContext.Response)
            };

            return log;            
        }
        private void InsertErrors(Log log, Exception exception)
        {
            var errors = new List<Error>
            {
                new Error
                {
                    Type = exception.GetType().FullName,
                    Message = exception.Message,
                    Tracer = exception.StackTrace
                }
            };

            log.Errors = errors.Count > 0 ? errors : null;
        }
        private void InsertErrors(Log log, IEnumerable<Exception> exceptions)
        {
            var errors = new List<Error>();
            foreach (var exception in exceptions)
            {
                errors.Add(new Error
                {
                    Type = exception.GetType().FullName,
                    Message = exception.Message,
                    Tracer = exception.StackTrace
                });
            }

            log.Errors = errors.Count > 0 ? errors : null;
        }
        private void InsertErrors(Log log, IDictionary<string, string> notifications)
        {
            var errors = new List<Error>();
            foreach (var notification in notifications)
            {
                errors.Add(new Error
                {
                    Type = "notifications",
                    Message = notification.Key,
                    Tracer = notification.Value
                });
            }

            log.Errors = errors.Count > 0 ? errors : null;
        }

        private IDictionary<string, string> GetHeader(IHeaderDictionary headers)
        {
            var result = new Dictionary<string, string>();
            try
            {
                if (!headers.Any()) return null;

                foreach (var header in headers)
                    result.Add(header.Key, header.Value);

                return result;

            }
            catch
            {
                return null;
            }
        }
        private IDictionary<string, string> GetBody(HttpRequest request)
        {
            var form = new Dictionary<string, string>();
            try
            {
                foreach (var item in request.Form)
                    form.Add(item.Key, item.Value);

                try
                {
                    foreach (var file in request.Form.Files)
                    {
                        form.Add(nameof(file.Name), file.Name);
                        form.Add(nameof(file.ContentType), file.ContentType);
                        form.Add(nameof(file.FileName), file.FileName);
                        form.Add(nameof(file.Length), file.Length.ToString());
                    }
                }
                catch { }
                return form;
            }
            catch
            {
                return null;
            }
        }
        private long GetSise(HttpRequest request)
        {
            long sise = 0;
            using (var buffer = new MemoryStream())
            {
                var bodyStream = request.Body;
                request.Body = buffer;

                sise = request.ContentLength ?? buffer.Length;
            }
            return sise;
        }
        private long GetSise(HttpResponse response)
        {
            long sise = 0;
            using (var buffer = new MemoryStream())
            {
                var bodyStream = response.Body;
                response.Body = buffer;

                sise = response.ContentLength ?? buffer.Length;
            }
            return sise;
        }
    }
}
