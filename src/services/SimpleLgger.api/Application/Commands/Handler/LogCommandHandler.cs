using FluentValidation.Results;
using MediatR;
using SimpleLogger.api.Model;
using System.Threading;
using System.Threading.Tasks;

namespace SimpleLogger.api.Application.Commands.Handler
{
    public class LogCommandHandler : IRequestHandler<InsertLogCommand, ValidationResult>
    {
        public async Task<ValidationResult> Handle(InsertLogCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid())
                return request.ValidationResult;

            var log = new Log(request.Path, request.TimeProcess, request.ProjectId);

            //Registrar no Banco

            return null;
        }
    }
}
