using BreadingBread.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BreadingBread.Persistence.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(el => el.Id);
            builder.HasIndex(el => el.UserName).IsUnique();

            builder.Property(el => el.UserName)
                .IsRequired()
                .HasMaxLength(20)
                .IsUnicode(true);

            builder.Property(el => el.TokenConfirmacion)
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.Property(el => el.HashedPassword)
                .IsRequired()
                .IsUnicode(false);

            builder.Property(el => el.Aproved)
                .IsRequired()
                .IsUnicode();

            builder.Property(el => el.Name)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(true);

            builder.Property(el => el.AccessFailedCount)
                .IsRequired();

            builder.Property(el => el.LockoutEnd)
                .IsRequired();

            builder.Property(el => el.NormalizedUserName)
                .IsRequired()
                .HasMaxLength(20)
                .IsUnicode(true);
        }
    }
}
