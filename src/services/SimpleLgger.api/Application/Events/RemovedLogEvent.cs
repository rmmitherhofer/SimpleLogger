using Core.Messages;
using System;

namespace SimpleLogger.api.Application.Events
{
    public class RemovedLogEvent : Event
    {
        public Guid Id { get; private set; }

        public RemovedLogEvent(Guid id)
        {
            AggregateId = id;
            Id = id;
        }
    }
}
