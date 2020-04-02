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

        //AppDbcontext mümkün olduğunca sade olması gerekir   
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());



            modelBuilder.ApplyConfiguration(new ProductSeed(new int[] { 1, 2, 3, 4, 5, 6, 7 }));
            modelBuilder.ApplyConfiguration(new CategorySeed(new int[] { 1, 2, 3, 4, 5, 6, 7 }));



        }
    }


}
