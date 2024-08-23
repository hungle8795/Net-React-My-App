using Microsoft.EntityFrameworkCore;
using Net_React.Server.Models;

namespace backend.Data;

public class DataContext : DbContext
{

    protected readonly IConfiguration Configuration;

    public DataContext(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        // connect to postgres with connection string from app settings
        options.UseNpgsql(Configuration.GetConnectionString("DefaultConnection"));
    }

    public DbSet<Product> Products => Set<Product>();
    public DbSet<Category> Categories => Set<Category>();
    public DbSet<User> Users => Set<User>();
    public DbSet<Accounts> Accounts => Set<Accounts>();
    public DbSet<Tokens> Tokens => Set<Tokens>();


    //public virtual DbSet<Address> Addresses => Set<Address>();
    //public virtual DbSet<Gender> Genders => Set<Gender>();
    //public DbSet<Cart> Carts => Set<Cart>();
    //public DbSet<CartItem> CartItems => Set<CartItem>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("users_pkey");

            entity.ToTable("Users");
            entity.Property(e => e.Id).HasColumnName("id");

            //entity.HasOne(e => e.Gender)
            //    .WithMany()
            //    .HasForeignKey(d => d.GenderId)
            //    .OnDelete(DeleteBehavior.ClientSetNull)
            //    .HasConstraintName("product_details_category_id_fkey");
        });

        modelBuilder.Entity<Accounts>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("accounts_pkey");
            entity.ToTable("Account");
            entity.HasIndex(u => u.Email)
            .IsUnique();
            entity.HasMany(a => a.Tokens)
            .WithOne(t => t.Account)
            .HasForeignKey(t => t.AccountId);
        });

        modelBuilder.Entity<Tokens>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("token_pkey");

            entity.ToTable("Tokens");

            entity.Property(e => e.AccountId).HasColumnName("account_id");
            entity.HasOne(e => e.Account)
            .WithMany(p => p.Tokens)
            .HasForeignKey(pd => pd.AccountId);
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("product_pkey");

            entity.ToTable("Product");

            //entity.HasOne(d => d.Category).WithMany(p => p.Products)
            //    .HasForeignKey(d => d.CategoryId)
            //    .OnDelete(DeleteBehavior.ClientSetNull)
            //    .HasConstraintName("product_category_id_fkey");
        });

        //modelBuilder.Entity<ProductDetails>(entity =>
        //{
        //    entity.HasKey(e => e.Id).HasName("Product_Details_pkey");
        //    entity.ToTable("ProductDetails");

        //    entity.Property(e => e.ProductId).HasColumnName("product_id");
        //    entity.HasOne(e => e.Product)
        //    .WithMany(p => p.ProductDetails)
        //    .HasForeignKey(pd => pd.ProductId);
        //});

        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Category_pkey");

            entity.ToTable("Categories");
            entity.Property(e => e.Id).HasColumnName("id");
        });

        //modelBuilder.Entity<User>()
        //.HasOne(u => u.Cart)
        //.WithOne(c => c.User)
        //.HasForeignKey<Cart>(c => c.UserId);

        //modelBuilder.Entity<Address>(entity =>
        //{
        //    entity.HasKey(e => e.Id).HasName("address_pkey");
        //    entity.ToTable("Address");
        //    entity.Property(e => e.Id).HasColumnName("id");

        //    entity.HasOne(d => d.User).WithMany(p => p.Addresses)
        //        .HasForeignKey(d => d.UserId)
        //        .OnDelete(DeleteBehavior.ClientSetNull)
        //        .HasConstraintName("address_user_id_fkey");
        //});
    }

}