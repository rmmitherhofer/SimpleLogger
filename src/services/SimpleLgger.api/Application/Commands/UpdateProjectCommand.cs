using Core.Messages;
using FluentValidation;
using SimpleLogger.Business.Enums;
using System;

namespace SimpleLogger.api.Application.Commands
{
    public class UpdateProjectCommand : Command
    {
        public Guid Id { get; private set; }
        public ProjectType ProjectType { get; private set; }
        public string Name { get; private set; }

        public UpdateProjectCommand(Guid id, ProjectType projectType, string name)
        {
            Id = id;
            ProjectType = projectType;
            Name = name;
        }

        public override bool IsValid()
        {
            ValidationResult = new UpdateProjectValidation().Validate(this);
            return ValidationResult.IsValid;
        }

        public class UpdateProjectValidation : AbstractValidator<UpdateProjectCommand>
        {
            public UpdateProjectValidation()
            {
                RuleFor(p => p.Id)
                    .NotEqual(Guid.Empty)
                    .WithMessage("O id do projeto não foi informado");

                RuleFor(p => p.ProjectType)
                    .NotEmpty()
                    .WithMessage("O tipo de projeto não foi informado");

                RuleFor(p => p.Name)
                    .NotEmpty()
                    .WithMessage("Nome do projeto não foi informado");
            }
        }
    }
}
