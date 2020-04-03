using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hirdavat_Api_Nesne2.Dto
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Stok { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }

    }
}
