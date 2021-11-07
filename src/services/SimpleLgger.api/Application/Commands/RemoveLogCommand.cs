using Core.Messages;
using FluentValidation;
using System;

namespace SimpleLogger.api.Application.Commands
{
    public class RemoveLogCommand : Command
    {
        public Guid Id { get; private set; }

        public RemoveLogCommand(Guid id)
        {
            Id = id;
        }

        public override bool IsValid()
        {
            ValidationResult = new RemoveLogValidation().Validate(this);
            return ValidationResult.IsValid;
        }

        public class RemoveLogValidation : AbstractValidator<RemoveLogCommand>
        {
            public RemoveLogValidation()
            {
                RuleFor(l => l.Id)
                    .NotEqual(Guid.Empty)
                    .WithMessage("O id do log não foi informado");
            }
        }
    }
}
