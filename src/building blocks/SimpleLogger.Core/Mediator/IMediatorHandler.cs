using Core.Messages;
using FluentValidation.Results;
using System.Threading.Tasks;

namespace Core.Mediator
{
    public interface IMediatorHandler
    {
        Task Publish<T>(T eventItem) where T : Event;
        Task<ValidationResult> Send<T>(T command) where T : Command;
    }
}
