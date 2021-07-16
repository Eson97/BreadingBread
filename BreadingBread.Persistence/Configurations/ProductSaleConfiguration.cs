using BreadingBread.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace BreadingBread.Persistence.Configurations
{
    public class ProductSaleConfiguration : IEntityTypeConfiguration<ProductSale>
    {
        public void Configure(EntityTypeBuilder<ProductSale> builder)
        {
            builder.HasKey(el => el.Id);

            builder.HasIndex(el => el.IdProduct);

            builder.Property(el => el.PromoCantity)
                .IsRequired();

            builder.Property(el => el.ReturnCantity)
                .IsRequired();

            builder.Property(el => el.Discount)
                .IsRequired();

            builder.Property(el => el.Cantity)
                .IsRequired();

            builder.Property(el => el.UnitPrice)
                .IsRequired();

            builder.Property(el => el.Total)
                .IsRequired();

            builder.HasOne(el => el.Product)
                .WithMany(el => el.SaleProducts)
                .HasForeignKey(el => el.IdProduct)
                .IsRequired();
        }
    }
}
