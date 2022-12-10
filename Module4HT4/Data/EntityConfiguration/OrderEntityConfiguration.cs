using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Module4HT4.Data.Entities;

namespace Module4HT4.Data.EntityConfiguration
{
    public class OrderEntityConfiguration : IEntityTypeConfiguration<OrderEntity>
    {
        public void Configure(EntityTypeBuilder<OrderEntity> builder)
        {
            builder.Property(el => el.CustomerId).IsRequired();
            builder.HasOne(el => el.Customer).WithMany(el => el.Orders)
                .HasForeignKey(el => el.CustomerId).IsRequired();
            builder.Property(el => el.PaymentId).IsRequired();
            builder.HasOne(el => el.Payment).WithMany(el => el.Orders)
                .HasForeignKey(el => el.PaymentId);
            builder.Property(el => el.ShipperId).IsRequired();
            builder.HasOne(el => el.Shipper).WithMany(el => el.Orders)
                .HasForeignKey(el => el.ShipperId).IsRequired();
            builder.Property(el => el.OrderNumber).ValueGeneratedOnAdd();
        }
    }
}
