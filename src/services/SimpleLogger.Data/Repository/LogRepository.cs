using Core.Repository;
using Microsoft.EntityFrameworkCore;
using SimpleLogger.Business.Interfaces.Repository;
using SimpleLogger.Business.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SimpleLogger.Data.Repository
{
    public class LogRepository : ILogRepository
    {
        private readonly LoggerContext _context;

        public LogRepository(LoggerContext context)
        {
            _context = context;
        }

        public IUnitOfWork UnitOfWork => _context;



        public async Task<IEnumerable<Log>> GetAll()
        {
            return await _context.Logs
                .Include(l => l.Client)
                .Include(l => l.Request)
                .Include(l => l.Response)
                .Include(l => l.Errors)
                .Include(l => l.Project)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Log> GetById(Guid id)
        {
            return await _context.Logs.FindAsync(id);
        }

        public void Insert(Log log)
        {
            _context.Logs.Add(log);
        }
        public void Update(Log log)
        {
            _context.Logs.Update(log);
        }

        public void Remove(Log log)
        {
            _context.Logs.Remove(log);
        }

        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}
