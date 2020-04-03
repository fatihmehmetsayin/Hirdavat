using Hirdavat.Core.Models;
using Hirdavat.Core.Repositories;
using Hirdavat.Core.Servisler;
using Hirdavat.Core.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Hirdavat.Servis.Services
{
   public class CategoryService : Service<Category>, ICategoryServis
    {
        public CategoryService(IRepository<Category> repository, IunitOfWork ıunitOfWork) : base(repository, ıunitOfWork)
        {
        }

        public  async Task<Category> GetWithProductByIDAsync(int CategoryId)
        {
            return await _ıunitOfWork.Category.GetWithProductByIDAsync(CategoryId);
        }
    }
}
