using Hirdavat.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;



// data katmanındaki  repository clası implement edecek
namespace Hirdavat.Core.Repositories
{

    //generik repository pattern implement edildi   
   public  interface IproductRepository:IRepository<Product>
    {
        //product da ait özel metotlar burada  olacak
        //Ürünün ID sine bağlı kadegoride  gelsin

        Task<Product> GetWithCategoryByIdAsync(int product);
    }
}
