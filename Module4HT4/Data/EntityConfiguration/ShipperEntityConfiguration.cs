using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Module4HT4.Data.Entities;

namespace Module4HT4.Data.EntityConfiguration
{
    public class ShipperEntityConfiguration : IEntityTypeConfiguration<ShipperEntity>
    {
        public void Configure(EntityTypeBuilder<ShipperEntity> builder)
        {
            builder.Property(el => el.CompanyName).IsRequired();
            builder.HasMany(el => el.Orders).WithOne(el => el.Shipper)
                .HasForeignKey(el => el.ShipperId).IsRequired();
        }
    }
}
