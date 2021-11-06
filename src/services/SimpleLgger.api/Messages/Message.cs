using System;

namespace SimpleLogger.api.Messages
{
    public abstract class Message
    {
        public string Type { get; private set; }
        public Guid AggregateId { get; private set; }

        public Message()
        {
            Type = GetType().Name;
        }
    }
}
