using FluentValidation;
using SimpleLogger.api.Messages;
using System;

namespace SimpleLogger.api.Application.Commands
{
    public class InsertLogCommand : Command
    {
        public Guid Id { get; private set; }
        public string Path { get; private set; }
        public double TimeProcess { get; private set; }
        public Guid ProjectId { get; private set; }


        public InsertLogCommand(Guid id, string path, double timeProcess, Guid projectId)
        {
            Id = id;
            Path = path;
            TimeProcess = timeProcess;
            ProjectId = projectId;
        }

        public override bool IsValid()
        {
            ValidationResult = new InsertLogValidation().Validate(this);
            return ValidationResult.IsValid;
        }

        public class InsertLogValidation : AbstractValidator<InsertLogCommand>
        {
            public InsertLogValidation()
            {
                RuleFor(l => l.Id)
                    .NotEqual(Guid.Empty)
                    .WithMessage("Id do log inválido");

                RuleFor(l => l.Path)
                    .NotEmpty()
                    .WithMessage("O path não foi informado");

                RuleFor(l => l.Id)
                    .NotEqual(Guid.Empty)
                    .WithMessage("Id do projeto não foi informado");
            }
        }
    }
}
