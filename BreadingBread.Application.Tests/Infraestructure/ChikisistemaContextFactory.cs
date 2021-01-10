using BreadingBread.Domain.Entities;
using BreadingBread.Infraestructure;
using BreadingBread.Persistence;
using Microsoft.EntityFrameworkCore;
using System;

namespace BreadingBread.Application.Tests.Infraestructure
{
    public class BreadingBreadDbContextFactory
    {
        public static BreadingBreadDbContext Create()
        {
            var options = new DbContextOptionsBuilder<BreadingBreadDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            var context = new BreadingBreadDbContext(options, new MachineDateTime());

            context.Database.EnsureCreated();
            context.User.AddRange(new[] {
                new User { Id = 1, UserName = "Admin", UserType = Domain.Enums.UserType.Admin},
            });

            context.SaveChanges();

            return context;
        }

        public static void Destroy(BreadingBreadDbContext context)
        {
            context.Database.EnsureDeleted();

            context.Dispose();
        }
    }
}
