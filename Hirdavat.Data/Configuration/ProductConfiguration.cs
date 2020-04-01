using Hirdavat.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hirdavat.Data.Configuration
{
    class ProductConfiguration : IEntityTypeConfiguration<Product>
    {

        //Veri tabanında Prodcut Tablosunun oluşturulması
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();

            builder.Property(x => x.Name).IsRequired().HasMaxLength(200);
            builder.Property(x => x.Stok).IsRequired();

            builder.Property(x => x.Price).IsRequired().HasColumnType("decimal(18,2)");
            builder.Property(x => x.InnerBarCode).HasMaxLength(50);

            builder.ToTable("Products");


        }
    }
}
