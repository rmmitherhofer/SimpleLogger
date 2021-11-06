using Core.DomainObjects;
using SimpleLogger.Business.Enums;
using System.Collections.Generic;

namespace SimpleLogger.Business.Model
{
    public class Project : Entity, IAggregateRoot
    {
        public ProjectType Type { get; private set; }
        public string Name { get; private set; }
        public IEnumerable<Log> Logs { get; private set; }

        //EF Relation
        protected Project() { }

        public Project(ProjectType type, string name)
        {
            Type = type;
            Name = name;
        }
    }
}
