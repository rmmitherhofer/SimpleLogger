using Core.Messages;
using FluentValidation;
using SimpleLogger.api.Application.Queries.ViewModels;
using System;

namespace SimpleLogger.api.Application.Commands
{
    public class InsertLogCommand : Command
    {
        public LogViewModel Log { get; private set; }

        public InsertLogCommand(LogViewModel log)
        {
            Log = log;
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
                RuleFor(l => l.Log.Path)
                    .NotEmpty()
                    .WithMessage("O path não foi informado");

                RuleFor(l => l.Log.Type)
                    .NotEmpty()
                    .WithMessage("O tipo de erro não foi informado");

                RuleFor(l => l.Log.Level)
                    .NotEmpty()
                    .WithMessage("O nivel de criticidade não foi informado");

                RuleFor(l => l.Log.ProjectId)
                    .NotEqual(Guid.Empty)
                    .WithMessage("Id do projeto não foi informado");

                RuleFor(l => l.Log.Client.HostName)
                    .NotEmpty()
                    .WithMessage("HostName do Cliente não foi informado");

                RuleFor(l => l.Log.Request.Method)
                    .NotEmpty()
                    .WithMessage("Método da requisição não foi informado");

                RuleFor(l => l.Log.Request.Uri)
                    .NotEmpty()
                    .WithMessage("Endereço da requisição não foi informado");

                RuleFor(l => l.Log.Request.UserAgent)
                   .NotEmpty()
                   .WithMessage("Agente de navegação não foi informado");

                RuleFor(l => l.Log.Response.StatusCode)
                   .NotEmpty()
                   .WithMessage("Codigo de resposta não foi informado");

                RuleFor(l => l.Log.Errors)
                   .NotNull()
                   .WithMessage("O detalhes dos erros não foram informados");
            }
        }
    }
}
