using BreadingBread.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BreadingBread.Persistence.Configurations
{
    public class ProductSaleConfiguration : IEntityTypeConfiguration<ProductSale>
    {
        public void Configure(EntityTypeBuilder<ProductSale> builder)
        {
            builder.HasKey(el => el.Id);

            builder.HasIndex(el => el.IdSale);

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

            builder.HasOne(el => el.Sale)
                .WithMany(el => el.Products)
                .HasForeignKey(el => el.IdSale)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();
        }
    }
}
