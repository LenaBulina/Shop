using Microsoft.EntityFrameworkCore;

namespace MyShop.Backend
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
                
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Customer> Customers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .HasMany(p => p.Orders)
                .WithMany(or => or.Products)
                .UsingEntity(j => j.ToTable("ProductOrders"));

            modelBuilder.Entity<Order>()
                .HasOne(or => or.Customer)
                .WithMany(c => c.Orders)
                .HasForeignKey(or => or.CustomerId);
        }
    }
}


