using System;
using System.Collections.Generic;
using AutoMapper;
using MvcAppExample.Business.Interfaces.Services;
using MvcAppExample.Business.Entities;
using MvcAppExample.Business.Interfaces.Repositories;
using MvcAppExample.Business.Interfaces;

namespace MvcAppExample.Business.Services
{
    public abstract class ServiceBase<TEntity, TEntityViewModel, TRepository> : IServiceBase<TEntityViewModel> where TEntity : EntityBase where TEntityViewModel : class where TRepository : IRepositoryBase<TEntity>
    {
        readonly IUnitOfWork _uow;
        protected TRepository _repository;

        public ServiceBase(IUnitOfWork uow, TRepository repository)
        {
            _uow = uow;
            _repository = repository;
        }

        public virtual TEntityViewModel Add(TEntityViewModel entityViewModel)
        {
            var entity = _repository.Add(Mapper.Map<TEntity>(entityViewModel));

            if (entity.ValidationResult.IsValid)
                Commit();

            return Mapper.Map<TEntityViewModel>(entity);
        }

        public virtual TEntityViewModel Update(TEntityViewModel entityViewModel)
        {
            var entity = _repository.Update(Mapper.Map<TEntity>(entityViewModel));

            if (entity.ValidationResult.IsValid)
                Commit();

            return Mapper.Map<TEntityViewModel>(entity);
        }

        public virtual TEntityViewModel FindById(Guid id)
        {
            return Mapper.Map<TEntityViewModel>(_repository.FindById(id));
        }

        public virtual IEnumerable<TEntityViewModel> GetAll()
        {
            return Mapper.Map<IEnumerable<TEntityViewModel>>(_repository.GetAll());
        }

        public virtual void Delete(Guid id)
        {
            _repository.Delete(id);
            Commit();
        }

        protected void Commit()
        {
            _uow.Commit();
        }

        public virtual void Dispose()
        {
            _repository.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
