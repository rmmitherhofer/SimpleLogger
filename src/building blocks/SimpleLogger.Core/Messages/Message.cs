using System;

namespace Core.Messages
{
    public abstract class Message
    {
        public string Type { get; protected set; }
        public Guid AggregateId { get; protected set; }

        public Message()
        {
            Type = GetType().Name;
        }
    }
}
