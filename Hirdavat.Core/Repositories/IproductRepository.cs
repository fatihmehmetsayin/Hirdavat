using Hirdavat.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Hirdavat.Core.Repositories
{

    //generik repository pattern implement edildi   
    interface IproductRepository:IRepository<Product>
    {

        //Ürünün ID sine bağlı kadegoride  gelsin

        Task<Product> GetWithCategoryByIdAsync(int product);
    }
}
