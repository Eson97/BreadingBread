using BreadingBread.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BreadingBread.Persistence.Configurations
{
    public class ReasonSaleConfiguration : IEntityTypeConfiguration<ReasonSale>
    {
        public void Configure(EntityTypeBuilder<ReasonSale> builder)
        {
            {
                builder.HasKey(el => el.Id);

                builder.HasIndex(el => el.IdSaleUser);

                builder.Property(el => el.Description)
                    .IsRequired()
                    .IsUnicode(true);

                builder.Property(el => el.Lat)
                    .IsRequired();

                builder.Property(el => el.Lat)
                    .IsRequired();

                builder.HasOne(b => b.SaleUser)
                    .WithOne(i => i.Reason)
                    .HasForeignKey<ReasonSale>(b => b.IdSaleUser);
            }
        }
    }
}