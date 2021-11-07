using Core.Repository;
using Microsoft.EntityFrameworkCore;
using SimpleLogger.Business.Enums;
using SimpleLogger.Business.Interfaces.Repository;
using SimpleLogger.Business.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleLogger.Data.Repository
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly LoggerContext _context;

        public ProjectRepository(LoggerContext context)
        {
            _context = context;
        }

        public IUnitOfWork UnitOfWork => _context;

        public async Task<IEnumerable<Project>> GetAll()
        {
            return await _context.Projects
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Project> GetById(Guid id)
        {
            return await _context.Projects.FindAsync(id);
        }

        public async Task<Project> GetByName(string name)
        {
            return await _context.Projects
                .AsNoTracking()
                .FirstOrDefaultAsync(p => p.Name == name);
        }
        public async Task<Project> GetByType(ProjectType type)
        {
            return await _context.Projects
                .AsNoTracking()
                .FirstOrDefaultAsync(p => p.Type == type);
        }

        public void Insert(Project project)
        {
            _context.Projects.Add(project);
        }
        public void Update(Project project)
        {
            _context.Projects.Update(project);
        }

        public void Remove(Project project)
        {
            _context.Projects.Remove(project);
        }

        public void Dispose()
        {
            _context?.Dispose();
        }

    }
}
