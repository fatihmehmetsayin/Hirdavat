﻿// <auto-generated />
using Hirdavat.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Hirdavat.Data.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20200402200235_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Hirdavat.Core.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            IsDeleted = false,
                            Name = "Mekanik El Aletleri"
                        },
                        new
                        {
                            Id = 2,
                            IsDeleted = false,
                            Name = "Elektikli El Aletleri"
                        },
                        new
                        {
                            Id = 3,
                            IsDeleted = false,
                            Name = "Akülü El Aletleri"
                        },
                        new
                        {
                            Id = 4,
                            IsDeleted = false,
                            Name = "Havalı El Aletleri"
                        },
                        new
                        {
                            Id = 5,
                            IsDeleted = false,
                            Name = "Ölçüm Cihazları"
                        },
                        new
                        {
                            Id = 6,
                            IsDeleted = false,
                            Name = "Bahçe Makinaleri "
                        },
                        new
                        {
                            Id = 7,
                            IsDeleted = false,
                            Name = "Hobi Aletleri "
                        });
                });

            modelBuilder.Entity("Hirdavat.Core.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("InnerBarCode")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(200)")
                        .HasMaxLength(200);

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Stok")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoryId = 1,
                            IsDeleted = false,
                            Name = "İzeltaş 10 lu",
                            Price = 12.50m,
                            Stok = 100
                        },
                        new
                        {
                            Id = 2,
                            CategoryId = 1,
                            IsDeleted = false,
                            Name = " izeltaş dokuzlu",
                            Price = 40.50m,
                            Stok = 200
                        },
                        new
                        {
                            Id = 3,
                            CategoryId = 1,
                            IsDeleted = false,
                            Name = " stanley uzun",
                            Price = 500m,
                            Stok = 300
                        },
                        new
                        {
                            Id = 4,
                            CategoryId = 1,
                            IsDeleted = false,
                            Name = "Stanley somun ",
                            Price = 12.50m,
                            Stok = 100
                        },
                        new
                        {
                            Id = 5,
                            CategoryId = 1,
                            IsDeleted = false,
                            Name = " Stanley Lokma",
                            Price = 12.50m,
                            Stok = 100
                        },
                        new
                        {
                            Id = 6,
                            CategoryId = 1,
                            IsDeleted = false,
                            Name = "Astor Pvc Boru 65 mm",
                            Price = 12.50m,
                            Stok = 100
                        },
                        new
                        {
                            Id = 7,
                            CategoryId = 1,
                            IsDeleted = false,
                            Name = " Astor Pvc Boru 75 mm",
                            Price = 12.50m,
                            Stok = 100
                        });
                });

            modelBuilder.Entity("Hirdavat.Core.Models.Product", b =>
                {
                    b.HasOne("Hirdavat.Core.Models.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
