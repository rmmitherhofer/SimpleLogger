using FluentValidation.Results;
using MediatR;
using System;

namespace SimpleLogger.api.Messages
{
    public abstract class Command : Message, IRequest<ValidationResult> 
    {
        public DateTime  TimeStamp { get; set; }
        public ValidationResult ValidationResult { get; set; }

        protected Command()
        {
            TimeStamp = DateTime.Now;
        }

        public virtual bool IsValid()
        {
            throw new NotImplementedException();
        }
    }
}
