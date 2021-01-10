using BreadingBread.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BreadingBread.Persistence.Configurations
{
    public class PathConfiguration : IEntityTypeConfiguration<Path>
    {
        public void Configure(EntityTypeBuilder<Path> builder)
        {
            builder.HasKey(el => el.Id);

            builder.HasIndex(el => el.IdUser);

            builder.Property(el => el.Name)
            .IsRequired()
            .IsUnicode(true);

            builder.HasOne(el => el.CurrentUser)
                .WithOne(el => el.Path)
                .HasForeignKey<Path>(el => el.IdUser);
        }
    }
}
