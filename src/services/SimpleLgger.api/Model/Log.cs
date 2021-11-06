using SimpleLogger.api.DomainObjects;
using System;
using System.Collections.Generic;

namespace SimpleLogger.api.Model
{
    public class Log : Entity
    {
        public DateTime RegisterDate { get; private set; }
        public string Path { get; private set; }
        public double TimeProcess { get; private set; }
        public Guid ProjectId { get; private set; }
        
        public Client Client { get; private set; }
        public Request Request { get; private set; }
        public Response Response { get; private set; }
        public IEnumerable<Error> Errors { get; private set; }

        //EF Relation
        public Project Project { get; protected set; }
        protected Log() { }

        public Log(string path, double timeProcess, Guid projectId)
        {
            RegisterDate = DateTime.Now;
            Path = path;
            TimeProcess = timeProcess;
            ProjectId = projectId;
        }

        public void SetClient(Client client)
        {
            Client = client;
        }

        public void SetRequest(Request request)
        {
            Request = request;
        }

        public void SetRequest(Response response)
        {
            Response = response;
        }

        //public void SetRequest(Error errors)
        //{
        //    Errors = errors;
        //}
    }
}
