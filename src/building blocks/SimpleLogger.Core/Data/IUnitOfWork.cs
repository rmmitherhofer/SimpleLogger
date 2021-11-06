using System.Threading.Tasks;

namespace Core.Repository
{
    public interface IUnitOfWork
    {
        Task<bool> Commit();
    }
}
