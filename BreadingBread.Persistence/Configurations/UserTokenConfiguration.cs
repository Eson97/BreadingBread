using BreadingBread.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BreadingBread.Persistence.Configurations
{
    internal class UserTokenConfiguration : IEntityTypeConfiguration<UserToken>
    {
        public void Configure(EntityTypeBuilder<UserToken> builder)
        {
            builder.HasKey(el => el.Id);


            builder.HasIndex(el => el.IdUser);

            builder.HasIndex(el => el.RefreshToken).IsUnique(true);

            builder.Property(el => el.RefreshToken)
                .IsRequired()
                .HasMaxLength(256);

            builder.HasOne(el => el.UserNavigation)
                .WithMany(el => el.UserTokens)
                .HasForeignKey(el => el.IdUser)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UserToken_User");
        }
    }
}
