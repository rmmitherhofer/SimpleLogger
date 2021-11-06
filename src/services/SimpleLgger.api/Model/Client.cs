using SimpleLogger.api.DomainObjects;
using System;

namespace SimpleLogger.api.Model
{
    public class Client : Entity
    {
        public string CpfCnpj { get; private set; }
        public string HostName { get; private set; }
        public string Browser { get; private set; }
        public string OperationSystem { get; private set; }
        public string ClientAdress { get; private set; }
        public string OperatorAddress { get; private set; }
        public string ExternalAddress { get; private set; }
        public Guid LogId { get; private set; }

        //EF Relation
        public Log Log { get; protected set; }

        protected Client() { }
        public Client(string cpfCnpj, string hostName, string browser, string operationSystem, string clientAdress, string operatorAddress, string externalAddress, Guid logId, Log log)
        {
            CpfCnpj = cpfCnpj;
            HostName = hostName;
            Browser = browser;
            OperationSystem = operationSystem;
            ClientAdress = clientAdress;
            OperatorAddress = operatorAddress;
            ExternalAddress = externalAddress;
            LogId = logId;
            Log = log;
        }
    }
}
