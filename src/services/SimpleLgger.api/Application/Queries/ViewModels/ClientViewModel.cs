using SimpleLogger.Business.Enums;
using System;
using System.Collections.Generic;
using System.Net;

namespace SimpleLogger.api.Application.Queries.ViewModels
{
    public class ClientViewModel
    {
        public Guid Id { get; set; }
        public string HostName { get; set; }
        public string UserAgent { get; set; }
        public string Browser { get; set; }
        public string OperationSystem { get; set; }
        public string ClientAddress { get; set; }
        public string OperatorAddress { get; set; }
        public string ExternalAddress { get; set; }
    }
}
