using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using UdemyNLayerProject.Core.UnitOfWorks;
using UdemyNLayerProject.Core.Repositories;
using UdemyNLayerProject.Core.Services;


namespace UdemyNLayerProject.Service.Services
{
    public class Service<TEntity> : IService<TEntity> where TEntity : class
    {
        // public readonly IUnitOfWork _unitOfWork;
        // private readonly IRepository<TEntity> _repository;

        protected IUnitOfWork UnitOfWork { get; }

        private IRepository<TEntity> Repository { get; }


        public Service(IUnitOfWork unitOfWork, IRepository<TEntity> repository)
        {
            UnitOfWork = unitOfWork;
            Repository = repository;
        }

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            await Repository.AddAsync(entity);
            await UnitOfWork.CommitAsync();
            return entity;
        }

        public async Task<IEnumerable<TEntity>> AddRangeAsync(IEnumerable<TEntity> entities)
        {
            var addRangeAsync = entities as TEntity[] ?? entities.ToArray();
            await Repository.AddRangeAsync(addRangeAsync);
            await UnitOfWork.CommitAsync();
            return addRangeAsync;
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await Repository.GetAllAsync();
        }

        public async Task<TEntity> GetByIdAsync(int id)
        {
            return await Repository.GetByIdAsync(id);
        }

        public void Remove(TEntity entity)
        {
            Repository.Remove(entity);
            UnitOfWork.Commit();
        }

        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            Repository.RemoveRange(entities);
            UnitOfWork.Commit();
        }

        public async Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await Repository.SingleOrDefaultAsync(predicate);
        }

        public TEntity Update(TEntity entity)
        {
            TEntity updateEntity = Repository.Update(entity);
            UnitOfWork.Commit();
            return updateEntity;
        }

        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            TEntity updateEntity = await Repository.UpdateAsync(entity);
            await UnitOfWork.CommitAsync();
            return updateEntity;
        }

        public async Task<IEnumerable<TEntity>> Where(Expression<Func<TEntity, bool>> predicate)
        {
            return await Repository.Where(predicate);
        }
        
        
    }
}