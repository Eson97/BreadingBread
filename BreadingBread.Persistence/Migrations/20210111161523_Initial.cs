using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BreadingBread.Persistence.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedDate = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(nullable: false),
                    Prize = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: true),
                    UserName = table.Column<string>(maxLength: 20, nullable: false),
                    HashedPassword = table.Column<string>(unicode: false, nullable: false),
                    UserType = table.Column<int>(nullable: false),
                    Aproved = table.Column<bool>(nullable: false),
                    TokenConfirmacion = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    LockoutEnd = table.Column<DateTime>(nullable: false),
                    NormalizedUserName = table.Column<string>(maxLength: 20, nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Path",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedDate = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(nullable: false),
                    Selected = table.Column<bool>(nullable: false),
                    IdUser = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Path", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Path_User_IdUser",
                        column: x => x.IdUser,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserToken",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: true),
                    IdUser = table.Column<int>(nullable: false),
                    RefreshToken = table.Column<string>(maxLength: 256, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserToken", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserToken_User",
                        column: x => x.IdUser,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Store",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedDate = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(nullable: false),
                    Lat = table.Column<double>(nullable: false),
                    Long = table.Column<double>(nullable: false),
                    IdPath = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Store", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Store_Path_IdPath",
                        column: x => x.IdPath,
                        principalTable: "Path",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SaleUser",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: true),
                    Total = table.Column<decimal>(nullable: false),
                    Wastage = table.Column<decimal>(nullable: false),
                    IdUser = table.Column<int>(nullable: false),
                    IdStore = table.Column<int>(nullable: false)
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
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: true),
                    Description = table.Column<string>(nullable: false),
                    Lat = table.Column<double>(nullable: false),
                    Long = table.Column<double>(nullable: false),
                    IdSaleUser = table.Column<int>(nullable: false)
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
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: true),
                    Cantity = table.Column<int>(nullable: false),
                    Prize = table.Column<decimal>(nullable: false),
                    IdSaleUser = table.Column<int>(nullable: false),
                    IdProduct = table.Column<int>(nullable: false)
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
                name: "IX_Path_IdUser",
                table: "Path",
                column: "IdUser",
                unique: true,
                filter: "[IdUser] IS NOT NULL");

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

            migrationBuilder.CreateIndex(
                name: "IX_Store_IdPath",
                table: "Store",
                column: "IdPath");

            migrationBuilder.CreateIndex(
                name: "IX_User_UserName",
                table: "User",
                column: "UserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserToken_IdUser",
                table: "UserToken",
                column: "IdUser");

            migrationBuilder.CreateIndex(
                name: "IX_UserToken_RefreshToken",
                table: "UserToken",
                column: "RefreshToken",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ReasonSale");

            migrationBuilder.DropTable(
                name: "SaleProduct");

            migrationBuilder.DropTable(
                name: "UserToken");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "SaleUser");

            migrationBuilder.DropTable(
                name: "Store");

            migrationBuilder.DropTable(
                name: "Path");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
