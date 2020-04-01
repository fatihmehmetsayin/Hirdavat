using Hirdavat.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Hirdavat.Core.Repositories
{

    //generic repository pattern imlement edildi
    interface IcategoryRepository : IRepository<Category>
    {

        

        //category ve kadogriye bağlı ürünler dönsün
        Task<Category> GetWithProductByIDAsync(int CategoryId);


    }
}
