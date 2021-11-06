using SimpleLogger.Business.Enums;
using System;
using System.Collections.Generic;
using System.Net;

namespace SimpleLogger.api.Application.Queries.ViewModels
{

    public class ProjectViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public ProjectType Type { get; set; }
    }
}
