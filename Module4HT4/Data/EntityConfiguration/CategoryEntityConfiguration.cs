using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Module4HT4.Data.Entities;

namespace Module4HT4.Data.EntityConfiguration
{
    public class CategoryEntityConfiguration : IEntityTypeConfiguration<CategoryEntity>
    {
        public void Configure(EntityTypeBuilder<CategoryEntity> builder)
        {
            builder.Property(el => el.Name).IsRequired();
            builder.Property(el => el.Description).IsRequired();
            builder.Property(el => el.Active).HasDefaultValue(true);
            builder.HasMany(el => el.Products).WithOne(el => el.Category)
                .HasForeignKey(el => el.CategoryId).IsRequired();
        }
    }
}
