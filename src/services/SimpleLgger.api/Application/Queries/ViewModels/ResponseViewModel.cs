using SimpleLogger.Business.Enums;
using System;
using System.Collections.Generic;
using System.Net;

namespace SimpleLogger.api.Application.Queries.ViewModels
{

    public class ResponseViewModel
    {
        public HttpStatusCode StatusCode { get; set; }
        public IDictionary<string, string> Headers { get; set; }
        public decimal Sise { get; set; }
    }
}
