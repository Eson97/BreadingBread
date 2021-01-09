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
            context.Usuario.AddRange(new[] {
                new Usuario { Id = 1, NombreUsuario = "Admin", TipoUsuario = Domain.Enums.TiposUsuario.Admin, Email = "asd@asd.com"},
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
