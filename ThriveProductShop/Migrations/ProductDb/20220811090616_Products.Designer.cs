﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProductShop.models;

#nullable disable

namespace ThriveProductShop.migrations.ProductDb
{
    [DbContext(typeof(ProductShopContext))]
    [Migration("20220811090616_Products")]
    partial class Products
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ThriveProductShop.models.ProductDomain.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)");

                    b.Property<string>("ImagePath")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Name")
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)");

                    b.Property<decimal?>("Price")
                        .HasColumnType("money");

                    b.Property<int?>("ProductGroupId")
                        .HasColumnType("int")
                        .HasColumnName("ProductGroup_Id");

                    b.HasKey("Id");

                    b.HasIndex("ProductGroupId");

                    b.ToTable("Product", (string)null);
                });

            modelBuilder.Entity("ThriveProductShop.models.ProductDomain.ProductGroup", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Title")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("ProductGroup", (string)null);
                });

            modelBuilder.Entity("ThriveProductShop.models.ProductDomain.Product", b =>
                {
                    b.HasOne("ThriveProductShop.models.ProductDomain.ProductGroup", "ProductGroup")
                        .WithMany("Products")
                        .HasForeignKey("ProductGroupId")
                        .HasConstraintName("FK_ProductList_ProductGroup");

                    b.Navigation("ProductGroup");
                });

            modelBuilder.Entity("ThriveProductShop.models.ProductDomain.ProductGroup", b =>
                {
                    b.Navigation("Products");
                });
#pragma warning restore 612, 618
        }
    }
}