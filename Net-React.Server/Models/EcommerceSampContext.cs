using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Net_React.Server.Models;

public partial class ECommerceSampContext : DbContext
{
    public ECommerceSampContext()
    {
    }

    public ECommerceSampContext(DbContextOptions<ECommerceSampContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Address> Addresses { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=localhost;Database=ECommerceSamp;Username=postgres;Password=jdgtmg95");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Address>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("addresses_pkey");

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("'2024-09-19 09:46:39.66236'::timestamp without time zone");
            entity.Property(e => e.UpdatedAt).HasDefaultValueSql("'2024-09-19 09:46:39.662361'::timestamp without time zone");

            entity.HasOne(d => d.User).WithMany(p => p.Addresses)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("addresses_user_id_fkey");
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Category_pkey");

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("'2024-09-19 09:46:39.662361'::timestamp without time zone");
            entity.Property(e => e.UpdatedAt).HasDefaultValueSql("'2024-09-19 09:46:39.662362'::timestamp without time zone");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("products_pkey");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("CURRENT_TIMESTAMP");
            entity.Property(e => e.Quantity).HasDefaultValue(0);
            entity.Property(e => e.UpdatedAt).HasDefaultValueSql("CURRENT_TIMESTAMP");

            entity.HasOne(d => d.Category).WithMany(p => p.Products)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("products_category_id_fkey");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("users_pkey");

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("'2024-09-19 09:46:39.658845'::timestamp without time zone");
            entity.Property(e => e.PasswordHash).HasDefaultValueSql("''::text");
            entity.Property(e => e.Role).HasDefaultValueSql("''::text");
            entity.Property(e => e.UpdatedAt).HasDefaultValueSql("'2024-09-19 09:46:39.662357'::timestamp without time zone");
            entity.Property(e => e.UserName).HasDefaultValueSql("''::text");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
