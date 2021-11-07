using Core.DomainObjects;
using Core.Mediator;
using Core.Messages;
using Core.Repository;
using FluentValidation.Results;
using Microsoft.EntityFrameworkCore;
using SimpleLogger.Business.Model;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleLogger.Data
{
    public class LoggerContext : DbContext, IUnitOfWork
    {
        private readonly IMediatorHandler _mediatorHandler;
        public LoggerContext(DbContextOptions<LoggerContext> options, IMediatorHandler mediatorHandler) : base(options)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            ChangeTracker.AutoDetectChangesEnabled = false;
            _mediatorHandler = mediatorHandler;
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
            builder.Ignore<Event>();

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
                await _mediatorHandler.PublishEvents(this);

            return success;
        }
    }

    public static class MediatorExtension
    {
        public static async Task PublishEvents<T>(this IMediatorHandler mediator, T context) where T : DbContext
        {
            var domainEntities = context.ChangeTracker
                .Entries<Entity>()
                .Where(x => x.Entity.Notifications?.Any() == true);

            var domainEvents = domainEntities
                .SelectMany(x => x.Entity.Notifications)
                .ToList();

            domainEntities
                .ToList()
                .ForEach(entity => entity.Entity.ClearEvents());

            var tasks = domainEvents
                .Select(async (domainEvents) => await mediator.Publish(domainEvents));

            await Task.WhenAll(tasks);
        }
    }
}
