using MvcAppExample.Business.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace MvcAppExample.Business.Interfaces.Repositories
{
    public interface IRepositoryBase<TEntity> : IDisposable where TEntity : EntityBase
    {
        TEntity Add(TEntity entity);
        void Delete(Guid id);
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);
        TEntity FindById(Guid id);
        IEnumerable<TEntity> GetAll();
        int SaveChanges();
        TEntity Update(TEntity entity);
    }
}