using Core.DomainObjects;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Repository
{
    public interface IRepository<TEntity> : IDisposable where TEntity : IAggregateRoot
    {
        IUnitOfWork UnitOfWork { get; }

        Task<IEnumerable<TEntity>> GetAll();
        Task<TEntity> GetById(Guid id);

        void Insert(TEntity entity);
        void Update(TEntity entity);
        void Remove(TEntity entity);
    }
}
