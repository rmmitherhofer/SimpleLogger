using SimpleLogger.api.DomainObjects;
using SimpleLogger.api.Enums;
using System.Collections.Generic;

namespace SimpleLogger.api.Model
{
    public class Project : Entity
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
