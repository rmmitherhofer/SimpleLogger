using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace SimpleLogger.api.Application.Events.Handler
{
    public class LogEventHandler : INotificationHandler<RegisteredProjectEvent>
    {
        public Task Handle(RegisteredProjectEvent notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
