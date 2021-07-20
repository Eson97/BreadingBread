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
            SeedInventory(context);
            SeedPromotion(context);
            SeedPathStore(context);
            SeedUserSale(context);
            SeedSale(context);
            SeedSaleProduct(context);
        }
        private void SeedPathStore(BreadingBreadDbContext context)
        {
            var pathStores = new PathStore[]
            {
                new PathStore
                {
                    IdPath=1,
                    IdStore=1
                },
                new PathStore
                {
                    IdPath=1,
                    IdStore=2
                },
                new PathStore
                {
                    IdPath=1,
                    IdStore=3
                },
                new PathStore
                {
                    IdPath=1,
                    IdStore=4
                },
                new PathStore
                {
                    IdPath=2,
                    IdStore=1
                },
                new PathStore
                {
                    IdPath=2,
                    IdStore=2
                },
                new PathStore
                {
                    IdPath=3,
                    IdStore=1
                },

            };

            foreach (var pathStore in pathStores)
            {
                context.PathStore.Add(pathStore);
                context.SaveChanges();
            }
        }


        private void SeedSaleProduct(BreadingBreadDbContext context)
        {
            var productSale = new ProductSale[]
            {
                new ProductSale
                {
                    IdSale=1,
                    IdProduct=1,
                    Cantity=10,
                    UnitPrice=3,
                    Total=30
                },
                new ProductSale
                {
                    IdSale=1,
                    IdProduct=2,
                    Cantity=2,
                    UnitPrice=10,
                    Total=20,
                },
                new ProductSale
                {
                    IdSale=1,
                    IdProduct=3,
                    Cantity=10,
                    UnitPrice=10,
                    Total=30,
                    IdPromo=1,
                    ReturnCantity=2
                },
                new ProductSale
                {
                    IdSale=1,
                    IdProduct=1,
                    Cantity=10,
                    UnitPrice=3,
                    Total=9.9M,
                    IdPromo=2,
                    Discount=20.1M,
                },
                new ProductSale
                {
                    IdSale=2,
                    IdProduct=1,
                    Cantity=10,
                    UnitPrice=3,
                    Total=30
                },
                new ProductSale
                {
                    IdSale=3,
                    IdProduct=1,
                    Cantity=10,
                    UnitPrice=3,
                    Total=30
                },

            };

            foreach (var sale in productSale)
            {
                context.ProductSale.Add(sale);
                context.SaveChanges();
            }
        }

        private void SeedSale(BreadingBreadDbContext context)
        {
            var sales = new Sale[]
            {
                new Sale
                {
                  IdUserSale=1,
                  IdStore=1,
                  Total=20,
                  Visited=System.DateTime.Now,
                  Lat=1.1223,
                  Lon=-1223.22,
                },
                new Sale
                {
                  IdUserSale=1,
                  IdStore=2,
                  Total=30,
                  Visited=System.DateTime.Now,
                  Lat=1.1223,
                  Lon=-1223.22,
                },
                new Sale
                {
                  IdUserSale=1,
                  IdStore=3,
                  Total=30,
                  Visited=System.DateTime.Now,
                  Lat=1.1223,
                  Lon=-1223.22,
                },
                new Sale
                {
                  IdUserSale=2,
                  IdStore=1,
                  Total=20,
                  Visited=System.DateTime.Now.AddDays(-1),
                  Lat=1.1223,
                  Lon=-1223.22,
                },
                new Sale
                {
                  IdUserSale=3,
                  IdStore=2,
                  Total=20,
                  Visited=System.DateTime.Now.AddDays(-1),
                  Lat=1.1223,
                  Lon=-1223.22,
                },
            };

            foreach (var sale in sales)
            {
                context.Sale.Add(sale);
                context.SaveChanges();
            }
        }

        private void SeedUserSale(BreadingBreadDbContext context)
        {
            var userSales = new UserSale[]
            {
                new UserSale
                {
                    IdPath=1,
                    IdUser=1,
                    Visited=System.DateTime.Now
                },
                new UserSale
                {
                    IdPath=1,
                    IdUser=2,
                    Visited=System.DateTime.Now.AddDays(-1)
                },
                new UserSale
                {
                    IdPath=1,
                    IdUser=2,
                    Visited=System.DateTime.Now.AddDays(-1)
                },
            };

            foreach (var userSale in userSales)
            {
                context.UserSale.Add(userSale);
                context.SaveChanges();
            }
        }

        private void SeedPromotion(BreadingBreadDbContext context)
        {
            var promotions = new Promotion[]
            {
                new Promotion
                {
                    IdProducto=1,
                    CantitySaleMin=10,
                    CantityFree=1,
                    Active=true
                },
                new Promotion
                {
                    IdProducto=2,
                    CantitySaleMin=10,
                    CantityFree=1,
                    Active=false
                },
                new Promotion
                {
                    IdProducto=3,
                    CantitySaleMin=10,
                    Discount=10,
                    Active=true
                },
                new Promotion
                {
                    IdProducto=4,
                    SaleMin=300,
                    Discount=10,
                    Active=true
                },
                new Promotion
                {
                    IdProducto=5,
                    SaleMin=300,
                    CantityFree=2,
                    Active=true
                },

            };

            foreach (var promotion in promotions)
            {
                context.Promotion.Add(promotion);
                context.SaveChanges();
            }
        }

        private void SeedInventory(BreadingBreadDbContext context)
        {
            var inventories = new Inventory[]
            {
                new Inventory
                {
                    IdProduct=1,
                    IdSaleUser=1,
                    InitalCantity=100
                },
                new Inventory
                {
                    IdProduct=2,
                    IdSaleUser=1,
                    InitalCantity=100
                },
                new Inventory
                {
                    IdProduct=3,
                    IdSaleUser=1,
                    InitalCantity=100
                },
                new Inventory
                {
                    IdProduct=4,
                    IdSaleUser=1,
                    InitalCantity=100
                },
                new Inventory
                {
                    IdProduct=1,
                    IdSaleUser=2,
                    InitalCantity=100
                },
                new Inventory
                {
                    IdProduct=1,
                    IdSaleUser=2,
                    InitalCantity=100
                },

            };

            foreach (var inventory in inventories)
            {
                context.Inventory.Add(inventory);
                context.SaveChanges();
            }
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
                new Product
                {
                    Name="Dona",
                    Price=8
                },
                new Product
                {
                    Name="Panquesito",
                    Price=7
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
