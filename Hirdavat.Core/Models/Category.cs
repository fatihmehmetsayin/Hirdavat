using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Hirdavat.Core.Models
{
    class Category
    {
        public Category()
        {            //boş bir colleciton nesnesi oluşturuyor.
            Products = new Collection<Product>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsDeleted { get; set; }

        //Icollection Interface den bir dizi oluşturduk 
        //category de birden fazla ürün olabilir.
        public ICollection<Product> Products { get; set; }

    }
}
