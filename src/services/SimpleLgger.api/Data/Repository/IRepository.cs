using SimpleLogger.api.DomainObjects;
using System;

namespace SimpleLogger.api.Data.Repository
{
    public interface IRepository<T> : IDisposable where T : IAggregateRoot
    {
        IUnitOfWork UnitOfWork { get; }
    }
}
