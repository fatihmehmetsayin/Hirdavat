using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Hirdavat_Api_Nesne2.Dto
{
    public class ProductDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "{0}, Name Alanı Gereklidir")]
        public string Name { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Stok alanı  1den büyük olmalıdır")]
        public int Stok { get; set; }

        [Range(1, double.MaxValue, ErrorMessage = "1den büyük olmalı")]
        public decimal Price { get; set; }

        public int CategoryId { get; set; }

    }
}
