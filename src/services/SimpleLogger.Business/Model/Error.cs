using Core.DomainObjects;
using System;

namespace SimpleLogger.Business.Model
{
    public class Error : Entity
    {
        public string Type { get; private set; }
        public string Message { get; private set; }
        public string Tracer { get; private set; }
        public Guid LogId { get; private set; }
        public Guid ProjectId { get; private set; }

        //EF Relation
        public Log Log { get; protected set; }
        public Project Project { get; protected set; }

        protected Error() { }
        public Error(string type, string message, string tracer)
        {
            Type = type;
            Message = message;
            Tracer = tracer;
        }

        public void AddReferente(Guid logId, Guid projectId)
        {
            LogId = logId;
            ProjectId = projectId;
        }
    }
}
