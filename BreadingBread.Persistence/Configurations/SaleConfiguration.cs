using BreadingBread.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BreadingBread.Persistence.Configurations
{
    public class SaleConfiguration : IEntityTypeConfiguration<Sale>
    {
        public void Configure(EntityTypeBuilder<Sale> builder)
        {
            builder.HasKey(el => el.Id);

            builder.HasIndex(el => el.IdStore);

            builder.HasIndex(el => el.IdUserSale);

            builder.Property(el => el.Commentary)
            .IsRequired()
            .IsUnicode(true);

            builder.Property(el => el.Lat)
            .IsRequired()
            .IsUnicode(true);

            builder.Property(el => el.Lon)
            .IsRequired()
            .IsUnicode(true);

            builder.Property(el => el.Total)
            .IsRequired()
            .IsUnicode(true);

            builder.Property(el => el.Visited)
            .IsRequired()
            .IsUnicode(true);

            builder.HasOne(el => el.UserSale)
                .WithMany(el => el.Sales)
                .HasForeignKey(el => el.IdUserSale)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
