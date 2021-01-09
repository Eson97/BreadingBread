using BreadingBread.Persistence.Infraestructure;
using Microsoft.EntityFrameworkCore;

namespace BreadingBread.Persistence
{
    public class BreadingBreadDbContextFactory : DesignTimeDbContextFactoryBase<BreadingBreadDbContext>
    {
        protected override BreadingBreadDbContext CreateNewInstance(DbContextOptions<BreadingBreadDbContext> options)
        {
            return new BreadingBreadDbContext(options);
        }
    }
}
