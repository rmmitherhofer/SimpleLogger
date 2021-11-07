using Core.Messages;
using FluentValidation;
using SimpleLogger.Business.Enums;
using System;

namespace SimpleLogger.api.Application.Commands
{
    public class UpdateLogCommand : Command
    {
        public Guid Id { get; private set; }
        public StatusLog Status { get; private set; }

        public UpdateLogCommand(Guid id, StatusLog status)
        {
            Id = id;
            Status = status;
        }

        public override bool IsValid()
        {
            ValidationResult = new UpdateLogValidation().Validate(this);
            return ValidationResult.IsValid;
        }

        public class UpdateLogValidation : AbstractValidator<UpdateLogCommand>
        {
            public UpdateLogValidation()
            {
                RuleFor(l => l.Id)
                    .NotEqual(Guid.Empty)
                    .WithMessage("O id do log não foi informado");

                RuleFor(l => l.Status)
                    .NotEqual(StatusLog.Open)
                    .WithMessage("O status deve ser diferente de aberto");
            }
        }
    }
}
