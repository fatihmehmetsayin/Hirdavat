using Hirdavat.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Hirdavat.Core.UnitOfWorks
{


    // pattern 
    //değişikleri yap Entity Framework hafızada tutacak 
    //ne zaman istiyorsan  veritabbanı yansımasını istiyorsan   o zaman değişiklik yapsın
    //alış veris yaparken toplu olarak tek bir seferde göndersin 
    //tek tek göndermesin 

    interface IunitOfWork
    {

        //Iunitof pattern içinde  verilmeyebilirler
        //DI olarak kullanılabilir
        //Dırasırdan da eişim olabilir 
        IproductRepository Product { get; }
        IcategoryRepository Category { get; }



        Task CommitAsync();

        void Commit();

    }
}
