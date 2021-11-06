using Core.Messages;
using FluentValidation.Results;
using MediatR;
using SimpleLogger.api.Application.Events;
using SimpleLogger.Business.Interfaces.Repository;
using SimpleLogger.Business.Model;
using System.Threading;
using System.Threading.Tasks;

namespace SimpleLogger.api.Application.Commands.Handler
{
    public class ProjectCommandHandler : CommandHandler, IRequestHandler<InsertProjectCommand, ValidationResult>
    {
        private readonly IProjectRepository _projectRepository;

        public ProjectCommandHandler(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }
        public async Task<ValidationResult> Handle(InsertProjectCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid())
                return request.ValidationResult;

            var project = await _projectRepository.GetByName(request.Name);


            if (project == null)
            {
                project = new Project(request.Type, request.Name);
                _projectRepository.Insert(project);

                project.AddEvent(new RegisteredProjectEvent(project.Id, project.Type, project.Name));
            }

            return await Commit(_projectRepository.UnitOfWork);
        }
    }
}
