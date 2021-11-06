using FluentValidation.Results;
using Microsoft.EntityFrameworkCore;
using SimpleLogger.api.Data.Repository;
using SimpleLogger.api.Model;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleLogger.api.Data
{
    public class LoggerContext : DbContext, IUnitOfWork
    {
        public LoggerContext(DbContextOptions<LoggerContext> options) : base(options)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            ChangeTracker.AutoDetectChangesEnabled = false;
        }

        public DbSet<Project> Projects { get; set; }
        public DbSet<Log> Logs { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Request> Requests { get; set; }
        public DbSet<Response> Responses { get; set; }
        public DbSet<Error> Errors { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Ignore<ValidationResult>();
            //builder.Ignore<Event>();

            foreach (var property in builder.Model.GetEntityTypes()
                .SelectMany(e =>
                    e.GetProperties()
                    .Where(p => p.ClrType == typeof(string))))
            {
                property.SetColumnType("varchar(100)");
            }

            foreach (var relationship in builder.Model.GetEntityTypes()
                .SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.ClientSetNull;
            }

            builder.ApplyConfigurationsFromAssembly(typeof(LoggerContext).Assembly);
        }

        public  async Task<bool> Commit()
        {
            var success = await base.SaveChangesAsync() > 0;

            if (success)
                Console.WriteLine(this);
                //await _mediatorHandler.PublicarEventos(this);

            return success;
        }
    }
}
