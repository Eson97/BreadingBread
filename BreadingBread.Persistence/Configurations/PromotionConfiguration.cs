using BreadingBread.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace BreadingBread.Persistence.Configurations
{
    public class PromotionConfiguration : IEntityTypeConfiguration<Promotion>
    {
        public void Configure(EntityTypeBuilder<Promotion> builder)
        {
            builder.HasKey(el => el.Id);

            builder.Property(el => el.CantitySaleMin)
                .IsRequired();

            builder.Property(el => el.SaleMin)
                .IsRequired();

            builder.Property(el => el.CantityFree)
                .IsRequired();

            builder.Property(el => el.Discount)
                .IsRequired();

            builder.Property(el => el.Active)
                .IsRequired();

            builder.HasOne(el => el.Product)
                .WithMany(el => el.Promotions)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
