﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PuntoDeVenta_Api.Data;

#nullable disable

namespace PuntoDeVenta_Api.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20240628034314_initial")]
    partial class initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("PuntoDeVenta_Api.Models.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int?>("CategoryId")
                        .HasColumnType("int");

                    b.Property<decimal>("Cost")
                        .HasColumnType("decimal(18, 0)");

                    b.Property<string>("Description")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18, 0)");

                    b.Property<int>("Stock")
                        .HasColumnType("int");

                    b.HasKey("ProductId")
                        .HasName("PK__PRODUCTS__B40CC6CD3AD54279");

                    b.HasIndex("CategoryId");

                    b.ToTable("PRODUCTS");
                });

            modelBuilder.Entity("Shared.Models.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.HasKey("CategoryId")
                        .HasName("PK__CATEGORI__19093A0B5132E779");

                    b.ToTable("CATEGORIES");
                });

            modelBuilder.Entity("Shared.Models.Inventory", b =>
                {
                    b.Property<int>("InventoryId")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int?>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("InventoryId")
                        .HasName("PK__INVENTOR__F5FDE6B38CB3E2D9");

                    b.HasIndex("ProductId");

                    b.ToTable("INVENTORY");
                });

            modelBuilder.Entity("Shared.Models.Paymentmethod", b =>
                {
                    b.Property<int>("PaymentMethodId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.HasKey("PaymentMethodId")
                        .HasName("PK__PAYMENTM__DC31C1D351B7B089");

                    b.ToTable("PAYMENTMETHODS");
                });

            modelBuilder.Entity("Shared.Models.Purchase", b =>
                {
                    b.Property<int>("PurchaseId")
                        .HasColumnType("int");

                    b.Property<DateTime>("PurchaseDate")
                        .HasColumnType("datetime");

                    b.Property<int>("SuplierId")
                        .HasColumnType("int");

                    b.Property<decimal>("TotalPurchase")
                        .HasColumnType("decimal(18, 2)");

                    b.HasKey("PurchaseId")
                        .HasName("PK__PURCHASE__6B0A6BBE44DAE336");

                    b.HasIndex("SuplierId");

                    b.ToTable("PURCHASES");
                });

            modelBuilder.Entity("Shared.Models.Purchasedetail", b =>
                {
                    b.Property<int>("DetailId")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("PurchaseId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<decimal>("SubTotal")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<decimal>("UnitPrice")
                        .HasColumnType("decimal(18, 2)");

                    b.HasKey("DetailId")
                        .HasName("PK__PURCHASE__135C316D22F8D778");

                    b.HasIndex("ProductId");

                    b.HasIndex("PurchaseId");

                    b.ToTable("PURCHASEDETAILS");
                });

            modelBuilder.Entity("Shared.Models.Saledetail", b =>
                {
                    b.Property<int>("DetailId")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<int>("SaleId")
                        .HasColumnType("int");

                    b.Property<decimal>("SubTotal")
                        .HasColumnType("decimal(18, 0)");

                    b.Property<decimal>("UnitaryPrice")
                        .HasColumnType("decimal(18, 0)");

                    b.HasKey("DetailId")
                        .HasName("PK__SALEDETA__135C316D5FF9200A");

                    b.HasIndex("ProductId");

                    b.HasIndex("SaleId");

                    b.ToTable("SALEDETAILS");
                });

            modelBuilder.Entity("Shared.Models.Sales", b =>
                {
                    b.Property<int>("SaleId")
                        .HasColumnType("int");

                    b.Property<int>("PaymentMethodId")
                        .HasColumnType("int");

                    b.Property<DateTime>("SaleDate")
                        .HasColumnType("datetime");

                    b.Property<decimal>("SaleTotal")
                        .HasColumnType("decimal(18, 0)");

                    b.HasKey("SaleId")
                        .HasName("PK__SALES__1EE3C3FFA2BAB9F2");

                    b.HasIndex("PaymentMethodId");

                    b.ToTable("SALES");
                });

            modelBuilder.Entity("Shared.Models.Suplier", b =>
                {
                    b.Property<int>("SuplierId")
                        .HasColumnType("int");

                    b.Property<string>("Address")
                        .HasMaxLength(200)
                        .IsUnicode(false)
                        .HasColumnType("varchar(200)");

                    b.Property<string>("Email")
                        .HasMaxLength(80)
                        .IsUnicode(false)
                        .HasColumnType("varchar(80)");

                    b.Property<string>("PhoneNumber")
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("varchar(20)");

                    b.Property<string>("SuplierName")
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)");

                    b.HasKey("SuplierId")
                        .HasName("PK__SUPLIERS__1AD74ADD3FD3A0B6");

                    b.ToTable("SUPLIERS");
                });

            modelBuilder.Entity("PuntoDeVenta_Api.Models.Product", b =>
                {
                    b.HasOne("Shared.Models.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId")
                        .HasConstraintName("FK__PRODUCTS__Catego__440B1D61");

                    b.Navigation("Category");
                });

            modelBuilder.Entity("Shared.Models.Inventory", b =>
                {
                    b.HasOne("PuntoDeVenta_Api.Models.Product", "Product")
                        .WithMany("Inventories")
                        .HasForeignKey("ProductId")
                        .IsRequired()
                        .HasConstraintName("FK__INVENTORY__Produ__656C112C");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("Shared.Models.Purchase", b =>
                {
                    b.HasOne("Shared.Models.Suplier", "Suplier")
                        .WithMany("Purchases")
                        .HasForeignKey("SuplierId")
                        .IsRequired()
                        .HasConstraintName("FK__PURCHASES__Supli__5EBF139D");

                    b.Navigation("Suplier");
                });

            modelBuilder.Entity("Shared.Models.Purchasedetail", b =>
                {
                    b.HasOne("PuntoDeVenta_Api.Models.Product", "Product")
                        .WithMany("Purchasedetails")
                        .HasForeignKey("ProductId")
                        .IsRequired()
                        .HasConstraintName("FK__PURCHASED__Produ__619B8048");

                    b.HasOne("Shared.Models.Purchase", "Purchase")
                        .WithMany("Purchasedetails")
                        .HasForeignKey("PurchaseId")
                        .IsRequired()
                        .HasConstraintName("FK__PURCHASED__Purch__628FA481");

                    b.Navigation("Product");

                    b.Navigation("Purchase");
                });

            modelBuilder.Entity("Shared.Models.Saledetail", b =>
                {
                    b.HasOne("PuntoDeVenta_Api.Models.Product", "Product")
                        .WithMany("Saledetails")
                        .HasForeignKey("ProductId")
                        .IsRequired()
                        .HasConstraintName("FK__SALEDETAI__Produ__4CA06362");

                    b.HasOne("Shared.Models.Sales", "Sale")
                        .WithMany("Saledetails")
                        .HasForeignKey("SaleId")
                        .IsRequired()
                        .HasConstraintName("FK__SALEDETAI__SaleI__4BAC3F29");

                    b.Navigation("Product");

                    b.Navigation("Sale");
                });

            modelBuilder.Entity("Shared.Models.Sales", b =>
                {
                    b.HasOne("Shared.Models.Paymentmethod", "PaymentMethod")
                        .WithMany("Sales")
                        .HasForeignKey("PaymentMethodId")
                        .IsRequired()
                        .HasConstraintName("FK__SALES__PaymentMe__48CFD27E");

                    b.Navigation("PaymentMethod");
                });

            modelBuilder.Entity("PuntoDeVenta_Api.Models.Product", b =>
                {
                    b.Navigation("Inventories");

                    b.Navigation("Purchasedetails");

                    b.Navigation("Saledetails");
                });

            modelBuilder.Entity("Shared.Models.Category", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("Shared.Models.Paymentmethod", b =>
                {
                    b.Navigation("Sales");
                });

            modelBuilder.Entity("Shared.Models.Purchase", b =>
                {
                    b.Navigation("Purchasedetails");
                });

            modelBuilder.Entity("Shared.Models.Sales", b =>
                {
                    b.Navigation("Saledetails");
                });

            modelBuilder.Entity("Shared.Models.Suplier", b =>
                {
                    b.Navigation("Purchases");
                });
#pragma warning restore 612, 618
        }
    }
}
