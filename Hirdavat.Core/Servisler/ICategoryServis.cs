using Hirdavat.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Hirdavat.Core.Servisler
{
    public interface ICategoryServis : Iservice<Category>
    {
        Task<Category> GetWithProductByIDAsync(int CategoryId);

        //category özgü metotlar burada tanmlanabilir.
    }
}
