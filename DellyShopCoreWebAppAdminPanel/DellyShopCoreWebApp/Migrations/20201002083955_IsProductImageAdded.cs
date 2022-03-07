using Microsoft.EntityFrameworkCore.Migrations;

namespace DellyShopCoreWebAppAdminPanel.Migrations
{
    public partial class IsProductImageAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsProductImage",
                table: "ImageModels",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsProductImage",
                table: "ImageModels");
        }
    }
}
