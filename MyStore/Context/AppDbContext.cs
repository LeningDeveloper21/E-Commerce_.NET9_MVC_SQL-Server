using Microsoft.EntityFrameworkCore;
using MyStore.Entities;

namespace MyStore.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<User> User { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Category>(e =>
            {
                e.HasKey("CategoryId");
                e.Property("CategoryId").ValueGeneratedOnAdd();
                e.HasData(
                    new Category { CategoryId = 1, Name = "Technology" },
                    new Category { CategoryId = 2, Name = "Bedroom" }
                );
            });

            modelBuilder.Entity<Product>(e =>
            {
                e.HasKey("ProductId");
                e.Property("ProductId").ValueGeneratedOnAdd();
                e.Property("Price").HasColumnType("decimal(10, 2)");
                e.HasOne(p => p.Category)
                 .WithMany(c => c.Products)
                 .HasForeignKey(p => p.CategoryId)
                 .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<User>(e =>
            {
                e.HasKey("UserId");
                e.Property("UserId").ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<Order>(e =>
            {
                e.HasKey("OrderId");
                e.Property("OrderId").ValueGeneratedOnAdd();
                e.Property("TotalAmount").HasColumnType("decimal(10, 2)");
                e.HasOne(p => p.User)
                 .WithMany(c => c.Orders)
                 .HasForeignKey(p => p.UserId)
                 .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<OrderItem>(e =>
            {
                e.HasKey("OrderItemId");
                e.Property("OrderItemId").ValueGeneratedOnAdd();
                e.Property("Price").HasColumnType("decimal(10, 2)");
                e.HasOne(p => p.Order)
                 .WithMany(c => c.OrderItems)
                 .HasForeignKey(p => p.OrderId)
                 .OnDelete(DeleteBehavior.Restrict);
                e.HasOne(p => p.Product)
                 .WithMany()
                 .HasForeignKey(p => p.ProductId)
                 .OnDelete(DeleteBehavior.Restrict);
            });


        }

    }
}
