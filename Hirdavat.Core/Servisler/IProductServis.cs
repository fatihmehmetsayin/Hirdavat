using Hirdavat.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Hirdavat.Core.Servisler
{
    public interface IProductServis : Iservice<Product>
    {

        Task<Product> GetWithCategoryByIdAsync(int product);

        //product nesnesi ile ilgili olan kodlar
        //herhangi bir veri tabanı ile ilgili işlemler ile alakalı  olmak zorunda değil
        //product nesnesine özel kodlar için
    }
}
