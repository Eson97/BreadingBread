using BreadingBread.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace BreadingBread.Persistence.Configurations
{
    public class SaleUserConfiguration : IEntityTypeConfiguration<SaleUser>
    {
        public void Configure(EntityTypeBuilder<SaleUser> builder)
        {
            builder.HasKey(el => el.Id);

            builder.HasIndex(el => el.IdStore);

            builder.HasIndex(el => el.IdUser);

            builder.Property(el => el.Total)
                .IsRequired();

            builder.Property(el => el.Wastage)
                .IsRequired();

            builder.HasOne(el => el.Store)
               .WithMany(el => el.Sales)
               .HasForeignKey(el => el.IdStore)
               .OnDelete(DeleteBehavior.ClientCascade)
               .IsRequired();

            builder.HasOne(el => el.User)
               .WithMany(el => el.Sales)
               .HasForeignKey(el => el.IdUser)
               .OnDelete(DeleteBehavior.ClientCascade)
               .IsRequired();

        }
    }
}
