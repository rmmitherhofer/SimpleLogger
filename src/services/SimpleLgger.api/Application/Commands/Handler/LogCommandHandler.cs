using AutoMapper;
using Core.Messages;
using FluentValidation.Results;
using MediatR;
using SimpleLogger.api.Application.Events;
using SimpleLogger.Business.Interfaces.Repository;
using SimpleLogger.Business.Model;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace SimpleLogger.api.Application.Commands.Handler
{
    public class LogCommandHandler : CommandHandler, 
        IRequestHandler<InsertLogCommand, ValidationResult>,
        IRequestHandler<UpdateLogCommand, ValidationResult>,
        IRequestHandler<RemoveLogCommand, ValidationResult>
    {
        private readonly ILogRepository _logRepository;
        private readonly IMapper _mapper;

        public LogCommandHandler(ILogRepository logRepository, IMapper mapper)
        {
            _logRepository = logRepository;
            _mapper = mapper;
        }

        public async Task<ValidationResult> Handle(InsertLogCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid())
                return message.ValidationResult;

            var log = _mapper.Map<Log>(message.Log);

            log.SetClient(_mapper.Map<Client>(message.Log.Client));
            log.SetRequest(_mapper.Map<Request>(message.Log.Request));
            log.SetResponse(_mapper.Map<Response>(message.Log.Response));

            foreach (var error in _mapper.Map<IEnumerable<Error>>(message.Log.Errors))
            {
                log.SetError(error);
            }

            log.AddReferences();

            _logRepository.Insert(log);
            log.AddEvent(new RegisteredLogEvent());

            return await Commit(_logRepository.UnitOfWork);
        }

        public async Task<ValidationResult> Handle(UpdateLogCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid())
                return message.ValidationResult;

            var log = await _logRepository.GetById(message.Id);

            if (log == null)
            {
                AddError("Log não encontrado");
                return ValidationResult;
            }

            log.UpdateStatus(message.Status);

            _logRepository.Update(log);
            log.AddEvent(new UpdatedLogEvent(message.Id, message.Status));

            return await Commit(_logRepository.UnitOfWork);
        }

        public async Task<ValidationResult> Handle(RemoveLogCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid())
                return message.ValidationResult;

            var log = await _logRepository.GetById(message.Id);

            if (log == null)
            {
                AddError("Log não encontrado");
                return ValidationResult;
            }

            _logRepository.Remove(log);
            log.AddEvent(new RemovedLogEvent(message.Id));

            return await Commit(_logRepository.UnitOfWork);
        }
    }
}
