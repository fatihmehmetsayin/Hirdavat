using Hirdavat.Core.Models;
using Hirdavat.Data.Configuration;
using Hirdavat.Data.Seeds;
using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Text;

namespace Hirdavat.Data
{
  public  class AppDbContext : DbContext
    {

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Category>().ToTable("Categories");
            builder.Entity<Category>().HasKey(p => p.Id);
            builder.Entity<Category>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();//.HasValueGenerator<InMemoryIntegerValueGenerator<int>>();
            builder.Entity<Category>().Property(p => p.Name).HasMaxLength(30);
            builder.Entity<Category>().HasMany(p => p.Products).WithOne(p => p.Category).HasForeignKey(p => p.CategoryId);

            builder.Entity<Category>().HasData
            (
                new Category { Id = 100, Name = "Anahtar" }, // Id set manually due to in-memory provider
                new Category { Id = 101, Name = "Boa tabancları" }
            );

            builder.Entity<Product>().ToTable("Products");
            builder.Entity<Product>().HasKey(p => p.Id);
            builder.Entity<Product>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Product>().Property(p => p.Name).HasMaxLength(50);
            builder.Entity<Product>().Property(p => p.Stok);
            //builder.Entity<Product>().Property(p => p.).IsRequired();

         
            
          

            builder.Entity<Product>().HasData
            (
                new Product
                {
                    Id = 100,
                    Name = "Mekanik El Aletleri",
                    //QuantityInPackage = 1,
                    //UnitOfMeasurement = EUnitOfMeasurement.Unity,
                    CategoryId = 100
                },
                new Product
                {
                    Id = 101,
                    Name = "Elektrikli El Alatleri",
                    //QuantityInPackage = 2,
                    //UnitOfMeasurement = EUnitOfMeasurement.Liter,
                    CategoryId = 101,
                }
            );
        }
    }


}
