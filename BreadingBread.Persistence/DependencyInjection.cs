using BreadingBread.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Runtime.InteropServices;

namespace BreadingBread.Persistence

{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            // Add DbContext using SQL Server Provider
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                services.AddDbContext<BreadingBreadDbContext>(options =>
                    options.UseSqlServer(configuration.GetConnectionString("BreadingBreadDatabase")));
            }
            else
            {
                services.AddDbContext<BreadingBreadDbContext>(options =>
                    options.UseNpgsql(configuration.GetConnectionString("BreadingBreadDatabaseLinux")));
            }
            services.AddScoped<IBreadingBreadDbContext>(provider => provider.GetService<BreadingBreadDbContext>());
            return services;
        }
    }
}
