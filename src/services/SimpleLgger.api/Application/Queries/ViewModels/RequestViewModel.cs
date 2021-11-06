using SimpleLogger.Business.Enums;
using System;
using System.Collections.Generic;
using System.Net;

namespace SimpleLogger.api.Application.Queries.ViewModels
{

    public class RequestViewModel
    {
        public string Method { get; set; }
        public string Uri { get; set; }
        public string UserAgent { get; set; }
        public IDictionary<string, string> Headers { get; set; }
        public IDictionary<string, string> Body { get; set; }
        public decimal Sise { get; set; }
    }
}
