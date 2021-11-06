using AutoMapper;
using SimpleLogger.api.Application.Queries.ViewModels;
using SimpleLogger.Business.Model;
using WebAPI.Core.Extensions;

namespace SimpleLogger.api.Configuration.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<LogViewModel, Log>()
                .ConstructUsing(l =>
                new Log(l.Path, l.Level, l.Type, l.TimeProcess, l.ProjectId));

            CreateMap<ProjectViewModel, Project>()
                .ConstructUsing(p => new Project(p.Type, p.Name));

            CreateMap<ClientViewModel, Client>()
                .ConstructUsing(c => new Client(c.HostName, c.UserAgent, c.ClientAddress, c.OperatorAddress, c.ExternalAddress));

            CreateMap<RequestViewModel, Request>()
                .ConstructUsing(r => new Request(
                    r.Method,
                    r.Uri,
                    r.UserAgent,
                    r.Headers.ToJson(),
                    r.Body.ToJson(),
                    r.Sise
                ));

            CreateMap<ResponseViewModel, Response>()
                .ConstructUsing(r => new Response(r.StatusCode, r.Headers.ToJson(), r.Sise));

            CreateMap<ErrorViewModel, Error>()
                .ConstructUsing(e => new Error(e.Type, e.Message, e.Tracer));
        }
    }
}