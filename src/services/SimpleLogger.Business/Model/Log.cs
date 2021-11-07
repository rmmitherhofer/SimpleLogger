using Core.DomainObjects;
using SimpleLogger.Business.Enums;
using System;
using System.Linq;
using System.Collections.Generic;

namespace SimpleLogger.Business.Model
{
    public class Log : Entity, IAggregateRoot
    {
        public string Path { get; private set; }
        public Level Level { get; private set; }
        public string Type { get; private set; }
        public double TimeProcess { get; private set; }
        public DateTime RegisterDate { get; private set; }
        public StatusLog Status { get; private set; }
        public Guid ProjectId { get; private set; }

        public Client Client { get; private set; }
        public Request Request { get; private set; }
        public Response Response { get; private set; }

        private List<Error> _errors;
        public IReadOnlyCollection<Error> Errors => _errors?.AsReadOnly();

        //EF Relation
        public Project Project { get; protected set; }
        protected Log() { }

        public Log(string path, Level level, string type, double timeProcess, Guid projectId)
        {
            RegisterDate = DateTime.Now;
            Path = path;
            TimeProcess = timeProcess;
            ProjectId = projectId;
            Level = level;
            Type = type;
            Status = StatusLog.Open;
        }

        public void SetClient(Client client)
        {
            Client = client;
        }

        public void SetRequest(Request request)
        {
            Request = request;
        }

        public void SetResponse(Response response)
        {
            Response = response;
        }

        public void SetError(Error error)
        {
            _errors ??= new List<Error>();
            _errors.Add(error);
        }

        public void UpdateStatus(StatusLog status)
        {
            Status = status;
        }

        public void AddReferences()
        {
            if (Client != null)
                Client.AddReferente(Id);

            if (Request != null)
                Request.AddReferente(Id);

            if (Response != null)
                Response.AddReferente(Id);

            if (Errors?.Count > 0)
                Errors.ToList().ForEach(e => e.AddReferente(Id, ProjectId));
        }
    }
}
