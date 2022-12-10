using Microsoft.EntityFrameworkCore;
using Module4HT4.Data.Entities;
using Module4HT4.Data.EntityConfiguration;

namespace Module4HT4.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<SupplierEntity> Suppliers { get; set; } = null!;

        public DbSet<CategoryEntity> Categories { get; set; } = null!;

        public DbSet<ProductEntity> Products { get; set; } = null!;

        public DbSet<ShipperEntity> Shippers { get; set; } = null!;

        public DbSet<CustomerEntity> Customers { get; set; } = null!;

        public DbSet<PaymentEntity> Payments { get; set; } = null!;

        public DbSet<OrderEntity> Orders { get; set; } = null!;

        public DbSet<OrderDetailsEntity> OrderDetails { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new SupplierEntityConfiguration());
            builder.ApplyConfiguration(new CategoryEntityConfiguration());
            builder.ApplyConfiguration(new ProductEntityConfiguration());
            builder.ApplyConfiguration(new ShipperEntityConfiguration());
            builder.ApplyConfiguration(new CustomerEntityConfiguration());
            builder.ApplyConfiguration(new PaymentEntityConfiguration());
            builder.ApplyConfiguration(new OrderEntityConfiguration());
            builder.ApplyConfiguration(new OrderDetailsEntityConfiguration());
            builder.UseHiLo();
        }
    }
}
