using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Hirdavat.M.MobilModels
{
    class Mobil_Model_Category
    {


        public Mobil_Model_Category()
        {
            mobil_Model_Products = new Collection<Mobil_Model_Products>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsDeleted { get; set; }

        //Icollection Interface den bir dizi oluşturduk 
        //category de birden fazla ürün olabilir.
        public ICollection<Mobil_Model_Products> mobil_Model_Products { get; set; }
    }
}
