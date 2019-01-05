using Microsoft.EntityFrameworkCore.Migrations;

namespace FurryPal.Data.Migrations
{
    public partial class AddedIsBoughtPropertyToPurchase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsBought",
                table: "Purchases",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsBought",
                table: "Purchases");
        }
    }
}
