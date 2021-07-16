using BreadingBread.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BreadingBread.Persistence.Configurations
{
    public class PathStoreConfiguration : IEntityTypeConfiguration<PathStore>
    {
        public void Configure(EntityTypeBuilder<PathStore> builder)
        {
            builder.HasKey(el => el.Id);

            builder.HasIndex(el => el.IdPath);

            builder.HasIndex(el => el.IdStore);

            builder.Property(el => el.Visited)
                    .IsRequired()
                    .IsUnicode(true);

            builder.HasOne(el => el.Store)
                    .WithMany(el => el.Paths)
                    .HasForeignKey(el => el.IdStore);

            builder.HasOne(el => el.Path)
                    .WithMany(el => el.PathStores)
                    .HasForeignKey(el => el.IdPath);

        }
    }
}
