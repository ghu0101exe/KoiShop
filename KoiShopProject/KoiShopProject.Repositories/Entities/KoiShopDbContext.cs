using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;

namespace KoiShopProject.Repositories.Entities;

public partial class KoiShopDbContext : DbContext
{
    public KoiShopDbContext()
    {
    }

    public KoiShopDbContext(DbContextOptions<KoiShopDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Blogpost> Blogposts { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<Fish> Fish { get; set; }

    public virtual DbSet<Koifishcategory> Koifishcategories { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<Orderdetail> Orderdetails { get; set; }

    public virtual DbSet<Staff> Staff { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=localhost;port=3306;initial catalog=KoiShopDb;user=root;password=huy1105", Microsoft.EntityFrameworkCore.ServerVersion.Parse("9.0.1-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Blogpost>(entity =>
        {
            entity.HasKey(e => e.BlogId).HasName("PRIMARY");

            entity.ToTable("blogposts");

            entity.HasIndex(e => e.CustomerId, "CustomerID");

            entity.Property(e => e.BlogId)
                .ValueGeneratedNever()
                .HasColumnName("BlogID");
            entity.Property(e => e.AuthorId).HasColumnName("AuthorID");
            entity.Property(e => e.Content).HasColumnType("text");
            entity.Property(e => e.CustomerId).HasColumnName("CustomerID");
            entity.Property(e => e.Title).HasMaxLength(255);

            entity.HasOne(d => d.Customer).WithMany(p => p.Blogposts)
                .HasForeignKey(d => d.CustomerId)
                .HasConstraintName("blogposts_ibfk_1");
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.CustomerId).HasName("PRIMARY");

            entity.ToTable("customer");

            entity.Property(e => e.CustomerId).HasColumnName("CustomerID");
            entity.Property(e => e.Address).HasMaxLength(255);
            entity.Property(e => e.CustomerName).HasMaxLength(100);
            entity.Property(e => e.Password).HasMaxLength(255);
            entity.Property(e => e.Phone).HasMaxLength(12);
        });

        modelBuilder.Entity<Fish>(entity =>
        {
            entity.HasKey(e => e.KoiId).HasName("PRIMARY");

            entity.ToTable("fish");

            entity.HasIndex(e => e.IdCategory, "idCategory");

            entity.Property(e => e.KoiId).HasColumnName("KoiID");
            entity.Property(e => e.Breed).HasMaxLength(50);
            entity.Property(e => e.Gender).HasMaxLength(10);
            entity.Property(e => e.IdCategory).HasColumnName("idCategory");
            entity.Property(e => e.Image).HasMaxLength(500);
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name")
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
            entity.Property(e => e.Origin).HasMaxLength(100);

            entity.HasOne(d => d.IdCategoryNavigation).WithMany(p => p.Fish)
                .HasForeignKey(d => d.IdCategory)
                .HasConstraintName("fish_ibfk_1");
        });

        modelBuilder.Entity<Koifishcategory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("koifishcategory");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(20)
                .HasColumnName("name")
                .UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.OrderId).HasName("PRIMARY");

            entity.ToTable("orders");

            entity.HasIndex(e => e.CustomerId, "CustomerID");

            entity.HasIndex(e => e.StaffId, "StaffID");

            entity.Property(e => e.OrderId)
                .ValueGeneratedNever()
                .HasColumnName("OrderID");
            entity.Property(e => e.CustomerId).HasColumnName("CustomerID");
            entity.Property(e => e.PaymentMethod).HasMaxLength(50);
            entity.Property(e => e.StaffId).HasColumnName("StaffID");
            entity.Property(e => e.Status).HasMaxLength(50);

            entity.HasOne(d => d.Customer).WithMany(p => p.Orders)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("orders_ibfk_1");

            entity.HasOne(d => d.Staff).WithMany(p => p.Orders)
                .HasForeignKey(d => d.StaffId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("orders_ibfk_2");
        });

        modelBuilder.Entity<Orderdetail>(entity =>
        {
            entity.HasKey(e => e.OrderDetailId).HasName("PRIMARY");

            entity.ToTable("orderdetail");

            entity.HasIndex(e => e.KoiId, "KoiID");

            entity.HasIndex(e => e.OrderId, "OrderID");

            entity.Property(e => e.OrderDetailId)
                .ValueGeneratedNever()
                .HasColumnName("OrderDetailID");
            entity.Property(e => e.KoiId).HasColumnName("KoiID");
            entity.Property(e => e.OrderId).HasColumnName("OrderID");
            entity.Property(e => e.PromotionId).HasColumnName("PromotionID");
            entity.Property(e => e.SalePrice).HasPrecision(10, 2);

            entity.HasOne(d => d.Koi).WithMany(p => p.Orderdetails)
                .HasForeignKey(d => d.KoiId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("orderdetail_ibfk_2");

            entity.HasOne(d => d.Order).WithMany(p => p.Orderdetails)
                .HasForeignKey(d => d.OrderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("orderdetail_ibfk_1");
        });

        modelBuilder.Entity<Staff>(entity =>
        {
            entity.HasKey(e => e.StaffId).HasName("PRIMARY");

            entity.ToTable("staff");

            entity.Property(e => e.StaffId).HasColumnName("StaffID");
            entity.Property(e => e.Password)
                .HasMaxLength(100)
                .HasColumnName("password");
            entity.Property(e => e.StaffName).HasMaxLength(100);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
