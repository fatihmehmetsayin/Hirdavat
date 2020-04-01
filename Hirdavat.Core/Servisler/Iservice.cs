using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Hirdavat.Core.Servisler
{

    public interface Iservice<TEntity> where TEntity : class
    {
        //servis repositorynin kopyası
        //veri tabanın  değitirilmesi durumuna karşılık yapılmıştır.
        //veri tabanı değişine repository değişir ancak servis değişmez


        // veri tabanı ile ilgili en sık kullanılan interfaceler

        //Id ye göre nesne getir. 
        Task<TEntity> GetByIdAsync(int Id);


        //tüm nesneleri getir.
        Task<IEnumerable<TEntity>> GetAllAsync();


        // TEntity alan Geriye bool dönen bir metodu işaret ediyor
        //herhangi bir parametrey göre nesne getir.
        Task<IEnumerable<TEntity>> Find(Expression<Func<TEntity, bool>> predicate);


        //product innerborkodu şu olanı döndür.
        Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate);


        //ekleme işlemi
        Task AddAsync(TEntity entity);


        //toplu ekleme işlemi
        Task AddRangeAsync(IEnumerable<TEntity> entities);


        //silme işlemi
        void Remove(TEntity entity);

        //toplu silme
        void RemoveRange(IEnumerable<TEntity> entity);


        //güncellemi işlemi
        TEntity Update(TEntity entity);



    }
}
