using Core.Messages;
using SimpleLogger.Business.Enums;
using System;

namespace SimpleLogger.api.Application.Events
{
    public class UpdatedLogEvent : Event
    {
        public Guid Id { get; private set; }
        public StatusLog Status { get; private set; }

        public UpdatedLogEvent(Guid id, StatusLog status)
        {
            AggregateId = id;
            Id = id;
            Status = status;
        }
    }
}
