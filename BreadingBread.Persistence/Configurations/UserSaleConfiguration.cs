using BreadingBread.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BreadingBread.Persistence.Configurations
{
    public class UserSaleConfiguration : IEntityTypeConfiguration<UserSale>
    {
        public void Configure(EntityTypeBuilder<UserSale> builder)
        {
            builder.HasKey(el => el.Id);

            builder.HasIndex(el => el.IdPath);

            builder.HasIndex(el => el.IdUser);

            builder.Property(el => el.Visited)
                .IsRequired();


            builder.HasOne(el => el.User)
               .WithMany(el => el.UserSales)
               .HasForeignKey(el => el.IdUser)
               .OnDelete(DeleteBehavior.ClientCascade)
               .IsRequired();

            builder.HasOne(el => el.Path)
               .WithMany(el => el.UserSales)
               .HasForeignKey(el => el.IdPath)
               .OnDelete(DeleteBehavior.ClientCascade)
               .IsRequired();

        }
    }
}
