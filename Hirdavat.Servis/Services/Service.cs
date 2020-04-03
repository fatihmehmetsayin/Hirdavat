using Hirdavat.Core.Models;
using Hirdavat.Core.Repositories;
using Hirdavat.Core.Servisler;
using Hirdavat.Core.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Hirdavat.Servis.Services
{
    public class Service<TEntity> : Iservice<TEntity> where TEntity : class
    {

        public readonly IunitOfWork _ıunitOfWork;
        private readonly IRepository<TEntity> _repository;
        private IunitOfWork uofW;
        private IRepository<Category> ırpsity;

        public Service(IRepository<TEntity> repository, IunitOfWork ıunitOfWork)
        {
            _repository = repository;
            _ıunitOfWork = ıunitOfWork;
        }

        public Service(IunitOfWork uofW, IRepository<Category> ırpsity)
        {
            this.uofW = uofW;
            this.ırpsity = ırpsity;
        }

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            await _repository.AddAsync(entity);
            await _ıunitOfWork.CommitAsync();
            return entity;
        }

        public async Task<IEnumerable<TEntity>> AddRangeAsync(IEnumerable<TEntity> entities)
        {
            await _repository.AddRangeAsync(entities);
            await _ıunitOfWork.CommitAsync();
            return entities;

        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<TEntity> GetByIdAsync(int Id)
        {
            return await _repository.GetByIdAsync(Id);
        }

        public void Remove(TEntity entity)
        {
            _repository.Remove(entity);
            _ıunitOfWork.Commit();

        }

        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            _repository.RemoveRange(entities);
            _ıunitOfWork.Commit();
        }

        public async Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _repository.SingleOrDefaultAsync(predicate);
        }

        public TEntity Update(TEntity entity)
        {

            TEntity Updateentity = _repository.Update(entity);
            _ıunitOfWork.Commit();
            return Updateentity;

        }
        public async Task<IEnumerable<TEntity>> Where(Expression<Func<TEntity, bool>> predicate)
        {
            return await _repository.Where(predicate);
        }
    }



}
