using Hirdavat.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hirdavat.Data.Seeds
{
    class CategorySeed : IEntityTypeConfiguration<Category>
    {
        private readonly int[] _Id;

        public CategorySeed(int[] Id)
        {
            _Id = Id;
        }
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasData(
                 new Category { Id = _Id[0], Name = "Mekanik El Aletleri" },
                 new Category { Id = _Id[1], Name = "Elektikli El Aletleri" },
                 new Category { Id = _Id[2], Name = "Akülü El Aletleri" },
                 new Category { Id = _Id[3], Name = "Havalı El Aletleri" },
                 new Category { Id = _Id[4], Name = "Ölçüm Cihazları" },
                 new Category { Id = _Id[5], Name = "Bahçe Makinaleri " },
                 new Category { Id = _Id[6], Name = "Hobi Aletleri " }




             );
        }
    }
}
