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
    public class ProductService : Service<Product>, IProductServis
    {
        public ProductService(IRepository<Product> repository, IunitOfWork ıunitOfWork) : base(repository, ıunitOfWork)
        {
        }

        public async Task<Product> GetWithCategoryByIdAsync(int productId)
        {
            return await _ıunitOfWork.Product.GetWithCategoryByIdAsync(productId);
        }
    }
}
