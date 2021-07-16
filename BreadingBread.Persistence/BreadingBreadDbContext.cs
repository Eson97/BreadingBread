using BreadingBread.Application.Interfaces;
using BreadingBread.Common;
using BreadingBread.Domain;
using BreadingBread.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace BreadingBread.Persistence
{
    public partial class BreadingBreadDbContext : DbContext, IBreadingBreadDbContext
    {
        private readonly IDateTime time;
        public BreadingBreadDbContext(DbContextOptions<BreadingBreadDbContext> options, IDateTime time)
            : base(options)
        {
            this.time = time;
        }

        public BreadingBreadDbContext(DbContextOptions<BreadingBreadDbContext> options)
            : base(options)
        {

        }
        public bool IsSoftDeleteFilterEnabled => false;
        public virtual DbSet<User> User { get; set; }
        public DbSet<UserToken> UserToken { get; set; }
        //public DbSet<ReasonSale> ReasonSale { get; set; }
        //public DbSet<SaleUser> SaleUser { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<Store> Store { get; set; }
        public DbSet<Path> Path { get; set; }


        public Task<IDbContextTransaction> BeginTransactionAsync(CancellationToken cancellationToken)
        {
            return this.Database.BeginTransactionAsync(cancellationToken);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var entry in ChangeTracker.Entries<BaseEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.Created = time.Now;
                        break;
                    case EntityState.Modified:
                        entry.Entity.Modified = time.Now;
                        break;
                    case EntityState.Deleted:
                        if (entry.Entity is DeleteableEntity deleaetableEntity)
                        {
                            entry.State = EntityState.Modified;
                            deleaetableEntity.DeletedDate = time.Now;
                            deleaetableEntity.IsDeleted = true;
                        }
                        break;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(BreadingBreadDbContext).Assembly);

            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                if (typeof(DeleteableEntity).IsAssignableFrom(entityType.ClrType))
                {
                    modelBuilder.Entity(entityType.ClrType).AddQueryFilter<DeleteableEntity>(e => IsSoftDeleteFilterEnabled == false || e.IsDeleted == false);
                }
            }

            // Si la entidad es de tipo DateTime se encarga de convertirlo a UTC
            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                foreach (var property in entityType.GetProperties())
                {
                    if (property.ClrType == typeof(DateTime))
                    {
                        modelBuilder.Entity(entityType.ClrType)
                         .Property<DateTime>(property.Name)
                         .HasConversion(
                          v => v.ToUniversalTime(),
                          v => DateTime.SpecifyKind(v, DateTimeKind.Utc));
                    }
                    else if (property.ClrType == typeof(DateTime?))
                    {
                        modelBuilder.Entity(entityType.ClrType)
                         .Property<DateTime?>(property.Name)
                         .HasConversion(
                          v => v.HasValue ? v.Value.ToUniversalTime() : v,
                          v => v.HasValue ? DateTime.SpecifyKind(v.Value, DateTimeKind.Utc) : v);
                    }
                }
            }
        }
    }
}
