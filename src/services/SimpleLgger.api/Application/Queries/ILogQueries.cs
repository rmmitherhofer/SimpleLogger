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

        private IEnumerable<LogViewModel> ToViewModel(IEnumerable<Log> logs)
        {
            var logsViewModel = new List<LogViewModel>();

            foreach (var log in logs)
            {
                logsViewModel.Add(ToViewModel(log));
            }

            return logsViewModel;
        }

        private LogViewModel ToViewModel(Log log)
        {
            return new LogViewModel
            {
                Id = log.Id,
                Path = log.Path,
                Level = log.Level,
                Type = log.Type,
                TimeProcess = log.TimeProcess,
                RegisterDate = log.RegisterDate,
                ProjectId = log.ProjectId,
                Project = ToViewModel(log.Project),
                Client = ToViewModel(log.Client),
                Request = ToViewModel(log.Request),
                Response = ToViewModel(log.Response),
                Errors = ToViewModel(log.Errors)
            };
        }
        private ProjectViewModel ToViewModel(Project project)
        {
            return new ProjectViewModel
            {
                Id = project.Id,
                Name = project.Name,
                Type = project.Type
            };
        }
        private ClientViewModel ToViewModel(Client client)
        {
            return new ClientViewModel
            {
                HostName = client.HostName,
                Browser = client.Browser,
                OperationSystem = client.OperationSystem,
                ClientAddress = client.ClientAddress,
                OperatorAddress = client.OperatorAddress,
                ExternalAddress = client.ExternalAddress
            };
        }
        private RequestViewModel ToViewModel(Request request)
        {
            return new RequestViewModel
            {
                Method = request.Method,
                Uri = request.Uri,
                UserAgent = request.UserAgent,
                Headers = request.Headers.ToDictionary(),
                Body = request.Body.ToDictionary(),
                Sise = request.Sise
            };
        }
        private ResponseViewModel ToViewModel(Response response)
        {
            return new ResponseViewModel
            {
                StatusCode = response.StatusCode,
                Sise = response.Sise,
                Headers = response.Headers.ToDictionary()
            };
        }
        private IEnumerable<ErrorViewModel> ToViewModel(IEnumerable<Error> errors)
        {
            var errorsViewModel = new List<ErrorViewModel>();
            foreach (var error in errors)
            {
                errorsViewModel.Add(ToViewModel(error));
            }
            return errorsViewModel;
        }
        private ErrorViewModel ToViewModel(Error error)
        {
            return new ErrorViewModel
            {
                Message = error.Message,
                Type = error.Type,
                Tracer = error.Tracer
            };
        }
    }
}
