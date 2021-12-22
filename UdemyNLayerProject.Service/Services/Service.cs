using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using UdemyNLayerProject.Core.Repositories;
using UdemyNLayerProject.Core.Services;
using UdemyNLayerProject.Data.UnitOfWorks;

namespace UdemyNLayerProject.Service.Services
{
    public class Service<TEntity> : IService<TEntity> where TEntity : class
    {
        public readonly UnitOfWork UnitOfWork;

        private readonly IRepository<TEntity> _repository;

        public Service(IRepository<TEntity> repository, UnitOfWork unitOfWork)
        {
            _repository = repository;
            UnitOfWork = unitOfWork;
        }

        public async Task<TEntity> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<IEnumerable<TEntity>> Where(Expression<Func<TEntity, bool>> predicate)
        {
            return await _repository.Where(predicate);
        }

        public async Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _repository.SingleOrDefaultAsync(predicate);
        }

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            await _repository.AddAsync(entity);
            await UnitOfWork.CommitAsync();
            return entity;
        }

        public async Task<IEnumerable<TEntity>> AddRangeAsync(IEnumerable<TEntity> entities)
        {
            var addRangeAsync = entities as TEntity[] ?? entities.ToArray();
            await _repository.AddRangeAsync(addRangeAsync);
            await UnitOfWork.CommitAsync();
            return addRangeAsync;
        }

        public void Remove(TEntity entity)
        {
            _repository.Remove(entity);
            UnitOfWork.Commit();
        }

        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            _repository.RemoveRange(entities);
            UnitOfWork.Commit();
        }

        public TEntity Update(TEntity entity)
        {
            var updateEntity = _repository.Update(entity);
            UnitOfWork.Commit();
            return updateEntity;
        }
    }
}