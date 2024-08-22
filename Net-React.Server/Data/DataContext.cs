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

    //public DbSet<Product> Products => Set<Product>();
    //public DbSet<Category> Categories => Set<Category>();
    public DbSet<User> Users => Set<User>();
    public DbSet<Accounts> Accounts => Set<Accounts>();
    public virtual DbSet<Address> Addresses => Set<Address>();
    //public virtual DbSet<Gender> Genders => Set<Gender>();
    //public DbSet<Cart> Carts => Set<Cart>();
    //public DbSet<CartItem> CartItems => Set<CartItem>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("users_pkey");

            entity.ToTable("users");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Address)
                .HasMaxLength(255)
                .HasColumnName("address");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .HasColumnName("email");
            entity.Property(e => e.Firstname)
                .HasMaxLength(50)
                .HasColumnName("firstname");
            entity.Property(e => e.Lastname)
                .HasMaxLength(50)
                .HasColumnName("lastname");

            //entity.HasOne(e => e.Gender)
            //    .WithMany()
            //    .HasForeignKey(d => d.GenderId)
            //    .OnDelete(DeleteBehavior.ClientSetNull)
            //    .HasConstraintName("product_details_category_id_fkey");
        });

        modelBuilder.Entity<Accounts>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("accounts_pkey");

            entity.ToTable("accounts");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .HasColumnName("email");
            entity.Property(e => e.Password)
                .HasMaxLength(255)
                .HasColumnName("password");

            entity.Property(e => e.FirstName)
                .HasMaxLength(255)
                .HasColumnName("firstName");

            entity.Property(e => e.LastName)
                .HasMaxLength(255)
                .HasColumnName("lastname");
        });

        modelBuilder.Entity<Address>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("addresses_pkey");
            entity.ToTable("addresses");
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ChromeStreetaddress)
                .HasMaxLength(20)
                .HasColumnName("chrome_streetaddress");
            entity.Property(e => e.City)
                .HasMaxLength(20)
                .HasColumnName("city");
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .HasColumnName("first_name");
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .HasColumnName("last_name");
            entity.Property(e => e.PhoneNumber).HasColumnName("phone_number");
            entity.Property(e => e.Province)
                .HasMaxLength(20)
                .HasColumnName("province");
            entity.Property(e => e.Region)
                .HasMaxLength(50)
                .HasColumnName("region");
            entity.Property(e => e.RoomNumber).HasColumnName("room_number");
            entity.Property(e => e.UserId).HasColumnName("user_id");
            entity.Property(e => e.ZipCode)
                .HasMaxLength(20)
                .HasColumnName("zip_code");

            entity.HasOne(d => d.User).WithMany(p => p.Addresses)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("addresses_user_id_fkey");
        });
    }

}