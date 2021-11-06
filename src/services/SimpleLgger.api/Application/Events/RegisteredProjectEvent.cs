using Core.Messages;
using SimpleLogger.Business.Enums;
using System;

namespace SimpleLogger.api.Application.Events
{
    public class RegisteredProjectEvent : Event
    {
        public Guid Id { get; private set; }
        public ProjectType ProjectType { get; private set; }
        public string Name { get; private set; }

        public RegisteredProjectEvent(Guid id, ProjectType projectType, string name)
        {
            AggregateId = id;
            Id = id;
            ProjectType = projectType;
            Name = name;
        }
    }
}
