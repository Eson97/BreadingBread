using BreadingBread.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BreadingBread.Persistence.Configurations
{
    public class InventoryConfiguration : IEntityTypeConfiguration<Inventory>
    {
        public void Configure(EntityTypeBuilder<Inventory> builder)
        {
            builder.HasKey(el => el.Id);
            builder.HasIndex(el => el.IdProduct);
            builder.HasIndex(el => el.IdSaleUser);

            builder.Property(el => el.InitalCantity)
                .IsRequired(true);

            builder.HasOne(el => el.Product)
                .WithMany(el => el.Inventory)
                .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
