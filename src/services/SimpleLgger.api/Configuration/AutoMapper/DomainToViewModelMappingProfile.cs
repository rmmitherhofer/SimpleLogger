using AutoMapper;
using SimpleLogger.api.Application.Queries.ViewModels;
using SimpleLogger.Business.Model;
using System.Linq;
using WebAPI.Core.Extensions;

namespace SimpleLogger.api.Configuration.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Log, LogViewModel>()
                .ForMember(d => d.Project, o => o.MapFrom(s => s.Project))
                .ForMember(d => d.Client, o => o.MapFrom(s => s.Client))
                .ForMember(d => d.Request, o => o.MapFrom(s => s.Request))
                .ForPath(d => d.Request.Headers, o => o.MapFrom(s => s.Request.Headers.ToDictionary()))
                .ForPath(d => d.Request.Body, o => o.MapFrom(s => s.Request.Body.ToDictionary()))
                .ForMember(d => d.Response, o => o.MapFrom(s => s.Response))
                .ForPath(d => d.Response.Headers, o => o.MapFrom(s => s.Response.Headers.ToDictionary()))
                .ForMember(d => d.Errors, o => o.MapFrom(s => s.Errors));

            CreateMap<Project, ProjectViewModel>();

            CreateMap<Client, ClientViewModel>();

            CreateMap<Request, RequestViewModel>()
                .ForPath(d => d.Headers, o => o.MapFrom(s => s.Headers.ToDictionary()))
                .ForPath(d => d.Body, o => o.MapFrom(s => s.Body.ToDictionary()));

            CreateMap<Response, ResponseViewModel>()
                .ForPath(d => d.Headers, o => o.MapFrom(s => s.Headers.ToDictionary()));

            CreateMap<Error, ErrorViewModel>();
        }
    }
}
