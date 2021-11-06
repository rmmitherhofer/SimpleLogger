using SimpleLogger.api.Application.Queries.ViewModels;
using SimpleLogger.Business.Enums;
using SimpleLogger.Business.Interfaces.Repository;
using SimpleLogger.Business.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SimpleLogger.api.Application.Queries
{
    public interface IProjectQueries
    {
        Task<IEnumerable<ProjectViewModel>> GetAll();
        Task<ProjectViewModel> GetById(Guid id);
        Task<ProjectViewModel> GetByName(string name);
        Task<ProjectViewModel> GetByType(ProjectType type);
    }

    public class ProjectQueries : IProjectQueries
    {
        private readonly IProjectRepository _projectRepository;

        public ProjectQueries(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }

        public async Task<IEnumerable<ProjectViewModel>> GetAll()
        {
            return ToViewModel(await _projectRepository.GetAll());
        }

        public async Task<ProjectViewModel> GetById(Guid id)
        {
            return ToViewModel(await _projectRepository.GetById(id));
        }

        public async Task<ProjectViewModel> GetByName(string name)
        {
            return ToViewModel(await _projectRepository.GetByName(name));
        }

        public async Task<ProjectViewModel> GetByType(ProjectType type)
        {
            return ToViewModel(await _projectRepository.GetByType(type));
        }

        private ProjectViewModel ToViewModel(Project project)
        {
            if (project == null) return null;

            return new ProjectViewModel
            {
                Id = project.Id,
                Type = project.Type,
                Name = project.Name
            };
        }

        private IEnumerable<ProjectViewModel> ToViewModel(IEnumerable<Project> projects)
        {
            var projectsViewModel = new List<ProjectViewModel>();
            foreach (var project in projects)
            {
                projectsViewModel.Add(ToViewModel(project));
            }

            return projectsViewModel;
        }
    }
}
