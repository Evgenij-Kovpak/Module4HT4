using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Module4HT4.Data.Entities;

namespace Module4HT4.Data.EntityConfiguration
{
    public class PaymentEntityConfiguration : IEntityTypeConfiguration<PaymentEntity>
    {
        public void Configure(EntityTypeBuilder<PaymentEntity> builder)
        {
            builder.Property(el => el.Type).HasDefaultValue("SomeDefaultValue");
            builder.Property(el => el.Allowed).IsRequired();
            builder.HasMany(el => el.Orders).WithOne(el => el.Payment)
                .HasForeignKey(el => el.PaymentId).IsRequired();
        }
    }
}
