using AutoMapper;
using SimpleLogger.api.Application.Queries.ViewModels;
using SimpleLogger.Business.Enums;
using SimpleLogger.Business.Interfaces.Repository;
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
        private readonly IMapper _mapper;
        private readonly IProjectRepository _projectRepository;

        public ProjectQueries(IProjectRepository projectRepository, IMapper mapper)
        {
            _projectRepository = projectRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProjectViewModel>> GetAll()
        {
            return _mapper.Map<IEnumerable<ProjectViewModel>>(await _projectRepository.GetAll());
        }

        public async Task<ProjectViewModel> GetById(Guid id)
        {
            return _mapper.Map<ProjectViewModel>(await _projectRepository.GetById(id));
        }

        public async Task<ProjectViewModel> GetByName(string name)
        {
            return _mapper.Map<ProjectViewModel>(await _projectRepository.GetByName(name));
        }

        public async Task<ProjectViewModel> GetByType(ProjectType type)
        {
            return _mapper.Map<ProjectViewModel>(await _projectRepository.GetByType(type));
        }
    }
}
