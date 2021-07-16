using BreadingBread.Domain.Entities;
using System.Linq;

namespace BreadingBread.Persistence
{
    public class BreadingBreadDbInitializer
    {
        public static void Initialize(BreadingBreadDbContext context)
        {
            var initializer = new BreadingBreadDbInitializer();
            initializer.SeedEverything(context);
        }

        public void SeedEverything(BreadingBreadDbContext context)
        {
            context.Database.EnsureCreated();

            if (context.User.Any())
            {
                return; // Db has been seeded
            }
            SeedUsuario(context);
            SeedPaths(context);
            SeedStores(context);
            SeedProducts(context);
            //TODO Add sales to seed
        }

        private void SeedStores(BreadingBreadDbContext context)
        {
            var stores = new Store[]
            {
                new Store
                {
                    Name="La Esquinita",
                },
                new Store
                {
                    Name="El atoron",
                },
                new Store
                {
                    Name="La tienda de don juan",
                },
            };

            foreach (var store in stores)
            {
                context.Store.Add(store);
                context.SaveChanges();
            }
        }

        private void SeedPaths(BreadingBreadDbContext context)
        {
            var paths = new Path[]
            {
                new Path
                {
                    Name="Ruta 1",
                },
                new Path
                {
                    Name="Ruta 2",
                },
                new Path
                {
                    Name="Ruta 3",
                },
            };

            foreach (var path in paths)
            {
                context.Path.Add(path);
                context.SaveChanges();
            }
        }

        private void SeedProducts(BreadingBreadDbContext context)
        {
            var products = new Product[]
            {
                new Product
                {
                    Name="Pan grande bolillo mamalon",
                    Price=15
                },
                new Product
                {
                    Name="Bolillo chico",
                    Price=5
                },
                new Product
                {
                    Name="Concha",
                    Price=6
                },
                new Product
                {
                    Name="Gollete",
                    Price=10
                },
            };

            foreach (var product in products)
            {
                context.Product.Add(product);
                context.SaveChanges();
            }
        }


        private void SeedUsuario(BreadingBreadDbContext db)
        {
            var usuarios = new User[]
            {
                new User
                {
                    // Id = 1,
                    UserName = "Admin",
                    UserType = Domain.Enums.UserType.Admin,
                    HashedPassword = "sha1:64000:18:GDo9HgM4Ke1BNgkIkvG1wlejZAS0qlpG:BPesev8ueqRpNVojKKcJMwDD",
                    Aproved = true,
                    TokenConfirmacion = "",
                    Name = "Nombre APaterno AMaterno Completo",
                    NormalizedUserName = "ADMIN"
                },
                new User
                {
                    // Id = 2,
                    UserName = "User",
                    UserType = Domain.Enums.UserType.User,
                    HashedPassword = "sha1:64000:18:GDo9HgM4Ke1BNgkIkvG1wlejZAS0qlpG:BPesev8ueqRpNVojKKcJMwDD",
                    Aproved = true,
                    TokenConfirmacion = "",
                    Name = "Nombre",
                    NormalizedUserName = "Nombre"
                },
                new User
                {
                    UserName = "User2",
                    UserType = Domain.Enums.UserType.User,
                    HashedPassword = "sha1:64000:18:GDo9HgM4Ke1BNgkIkvG1wlejZAS0qlpG:BPesev8ueqRpNVojKKcJMwDD",
                    Aproved = false,
                    TokenConfirmacion = "",
                    Name = "Usuario2 ",
                    NormalizedUserName = "USUARIO2"
                },
            };

            foreach (var usuario in usuarios)
            {
                db.User.Add(usuario);
                db.SaveChanges();
            }
        }
    }
}
