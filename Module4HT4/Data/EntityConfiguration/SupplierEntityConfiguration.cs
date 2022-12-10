using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Module4HT4.Data.Entities;

namespace Module4HT4.Data.EntityConfiguration
{
    public class SupplierEntityConfiguration : IEntityTypeConfiguration<SupplierEntity>
    {
        public void Configure(EntityTypeBuilder<SupplierEntity> builder)
        {
            builder.Property(el => el.CompanyName).IsRequired();
            builder.Property(el => el.ContactFName).IsRequired();
            builder.Property(el => el.ContactLName).IsRequired();
            builder.HasMany(el => el.Products).WithOne(el => el.Supplier)
                .HasForeignKey(el => el.SupplierId).IsRequired();
            builder.Property(el => el.CustomerId).IsRequired();
        }
    }
}
