using Core.Messages;
using System;

namespace SimpleLogger.api.Application.Events
{
    public class RemovedProjectEvent : Event
    {
        public Guid Id { get; private set; }

        public RemovedProjectEvent(Guid id)
        {
            AggregateId = id;
            Id = id;
        }
    }
}
