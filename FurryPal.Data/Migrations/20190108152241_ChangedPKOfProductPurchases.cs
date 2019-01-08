using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FurryPal.Data.Migrations
{
    public partial class ChangedPKOfProductPurchases : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductsPurchases_Products_ProductId",
                table: "ProductsPurchases");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductsPurchases_Purchases_PurchaseId",
                table: "ProductsPurchases");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductsPurchases",
                table: "ProductsPurchases");

            migrationBuilder.AlterColumn<string>(
                name: "PurchaseId",
                table: "ProductsPurchases",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "ProductId",
                table: "ProductsPurchases",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "ProductsPurchases",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductsPurchases",
                table: "ProductsPurchases",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_ProductsPurchases_ProductId",
                table: "ProductsPurchases",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductsPurchases_Products_ProductId",
                table: "ProductsPurchases",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductsPurchases_Purchases_PurchaseId",
                table: "ProductsPurchases",
                column: "PurchaseId",
                principalTable: "Purchases",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductsPurchases_Products_ProductId",
                table: "ProductsPurchases");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductsPurchases_Purchases_PurchaseId",
                table: "ProductsPurchases");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductsPurchases",
                table: "ProductsPurchases");

            migrationBuilder.DropIndex(
                name: "IX_ProductsPurchases_ProductId",
                table: "ProductsPurchases");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "ProductsPurchases");

            migrationBuilder.AlterColumn<string>(
                name: "PurchaseId",
                table: "ProductsPurchases",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ProductId",
                table: "ProductsPurchases",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductsPurchases",
                table: "ProductsPurchases",
                columns: new[] { "ProductId", "PurchaseId" });

            migrationBuilder.AddForeignKey(
                name: "FK_ProductsPurchases_Products_ProductId",
                table: "ProductsPurchases",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductsPurchases_Purchases_PurchaseId",
                table: "ProductsPurchases",
                column: "PurchaseId",
                principalTable: "Purchases",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
