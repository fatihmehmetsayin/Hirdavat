using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hirdavat_Api_Nesne2.Dto
{
    public class ErrorDto
    {



        //eror listesinden yeni bir liste oluşturalım ki  içerisini doldurabilelelim
        public ErrorDto()
        {
            Errors = new List<string>();
        }

        //birden fazla hata olabilir 
        public List<string> Errors { get; set; }


        //durum kodu klayt için
        public int status { get; set; }
    }

}

