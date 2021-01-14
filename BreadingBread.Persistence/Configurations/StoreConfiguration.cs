using BreadingBread.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BreadingBread.Persistence.Configurations
{
    public class StoreConfiguration : IEntityTypeConfiguration<Store>
    {
        public void Configure(EntityTypeBuilder<Store> builder)
        {
            builder.HasKey(el => el.Id);

            builder.HasIndex(el => el.IdPath);

            builder.Property(el => el.Name)
            .IsRequired()
            .IsUnicode(true);

            builder.Property(el => el.Lat)
                .IsRequired(false);

            builder.Property(el => el.Long)
                .IsRequired(false);

            builder.HasOne(el => el.Path)
                .WithMany(el => el.Stores)
                .HasForeignKey(el => el.IdPath);
        }
    }
}
