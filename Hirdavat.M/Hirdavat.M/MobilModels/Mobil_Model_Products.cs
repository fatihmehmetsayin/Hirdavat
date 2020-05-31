using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Hirdavat.M.MobilModels
{
    class Mobil_Model_Products
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public int Stok { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
        public bool IsDeleted { get; set; }
        public string InnerBarCode { get; set; }

        //EntityFrameWork Category üzerinde değişiklik olduğunda izleme yapabilecek
      //  public virtual Mobil_Model_Category M_Category { get; set; }


    }
}
