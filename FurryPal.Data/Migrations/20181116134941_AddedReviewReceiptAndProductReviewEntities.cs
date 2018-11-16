using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FurryPal.Data.Migrations
{
    public partial class AddedReviewReceiptAndProductReviewEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Sales_SaleId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_SubscriptionPurchases_SubscriptionPurchaseId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_SubscriptionPurchases_AspNetUsers_CustomerId",
                table: "SubscriptionPurchases");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SubscriptionPurchases",
                table: "SubscriptionPurchases");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Sales",
                table: "Sales");

            migrationBuilder.RenameTable(
                name: "SubscriptionPurchases",
                newName: "SubscribedPurchases");

            migrationBuilder.RenameTable(
                name: "Sales",
                newName: "OnSale");

            migrationBuilder.RenameIndex(
                name: "IX_SubscriptionPurchases_CustomerId",
                table: "SubscribedPurchases",
                newName: "IX_SubscribedPurchases_CustomerId");

            migrationBuilder.RenameColumn(
                name: "Type",
                table: "OnSale",
                newName: "Name");

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "Manufacturers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "OnSale",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_SubscribedPurchases",
                table: "SubscribedPurchases",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OnSale",
                table: "OnSale",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Receipts",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    PurchaseId = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Receipts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Receipts_Purchases_PurchaseId",
                        column: x => x.PurchaseId,
                        principalTable: "Purchases",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Receipts_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Reviews",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    Content = table.Column<string>(nullable: true),
                    ProductId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reviews_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProductReviews",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ProductId = table.Column<string>(nullable: true),
                    ReviewId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductReviews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductReviews_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductReviews_Reviews_ReviewId",
                        column: x => x.ReviewId,
                        principalTable: "Reviews",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductReviews_ProductId",
                table: "ProductReviews",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductReviews_ReviewId",
                table: "ProductReviews",
                column: "ReviewId");

            migrationBuilder.CreateIndex(
                name: "IX_Receipts_PurchaseId",
                table: "Receipts",
                column: "PurchaseId");

            migrationBuilder.CreateIndex(
                name: "IX_Receipts_UserId",
                table: "Receipts",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_ProductId",
                table: "Reviews",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_OnSale_SaleId",
                table: "Products",
                column: "SaleId",
                principalTable: "OnSale",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_SubscribedPurchases_SubscriptionPurchaseId",
                table: "Products",
                column: "SubscriptionPurchaseId",
                principalTable: "SubscribedPurchases",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SubscribedPurchases_AspNetUsers_CustomerId",
                table: "SubscribedPurchases",
                column: "CustomerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_OnSale_SaleId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_SubscribedPurchases_SubscriptionPurchaseId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_SubscribedPurchases_AspNetUsers_CustomerId",
                table: "SubscribedPurchases");

            migrationBuilder.DropTable(
                name: "ProductReviews");

            migrationBuilder.DropTable(
                name: "Receipts");

            migrationBuilder.DropTable(
                name: "Reviews");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SubscribedPurchases",
                table: "SubscribedPurchases");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OnSale",
                table: "OnSale");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "Manufacturers");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "OnSale");

            migrationBuilder.RenameTable(
                name: "SubscribedPurchases",
                newName: "SubscriptionPurchases");

            migrationBuilder.RenameTable(
                name: "OnSale",
                newName: "Sales");

            migrationBuilder.RenameIndex(
                name: "IX_SubscribedPurchases_CustomerId",
                table: "SubscriptionPurchases",
                newName: "IX_SubscriptionPurchases_CustomerId");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Sales",
                newName: "Type");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SubscriptionPurchases",
                table: "SubscriptionPurchases",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Sales",
                table: "Sales",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Sales_SaleId",
                table: "Products",
                column: "SaleId",
                principalTable: "Sales",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_SubscriptionPurchases_SubscriptionPurchaseId",
                table: "Products",
                column: "SubscriptionPurchaseId",
                principalTable: "SubscriptionPurchases",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SubscriptionPurchases_AspNetUsers_CustomerId",
                table: "SubscriptionPurchases",
                column: "CustomerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
