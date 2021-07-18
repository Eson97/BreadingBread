using Microsoft.EntityFrameworkCore.Migrations;

namespace BreadingBread.Persistence.Migrations
{
    public partial class Sale : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductSale_Sale_SaleId",
                table: "ProductSale");

            migrationBuilder.DropIndex(
                name: "IX_ProductSale_SaleId",
                table: "ProductSale");

            migrationBuilder.DropColumn(
                name: "SaleId",
                table: "ProductSale");

            migrationBuilder.AddColumn<int>(
                name: "IdSale",
                table: "ProductSale",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ProductSale_IdSale",
                table: "ProductSale",
                column: "IdSale");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductSale_Sale_IdSale",
                table: "ProductSale",
                column: "IdSale",
                principalTable: "Sale",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductSale_Sale_IdSale",
                table: "ProductSale");

            migrationBuilder.DropIndex(
                name: "IX_ProductSale_IdSale",
                table: "ProductSale");

            migrationBuilder.DropColumn(
                name: "IdSale",
                table: "ProductSale");

            migrationBuilder.AddColumn<int>(
                name: "SaleId",
                table: "ProductSale",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProductSale_SaleId",
                table: "ProductSale",
                column: "SaleId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductSale_Sale_SaleId",
                table: "ProductSale",
                column: "SaleId",
                principalTable: "Sale",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
