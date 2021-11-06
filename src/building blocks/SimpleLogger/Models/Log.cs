using System.Collections.Generic;

namespace SimpleLogger.Models
{
    public class Log
    {
        public string Path { get; set; }
        public string Timer { get; set; }
        public Project Project { get; set; }
        public Client Client { get; set; }
        public Request Request { get; set; }
        public Response Response { get; set; }
        public string Type { get; set; }
        public IEnumerable<Error> Errors { get; set; }
    }
}
