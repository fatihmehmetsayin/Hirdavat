using Hirdavat.Core.Models;
using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Text;

namespace Hirdavat.Data
{
    class AppDbContext : DbContext
    {

        //AppDbcontext mümkün olduğunca sade olması gerekir   
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
       


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
        }
    }

  
}
