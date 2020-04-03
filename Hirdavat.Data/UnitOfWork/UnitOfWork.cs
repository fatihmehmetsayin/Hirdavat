using Hirdavat.Core.Repositories;
using Hirdavat.Core.UnitOfWorks;
using Hirdavat.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Hirdavat.Data.UnitOfWork
{
     public class UnitOfWork : IunitOfWork
    {
        private readonly AppDbContext _AppDbContext;
        private ProductRepository _ProductRepository;
        private CategoryRepository _categoryRepository;

        public UnitOfWork(AppDbContext appDbContext)
        {
            _AppDbContext = appDbContext;
        }


        // iki tane soru işareti eğer null ise all anlamına geliyor 
        //git yeni bir tane poductreposiyory oluştur ve atama yap
        public IproductRepository Product => _ProductRepository = _ProductRepository ?? new ProductRepository(_AppDbContext);

        // varsa al  yok ise  yeni bir category reposiyory oluştur ve al


        public IcategoryRepository Category => _categoryRepository = _categoryRepository ?? new CategoryRepository(_AppDbContext);

        public void Commit()
        {
            _AppDbContext.SaveChanges();
        }

        public async Task CommitAsync()
        {
            await _AppDbContext.SaveChangesAsync();
        }
    }
}
