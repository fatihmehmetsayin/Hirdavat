using Hirdavat.Core.Models;
using Hirdavat.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Hirdavat.Data.Repositories
{
    internal class CategoryRepository : Repository<Category>, IcategoryRepository
    {
        public CategoryRepository(DbContext context) : base(context)
        {
        }

        private AppDbContext _AppDbContext { get => _Context as AppDbContext; }

        public  async Task<Category> GetWithProductByIDAsync(int CategoryId)
        {
            return await _AppDbContext.Categories.Include(x =>x.Products).SingleOrDefaultAsync(x => x.Id == CategoryId);
        }
    }
}
