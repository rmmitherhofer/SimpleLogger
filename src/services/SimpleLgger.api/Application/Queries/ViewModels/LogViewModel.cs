using SimpleLogger.Business.Enums;
using System;
using System.Collections.Generic;
using System.Net;

namespace SimpleLogger.api.Application.Queries.ViewModels
{

    public class LogViewModel
    {
        public Guid Id { get; set; }
        public string Path { get; set; }
        public double TimeProcess { get; set; }
        public Level Level { get; set; }
        public DateTime RegisterDate { get; set; }
        public Guid ProjectId { get; set; }
        public ProjectViewModel Project { get; set; }
        public ClientViewModel Client { get; set; }
        public RequestViewModel Request { get; set; }
        public ResponseViewModel Response { get; set; }

        public string Type { get; set; }
        public IEnumerable<ErrorViewModel> Errors { get; set; }
    }
}
