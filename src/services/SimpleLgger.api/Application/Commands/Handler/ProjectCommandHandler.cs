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
    public class ProjectCommandHandler : CommandHandler,
        IRequestHandler<InsertProjectCommand, ValidationResult>,
        IRequestHandler<UpdateProjectCommand, ValidationResult>,
        IRequestHandler<RemoveProjectCommand, ValidationResult>
    {
        private readonly IProjectRepository _projectRepository;

        public ProjectCommandHandler(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }
        public async Task<ValidationResult> Handle(InsertProjectCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid())
                return message.ValidationResult;

            var project = await _projectRepository.GetByName(message.Name);

            if (project == null)
            {
                project = new Project(message.ProjectType, message.Name);
                _projectRepository.Insert(project);

                project.AddEvent(new RegisteredProjectEvent(project.Id, project.Type, project.Name));
            }

            return await Commit(_projectRepository.UnitOfWork);
        }

        public async Task<ValidationResult> Handle(UpdateProjectCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid())
                return message.ValidationResult;

            var project = await _projectRepository.GetById(message.Id);

            if (project == null)
            {
                AddError("Projeto não encontrado");
                return ValidationResult;
            }

            project.Update(message.ProjectType, message.Name);

            _projectRepository.Update(project);

            project.AddEvent(new UpdatedProjectEvent(project.Id, project.Type, project.Name));

            return await Commit(_projectRepository.UnitOfWork);
        }

        public async Task<ValidationResult> Handle(RemoveProjectCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid())
                return message.ValidationResult;

            var project = await _projectRepository.GetById(message.Id);

            if (project == null)
            {
                AddError("Projeto não encontrado");
                return ValidationResult;
            }

            _projectRepository.Remove(project);

            //Remover todos os Logs Vinculados;

            project.AddEvent(new RemovedProjectEvent(project.Id));

            return await Commit(_projectRepository.UnitOfWork);
        }
    }
}
