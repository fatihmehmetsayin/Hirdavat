using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Hirdavat.Core.Repositories
{

    // data katmanındaki  repository clası implement edecek
  public   interface IRepository<TEntity> where TEntity : class
    {
        // veri tabanı ile ilgili en sık kullanılan interfaceler

        //Id ye göre nesne getir. 
        Task<TEntity> GetByIdAsync(int Id);


        //tüm nesneleri getir.
        Task<IEnumerable<TEntity>> GetAllAsync();


        // TEntity alan Geriye bool dönen bir metodu işaret ediyor
        //herhangi bir parametrey göre nesne getir.
      Task< IEnumerable<TEntity>> Where(Expression<Func<TEntity, bool>> predicate);


        //product innerborkodu şu olanı döndür.
        Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate);


        //ekleme işlemi
        Task AddAsync(TEntity entity);


        //toplu ekleme işlemi
        Task AddRangeAsync(IEnumerable<TEntity> entities);


        //silme işlemi
        void Remove(TEntity entity);

        //toplu silme
        void RemoveRange(IEnumerable<TEntity> entities);


        //güncellemi işlemi
        TEntity Update(TEntity entity);


       

    }
}
