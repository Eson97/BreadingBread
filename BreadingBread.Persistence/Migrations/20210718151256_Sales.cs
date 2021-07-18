using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BreadingBread.Persistence.Migrations
{
    public partial class Sales : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Store_Path_IdPath",
                table: "Store");

            migrationBuilder.DropTable(
                name: "ReasonSale");

            migrationBuilder.DropTable(
                name: "SaleProduct");

            migrationBuilder.DropTable(
                name: "SaleUser");

            migrationBuilder.DropIndex(
                name: "IX_Store_IdPath",
                table: "Store");

            migrationBuilder.DropColumn(
                name: "IdPath",
                table: "Store");

            migrationBuilder.CreateTable(
                name: "PathStore",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedDate = table.Column<DateTime>(nullable: true),
                    IdPath = table.Column<int>(nullable: false),
                    IdStore = table.Column<int>(nullable: false),
                    Visited = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PathStore", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PathStore_Path_IdPath",
                        column: x => x.IdPath,
                        principalTable: "Path",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PathStore_Store_IdStore",
                        column: x => x.IdStore,
                        principalTable: "Store",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Promotion",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedDate = table.Column<DateTime>(nullable: true),
                    IdProducto = table.Column<int>(nullable: false),
                    CantitySaleMin = table.Column<int>(nullable: false),
                    SaleMin = table.Column<decimal>(nullable: false),
                    CantityFree = table.Column<int>(nullable: false),
                    Discount = table.Column<int>(nullable: false),
                    Active = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Promotion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Promotion_Product_IdProducto",
                        column: x => x.IdProducto,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserSale",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: true),
                    IdUser = table.Column<int>(nullable: false),
                    IdPath = table.Column<int>(nullable: false),
                    Visited = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserSale", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserSale_Path_IdPath",
                        column: x => x.IdPath,
                        principalTable: "Path",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserSale_User_IdUser",
                        column: x => x.IdUser,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Inventory",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: true),
                    IdSaleUser = table.Column<int>(nullable: false),
                    IdProduct = table.Column<int>(nullable: false),
                    InitalCantity = table.Column<int>(nullable: false),
                    ProductId = table.Column<int>(nullable: true),
                    UserSaleId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inventory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Inventory_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Inventory_UserSale_UserSaleId",
                        column: x => x.UserSaleId,
                        principalTable: "UserSale",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Sale",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: true),
                    IdUserSale = table.Column<int>(nullable: false),
                    IdStore = table.Column<int>(nullable: false),
                    Visited = table.Column<DateTime>(nullable: false),
                    Lat = table.Column<double>(nullable: false),
                    Lon = table.Column<double>(nullable: false),
                    Total = table.Column<decimal>(nullable: false),
                    Commentary = table.Column<string>(nullable: false),
                    StoreVisitedId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sale", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sale_UserSale_IdUserSale",
                        column: x => x.IdUserSale,
                        principalTable: "UserSale",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Sale_Store_StoreVisitedId",
                        column: x => x.StoreVisitedId,
                        principalTable: "Store",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProductSale",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: true),
                    IdPromo = table.Column<int>(nullable: true),
                    IdProduct = table.Column<int>(nullable: false),
                    Cantity = table.Column<int>(nullable: false),
                    PromoCantity = table.Column<int>(nullable: false),
                    ReturnCantity = table.Column<int>(nullable: false),
                    Discount = table.Column<decimal>(nullable: false),
                    UnitPrice = table.Column<decimal>(nullable: false),
                    Total = table.Column<decimal>(nullable: false),
                    SaleId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductSale", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductSale_Product_IdProduct",
                        column: x => x.IdProduct,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductSale_Sale_SaleId",
                        column: x => x.SaleId,
                        principalTable: "Sale",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Inventory_IdProduct",
                table: "Inventory",
                column: "IdProduct");

            migrationBuilder.CreateIndex(
                name: "IX_Inventory_IdSaleUser",
                table: "Inventory",
                column: "IdSaleUser");

            migrationBuilder.CreateIndex(
                name: "IX_Inventory_ProductId",
                table: "Inventory",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Inventory_UserSaleId",
                table: "Inventory",
                column: "UserSaleId");

            migrationBuilder.CreateIndex(
                name: "IX_PathStore_IdPath",
                table: "PathStore",
                column: "IdPath");

            migrationBuilder.CreateIndex(
                name: "IX_PathStore_IdStore",
                table: "PathStore",
                column: "IdStore");

            migrationBuilder.CreateIndex(
                name: "IX_ProductSale_IdProduct",
                table: "ProductSale",
                column: "IdProduct");

            migrationBuilder.CreateIndex(
                name: "IX_ProductSale_SaleId",
                table: "ProductSale",
                column: "SaleId");

            migrationBuilder.CreateIndex(
                name: "IX_Promotion_IdProducto",
                table: "Promotion",
                column: "IdProducto");

            migrationBuilder.CreateIndex(
                name: "IX_Sale_IdStore",
                table: "Sale",
                column: "IdStore");

            migrationBuilder.CreateIndex(
                name: "IX_Sale_IdUserSale",
                table: "Sale",
                column: "IdUserSale");

            migrationBuilder.CreateIndex(
                name: "IX_Sale_StoreVisitedId",
                table: "Sale",
                column: "StoreVisitedId");

            migrationBuilder.CreateIndex(
                name: "IX_UserSale_IdPath",
                table: "UserSale",
                column: "IdPath");

            migrationBuilder.CreateIndex(
                name: "IX_UserSale_IdUser",
                table: "UserSale",
                column: "IdUser");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Inventory");

            migrationBuilder.DropTable(
                name: "PathStore");

            migrationBuilder.DropTable(
                name: "ProductSale");

            migrationBuilder.DropTable(
                name: "Promotion");

            migrationBuilder.DropTable(
                name: "Sale");

            migrationBuilder.DropTable(
                name: "UserSale");

            migrationBuilder.AddColumn<int>(
                name: "IdPath",
                table: "Store",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "SaleUser",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdStore = table.Column<int>(type: "int", nullable: false),
                    IdUser = table.Column<int>(type: "int", nullable: false),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Total = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Wastage = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SaleUser", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SaleUser_Store_IdStore",
                        column: x => x.IdStore,
                        principalTable: "Store",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SaleUser_User_IdUser",
                        column: x => x.IdUser,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ReasonSale",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdSaleUser = table.Column<int>(type: "int", nullable: false),
                    Lat = table.Column<double>(type: "float", nullable: false),
                    Long = table.Column<double>(type: "float", nullable: false),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReasonSale", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReasonSale_SaleUser_IdSaleUser",
                        column: x => x.IdSaleUser,
                        principalTable: "SaleUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SaleProduct",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cantity = table.Column<int>(type: "int", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdProduct = table.Column<int>(type: "int", nullable: false),
                    IdSaleUser = table.Column<int>(type: "int", nullable: false),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SaleProduct", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SaleProduct_Product_IdProduct",
                        column: x => x.IdProduct,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SaleProduct_SaleUser_IdSaleUser",
                        column: x => x.IdSaleUser,
                        principalTable: "SaleUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Store_IdPath",
                table: "Store",
                column: "IdPath");

            migrationBuilder.CreateIndex(
                name: "IX_ReasonSale_IdSaleUser",
                table: "ReasonSale",
                column: "IdSaleUser",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SaleProduct_IdProduct",
                table: "SaleProduct",
                column: "IdProduct");

            migrationBuilder.CreateIndex(
                name: "IX_SaleProduct_IdSaleUser",
                table: "SaleProduct",
                column: "IdSaleUser");

            migrationBuilder.CreateIndex(
                name: "IX_SaleUser_IdStore",
                table: "SaleUser",
                column: "IdStore");

            migrationBuilder.CreateIndex(
                name: "IX_SaleUser_IdUser",
                table: "SaleUser",
                column: "IdUser");

            migrationBuilder.AddForeignKey(
                name: "FK_Store_Path_IdPath",
                table: "Store",
                column: "IdPath",
                principalTable: "Path",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
