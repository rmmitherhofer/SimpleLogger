using SimpleLogger.api.DomainObjects;
using System;

namespace SimpleLogger.api.Model
{
    public class Request : Entity
    {
        public string Method { get; private set; }
        public string Uri { get; private set; }
        public string UserAgent { get; private set; }
        public string Headers { get; private set; }
        public string Form { get; private set; }
        public string Sise { get; private set; }
        public Guid LogId { get; private set; }

        //EF Relation
        public Log Log { get; protected set; }
        protected Request() { }
        public Request(string method, string uri, string userAgent, string headers, string form, string sise)
        {
            Method = method;
            Uri = uri;
            UserAgent = userAgent;
            Headers = headers;
            Form = form;
            Sise = sise;
        }
    }
}
