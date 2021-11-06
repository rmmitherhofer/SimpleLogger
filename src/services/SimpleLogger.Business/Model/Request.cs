using Core.DomainObjects;
using System;

namespace SimpleLogger.Business.Model
{
    public class Request : Entity
    {
        public string Method { get; private set; }
        public string Uri { get; private set; }
        public string UserAgent { get; private set; }
        public string Headers { get; private set; }
        public string Body { get; private set; }
        public decimal Sise { get; private set; }
        public Guid LogId { get; private set; }

        //EF Relation
        public Log Log { get; protected set; }
        protected Request() { }
        public Request(string method, string uri, string userAgent, string headers, string body, decimal sise)
        {
            Method = method;
            Uri = uri;
            UserAgent = userAgent;
            Headers = headers;
            Body = body;
            Sise = sise;
        }

        public void AddReferente(Guid logId)
        {
            LogId = logId;
        }
    }
}
