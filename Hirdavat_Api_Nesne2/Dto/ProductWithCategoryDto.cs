using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hirdavat_Api_Nesne2.Dto
{
    public class ProductWithCategoryDto :ProductDto
    {
        public CategoryDto Category { get; set; }
    }
}
