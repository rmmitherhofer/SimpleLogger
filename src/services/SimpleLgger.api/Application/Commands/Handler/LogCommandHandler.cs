using AutoMapper;
using Core.Messages;
using FluentValidation.Results;
using MediatR;
using SimpleLogger.api.Application.Events;
using SimpleLogger.api.Application.Queries.ViewModels;
using SimpleLogger.Business.Interfaces.Repository;
using SimpleLogger.Business.Model;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using UAParser;
using WebAPI.Core.Extensions;

namespace SimpleLogger.api.Application.Commands.Handler
{
    public class LogCommandHandler : CommandHandler, IRequestHandler<InsertLogCommand, ValidationResult>
    {
        private readonly ILogRepository _logRepository;
        private readonly IMapper _mapper;

        public LogCommandHandler(ILogRepository logRepository, IMapper mapper)
        {
            _logRepository = logRepository;
            _mapper = mapper;
        }

        public async Task<ValidationResult> Handle(InsertLogCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid())
                return request.ValidationResult;

            var log = _mapper.Map<Log>(request.Log);

            log.SetClient(_mapper.Map<Client>(request.Log.Client));
            log.SetRequest(_mapper.Map<Request>(request.Log.Request));
            log.SetResponse(_mapper.Map<Response>(request.Log.Response));

            foreach (var error in _mapper.Map<IEnumerable<Error>>(request.Log.Errors))
            {
                log.SetError(error);
            }

            log.AddReferences();

            _logRepository.Insert(log);
            log.AddEvent(new RegisteredLogEvent());

            return await Commit(_logRepository.UnitOfWork);
        }
    }
}
