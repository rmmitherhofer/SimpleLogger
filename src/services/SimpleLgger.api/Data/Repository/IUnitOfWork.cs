using System.Threading.Tasks;

namespace SimpleLogger.api.Data.Repository
{
    public interface IUnitOfWork
    {
        Task<bool> Commit();
    }
}
