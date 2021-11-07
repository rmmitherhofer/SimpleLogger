using AutoMapper;
using SimpleLogger.api.Application.Queries.ViewModels;
using SimpleLogger.Business.Enums;
using SimpleLogger.Business.Interfaces.Repository;
using SimpleLogger.Business.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Core.Extensions;

namespace SimpleLogger.api.Application.Queries
{
    public interface ILogQueries
    {
        Task<IEnumerable<LogViewModel>> GetAll();
        Task<LogViewModel> GetById(Guid id);
        Task<LogViewModel> GetByDate(string name);
        Task<LogViewModel> GetByProjectName(string name);
        Task<LogViewModel> GetByProjectType(ProjectType type);
    }

    public class LogQueries : ILogQueries
    {
        private readonly ILogRepository _logRepository;
        private readonly IMapper _mapper;

        public LogQueries(ILogRepository logRepository, IMapper mapper)
        {
            _logRepository = logRepository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<LogViewModel>> GetAll()
        {
            return _mapper.Map<IEnumerable<LogViewModel>>(await _logRepository.GetAll());
        }

        public Task<LogViewModel> GetByDate(string name)
        {
            throw new NotImplementedException();
        }

        public Task<LogViewModel> GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<LogViewModel> GetByProjectName(string name)
        {
            throw new NotImplementedException();
        }

        public Task<LogViewModel> GetByProjectType(ProjectType type)
        {
            throw new NotImplementedException();
        }
    }
}
