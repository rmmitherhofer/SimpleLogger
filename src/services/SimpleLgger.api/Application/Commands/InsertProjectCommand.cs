using Core.Messages;
using FluentValidation;
using SimpleLogger.Business.Enums;

namespace SimpleLogger.api.Application.Commands
{
    public class InsertProjectCommand : Command
    {
        public ProjectType ProjectType { get; private set; }
        public string Name { get; private set; }

        public InsertProjectCommand(ProjectType projectType, string name)
        {
            ProjectType = projectType;
            Name = name;
        }

        public override bool IsValid()
        {
            ValidationResult = new InsertProjectValidation().Validate(this);
            return ValidationResult.IsValid;
        }

        public class InsertProjectValidation : AbstractValidator<InsertProjectCommand>
        {
            public InsertProjectValidation()
            {
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
