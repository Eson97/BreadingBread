using BreadingBread.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BreadingBread.Persistence.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(el => el.Id);


            builder.Property(el => el.Name)
             .IsRequired()
             .IsUnicode(true);

            builder.Property(el => el.Prize)
             .IsRequired();
        }
    }
}
