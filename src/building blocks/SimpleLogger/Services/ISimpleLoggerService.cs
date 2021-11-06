using SimpleLogger.Models;
using System.Threading.Tasks;

namespace SimpleLogger.Services
{
    public interface ISimpleLoggerService
    {
        Task Insert(Log log);
    }
}
