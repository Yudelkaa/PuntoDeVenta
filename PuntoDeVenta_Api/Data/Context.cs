using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Shared.Models;

namespace PuntoDeVenta_Api.Data;
public partial class Context : DbContext
{
    public Context()
    {
    }

    public Context(DbContextOptions<Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Inventory> Inventories { get; set; }

    public virtual DbSet<Paymentmethod> Paymentmethods { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<Purchase> Purchases { get; set; }

    public virtual DbSet<Purchasedetail> Purchasedetails { get; set; }

    public virtual DbSet<Sales> Sales { get; set; }

    public virtual DbSet<Saledetail> Saledetails { get; set; }

    public virtual DbSet<Suplier> Supliers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=BRAYLIN;Database=SISTEMAVENTAS;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.CategoryId).HasName("PK__CATEGORI__19093A0B5132E779");

            entity.Property(e => e.CategoryId).ValueGeneratedNever();
        });

        modelBuilder.Entity<Inventory>(entity =>
        {
            entity.HasKey(e => e.InventoryId).HasName("PK__INVENTOR__F5FDE6B38CB3E2D9");

            entity.Property(e => e.InventoryId).ValueGeneratedNever();

            entity.HasOne(d => d.Product).WithMany(p => p.Inventories)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__INVENTORY__Produ__656C112C");
        });

        modelBuilder.Entity<Paymentmethod>(entity =>
        {
            entity.HasKey(e => e.PaymentMethodId).HasName("PK__PAYMENTM__DC31C1D351B7B089");

            entity.Property(e => e.PaymentMethodId).ValueGeneratedNever();
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.ProductId).HasName("PK__PRODUCTS__B40CC6CD3AD54279");

            entity.Property(e => e.ProductId).ValueGeneratedNever();

            entity.HasOne(d => d.Category).WithMany(p => p.Products).HasConstraintName("FK__PRODUCTS__Catego__440B1D61");
        });

        modelBuilder.Entity<Purchase>(entity =>
        {
            entity.HasKey(e => e.PurchaseId).HasName("PK__PURCHASE__6B0A6BBE44DAE336");

            entity.Property(e => e.PurchaseId).ValueGeneratedNever();

            entity.HasOne(d => d.Suplier).WithMany(p => p.Purchases)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__PURCHASES__Supli__5EBF139D");
        });

        modelBuilder.Entity<Purchasedetail>(entity =>
        {
            entity.HasKey(e => e.DetailId).HasName("PK__PURCHASE__135C316D22F8D778");

            entity.Property(e => e.DetailId).ValueGeneratedNever();

            entity.HasOne(d => d.Product).WithMany(p => p.Purchasedetails)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__PURCHASED__Produ__619B8048");

            entity.HasOne(d => d.Purchase).WithMany(p => p.Purchasedetails)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__PURCHASED__Purch__628FA481");
        });

        modelBuilder.Entity<Sales>(entity =>
        {
            entity.HasKey(e => e.SaleId).HasName("PK__SALES__1EE3C3FFA2BAB9F2");

            entity.Property(e => e.SaleId).ValueGeneratedNever();

            entity.HasOne(d => d.PaymentMethod).WithMany(p => p.Sales)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__SALES__PaymentMe__48CFD27E");
        });

        modelBuilder.Entity<Saledetail>(entity =>
        {
            entity.HasKey(e => e.DetailId).HasName("PK__SALEDETA__135C316D5FF9200A");

            entity.Property(e => e.DetailId).ValueGeneratedNever();

            entity.HasOne(d => d.Product).WithMany(p => p.Saledetails)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__SALEDETAI__Produ__4CA06362");

            entity.HasOne(d => d.Sale).WithMany(p => p.Saledetails)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__SALEDETAI__SaleI__4BAC3F29");
        });

        modelBuilder.Entity<Suplier>(entity =>
        {
            entity.HasKey(e => e.SuplierId).HasName("PK__SUPLIERS__1AD74ADD3FD3A0B6");

            entity.Property(e => e.SuplierId).ValueGeneratedNever();
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
