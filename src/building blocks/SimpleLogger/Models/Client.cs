using System;

namespace SimpleLogger.Models
{
    public class Client
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string HostName { get; set; }
        public string UserAgent { get; set; }
        public string ClientAddress { get; set; }
        public string OperatorAddress { get; set; }
        public string ExtenalAddress { get; set; }
    }
}
