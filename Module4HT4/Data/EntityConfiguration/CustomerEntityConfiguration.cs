using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Module4HT4.Data.Entities;

namespace Module4HT4.Data.EntityConfiguration
{
    public class CustomerEntityConfiguration : IEntityTypeConfiguration<CustomerEntity>
    {
        public void Configure(EntityTypeBuilder<CustomerEntity> builder)
        {
            builder.Property(el => el.FirstName).IsRequired();
            builder.Property(el => el.LastName).IsRequired();
            builder.HasMany(el => el.Orders).WithOne(el => el.Customer)
                .HasForeignKey(el => el.CustomerId).IsRequired();
        }
    }
}
