using System.Collections.Generic;
using System.Net;

namespace SimpleLogger.Models
{
    public class Response
    {
        public HttpStatusCode StatusCode { get; set; }
        public IDictionary<string, string> Headers { get; set; }
        public long Sise { get; set; }
    }
}
