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
    [Route("api/projects")]
    public class ProjectsController : MainController
    {
        private readonly IMediatorHandler _mediatorHandler;
        private readonly IProjectQueries _projectQueries;

        public ProjectsController(IMediatorHandler mediatorHandler, IProjectQueries projectQueries)
        {
            _mediatorHandler = mediatorHandler;
            _projectQueries = projectQueries;
        }

        [HttpGet]
        public async Task<IEnumerable<ProjectViewModel>> Get()
        {
            return await _projectQueries.GetAll();
        }

        [HttpGet("{id:guid}")]
        public async Task<ProjectViewModel> Get(Guid id)
        {
            return await _projectQueries.GetById(id);
        }

        [HttpGet("{name}")]
        public async Task<ProjectViewModel> Get(string name)
        {
            return await _projectQueries.GetByName(name);
        }

        [HttpGet("{type:int}")]
        public async Task<ProjectViewModel> Get(ProjectType type)
        {
            return await _projectQueries.GetByType(type);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ProjectViewModel project)
        {
            var existingProject = await _projectQueries.GetByName(project.Name);

            if (existingProject != null)
            {
                CustomResponse(existingProject);
            }

            var result = await _mediatorHandler.Send(new InsertProjectCommand(project.Type, project.Name));

            return CustomResponse(result);
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Put(Guid id, [FromBody] ProjectViewModel project)
        {
            var existingProject = await _projectQueries.GetById(id);

            if (existingProject == null)
            {
                AddErrorProcess("Projeto não localizado");
                CustomResponse();
            }

            var result = await _mediatorHandler.Send(new InsertProjectCommand(project.Type, project.Name));

            return CustomResponse();
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var project = await _projectQueries.GetById(id);

            if (project == null)
            {
                AddErrorProcess("Projeto não localizado");
                CustomResponse();
            }

            //var result = await _mediatorHandler.Send(new InsertProjectCommand(project.Type, project.Name));

            return CustomResponse();
        }
    }
}
