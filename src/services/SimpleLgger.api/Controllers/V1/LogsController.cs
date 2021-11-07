using Core.Mediator;
using Microsoft.AspNetCore.Mvc;
using SimpleLogger.api.Application.Commands;
using SimpleLogger.api.Application.Queries;
using SimpleLogger.api.Application.Queries.ViewModels;
using SimpleLogger.Business.Enums;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApi.Core.Controllers;

namespace SimpleLogger.api.Controllers.V1
{
    [Route("api/logs")]
    public class LogsController : MainController
    {
        private readonly IMediatorHandler _mediatorHandler;
        private readonly IProjectQueries _projectQueries;
        private readonly ILogQueries _logQueries;

        public LogsController(IMediatorHandler mediatorHandler, IProjectQueries projectQueries, ILogQueries logQueries = null)
        {
            _mediatorHandler = mediatorHandler;
            _projectQueries = projectQueries;
            _logQueries = logQueries;
        }

        [HttpGet]
        public async Task<IEnumerable<LogViewModel>> Get()
        {
            return await _logQueries.GetAll();
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] LogViewModel log)
        {
            var project = await _projectQueries.GetById(log.ProjectId);

            if (project == null)
            {
                AddErrorProcess("Projeto não encontrado");
                CustomResponse();
            }

            var result = await _mediatorHandler.Send(new InsertLogCommand(log));

            return CustomResponse(result);
        }

        [HttpPut("{id:guid}/{status}")]
        public async Task<IActionResult> Put(Guid id, StatusLog status)
        {
            var result = await _mediatorHandler.Send(new UpdateLogCommand(id, status));

            return CustomResponse(result);
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Post(Guid id)
        {
            var result = await _mediatorHandler.Send(new RemoveLogCommand(id));

            return CustomResponse(result);
        }
    }
}
