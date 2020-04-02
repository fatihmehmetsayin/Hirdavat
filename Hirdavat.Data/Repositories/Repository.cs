using Hirdavat.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Hirdavat.Data.Repositories
{

    
   public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {

        //miral aldığım yerde kullanıyorum daha uygun olur
        protected readonly DbContext _Context;

        // sadece burda kullaıyırum daha doğru olur  
        private readonly DbSet<TEntity> _DbSet;

        public Repository(DbContext context)
        {
            //context ile veri tabanına erişim
            _Context = context;

            //Db set ile de tablolara erişim sağlar
            _DbSet = context.Set<TEntity>();
        }


        public async Task AddAsync(TEntity entity)
        {
            await _DbSet.AddAsync(entity);
        }

        public async Task AddRangeAsync(IEnumerable<TEntity> entities)
        {
            await _DbSet.AddRangeAsync(entities);
        }

        public IEnumerable<TEntity> Where(Expression<Func<TEntity, bool>> predicate)
        {
            return _DbSet.Where(predicate);
        }


        //Task sekron programlamadaki void e karşılık gelir 
        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return  await _DbSet.ToListAsync();
        }

        public async Task<TEntity> GetByIdAsync(int Id)
        {
            return await _DbSet.FindAsync(Id);
        }

        public void Remove(TEntity entity)
        {
            _DbSet.Remove(entity);
        }

        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            _DbSet.RemoveRange(entities);
        }


        // delegeler 
        //predicate delgesi. bir entity alan geriye bool dönem bir metot ver 
        public async Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _DbSet.SingleOrDefaultAsync(predicate);
        }

        public TEntity Update(TEntity entity)
        {
            _Context.Entry(entity).State = EntityState.Modified;
            return entity;
        }

       
    }
}
