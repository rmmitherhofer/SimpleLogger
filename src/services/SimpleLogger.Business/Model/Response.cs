using Core.DomainObjects;
using System;
using System.Net;

namespace SimpleLogger.Business.Model
{
    public class Response: Entity
    {
        public HttpStatusCode StatusCode { get; private set; }
        public string Headers { get; private set; }
        public decimal Sise { get; private set; }
        public Guid LogId { get; private set; }

        //EF Relation
        public Log Log { get; protected set; }
        protected Response() { }
        public Response(HttpStatusCode statusCode, string headers, decimal sise)
        {
            StatusCode = statusCode;
            Headers = headers;
            Sise = sise;
        }

        public void AddReferente(Guid logId)
        {
            LogId = logId;
        }
    }
}
