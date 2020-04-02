using Hirdavat.Core.Models;
using Hirdavat.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Hirdavat.Data.Repositories
{
   public class ProductRepository : Repository<Product>, IproductRepository
    {


        // as keywordu ile beraber cast işlemi yapıldı ne olduğunu biliyorum
        private AppDbContext _AppDbContext { get => _Context as AppDbContext; }
        public ProductRepository(DbContext context) : base(context)
        {
        }

        public  async Task<Product> GetWithCategoryByIdAsync(int productId)
        {
            return await _AppDbContext.Products.Include(x => x.Category).SingleOrDefaultAsync(x => x.Id == productId);
        }
    }
}
