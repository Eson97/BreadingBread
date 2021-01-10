using BreadingBread.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace BreadingBread.Persistence.Configurations
{
    public class SaleProductConfiguration : IEntityTypeConfiguration<SaleProduct>
    {
        public void Configure(EntityTypeBuilder<SaleProduct> builder)
        {
            builder.HasKey(el => el.Id);

            builder.HasIndex(el => el.IdProduct);

            builder.HasIndex(el => el.IdSaleUser);

            builder.Property(el => el.Cantity)
                .IsRequired();

            builder.Property(el => el.Prize)
                .IsRequired();

            builder.HasOne(el => el.Product)
                .WithMany(el => el.SaleProducts)
                .HasForeignKey(el => el.IdProduct)
                .IsRequired();

            builder.HasOne(el => el.SaleUser)
                .WithMany(el => el.SaleProducts)
                .HasForeignKey(el => el.IdSaleUser)
                .IsRequired();
        }
    }
}
