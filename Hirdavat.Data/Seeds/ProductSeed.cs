using Hirdavat.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hirdavat.Data.Seeds
{
    class ProductSeed : IEntityTypeConfiguration<Product>
    {
        private readonly int[] _Id;


        public ProductSeed(int[] Id)
        {
            _Id = Id;


        }
        //catorriye bağlı olacağı için ctor d ID almam lazım veritabına kaydederken catori ID belli etmem lazım
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasData(
                new Product { Id = 1, CategoryId = _Id[0], Name = "İzeltaş 10 lu", Stok = 100, Price = 12.50m },
                 new Product { Id = 2, CategoryId = _Id[0], Name = " izeltaş dokuzlu", Stok = 200, Price = 40.50m },
                  new Product { Id = 3, CategoryId = _Id[0], Name = " stanley uzun", Stok = 300, Price = 500m },
                   new Product { Id = 4, CategoryId = _Id[0], Name = "Stanley somun ", Stok = 100, Price = 12.50m },
                    new Product { Id = 5, CategoryId = _Id[0], Name = " Stanley Lokma", Stok = 100, Price = 12.50m },
                     new Product { Id = 6, CategoryId = _Id[0], Name = "Astor Pvc Boru 65 mm", Stok = 100, Price = 12.50m },
                      new Product { Id = 7, CategoryId = _Id[0], Name = " Astor Pvc Boru 75 mm", Stok = 100, Price = 12.50m }
                );
        }
    }
}
