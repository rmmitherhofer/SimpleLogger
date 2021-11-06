using System.Collections.Generic;

namespace SimpleLogger.Models
{
    public class Request
    {
        public string Method { get; set; }
        public string Uri { get; set; }
        public string UserAgent { get; set; }
        public IDictionary<string, string> Headers { get; set; }
        public IDictionary<string, string> Body { get; set; }
        public long Sise { get; set; }
    }
}
