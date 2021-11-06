using Core.Repository;
using SimpleLogger.Business.Enums;
using SimpleLogger.Business.Model;
using System.Threading.Tasks;

namespace SimpleLogger.Business.Interfaces.Repository
{
    public interface IProjectRepository : IRepository<Project>
    {
        Task<Project> GetByName(string name);
        Task<Project> GetByType(ProjectType type);
    }
}
