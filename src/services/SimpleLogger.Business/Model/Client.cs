using Core.DomainObjects;
using System;
using UAParser;

namespace SimpleLogger.Business.Model
{
    public class Client : Entity
    {
        public string HostName { get; private set; }
        public string Browser { get; private set; }
        public string OperationSystem { get; private set; }
        public string ClientAddress { get; private set; }
        public string OperatorAddress { get; private set; }
        public string ExternalAddress { get; private set; }
        public Guid LogId { get; private set; }

        //EF Relation
        public Log Log { get; protected set; }

        protected Client() { }
        public Client(string hostName, string userAgent, string clientAddress, string operatorAddress, string externalAddress)
        {
            if (!string.IsNullOrEmpty(userAgent))
            {
                var uaParser = Parser.GetDefault();
                var clientInfo = uaParser.Parse(userAgent);

                Browser = clientInfo.UA.ToString();
                OperationSystem = clientInfo.OS.ToString();
            }

            HostName = hostName;
            ClientAddress = clientAddress;
            OperatorAddress = operatorAddress;
            ExternalAddress = externalAddress;
        }

        public void AddReferente(Guid logId)
        {
            LogId = logId;
        }
    }
}
