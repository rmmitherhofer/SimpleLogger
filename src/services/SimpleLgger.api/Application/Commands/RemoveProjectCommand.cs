using Core.Messages;
using FluentValidation;
using System;

namespace SimpleLogger.api.Application.Commands
{
    public class RemoveProjectCommand : Command
    {
        public Guid Id { get; private set; }

        public RemoveProjectCommand(Guid id)
        {
            Id = id;
        }

        public override bool IsValid()
        {
            ValidationResult = new RemoveProjectValidation().Validate(this);
            return ValidationResult.IsValid;
        }

        public class RemoveProjectValidation : AbstractValidator<RemoveProjectCommand>
        {
            public RemoveProjectValidation()
            {
                RuleFor(p => p.Id)
                    .NotEqual(Guid.Empty)
                    .WithMessage("O id do projeto não foi informado");
            }
        }
    }
}
