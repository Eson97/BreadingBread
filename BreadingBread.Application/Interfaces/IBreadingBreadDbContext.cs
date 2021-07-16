using BreadingBread.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System.Threading;
using System.Threading.Tasks;

namespace BreadingBread.Application.Interfaces
{
    public interface IBreadingBreadDbContext
    {
        DbSet<User> User { get; set; }
        DbSet<UserToken> UserToken { get; set; }
        DbSet<Product> Product { get; set; }
        DbSet<Store> Store { get; set; }
        DbSet<Path> Path { get; set; }
        DbSet<Promotion> Promotion { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
        Task<IDbContextTransaction> BeginTransactionAsync(CancellationToken cancellationToken);
    }
}
