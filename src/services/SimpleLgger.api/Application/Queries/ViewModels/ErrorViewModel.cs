using SimpleLogger.Business.Enums;
using System;
using System.Collections.Generic;
using System.Net;

namespace SimpleLogger.api.Application.Queries.ViewModels
{

    public class ErrorViewModel
    {
        public string Type { get; set; }
        public string Message { get; set; }
        public string Tracer { get; set; }
    }
}
