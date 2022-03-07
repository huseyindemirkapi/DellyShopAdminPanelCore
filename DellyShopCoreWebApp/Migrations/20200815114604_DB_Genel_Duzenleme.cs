using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DellyShopCoreWebAppAdminPanel.Migrations
{
    public partial class DB_Genel_Duzenleme : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProductImage",
                table: "Products");

            migrationBuilder.AddColumn<int>(
                name: "LastViewId",
                table: "Products",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MyFavoriteId",
                table: "Products",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "Products",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "BirthDay",
                table: "Customers",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<byte[]>(
                name: "CategoryBGImage",
                table: "Categories",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "CreditCards",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CardNumber = table.Column<string>(nullable: true),
                    ExpirationDate = table.Column<DateTime>(nullable: false),
                    CustomerId = table.Column<int>(nullable: false),
                    CustomerId1 = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CreditCards", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CreditCards_Customers_CustomerId1",
                        column: x => x.CustomerId1,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ImageModels",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Images = table.Column<byte[]>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    ProductId = table.Column<int>(nullable: false),
                    CategoryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImageModels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ImageModels_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ImageModels_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LastViews",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerId = table.Column<int>(nullable: false),
                    CustomerId1 = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LastViews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LastViews_Customers_CustomerId1",
                        column: x => x.CustomerId1,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MyFavorites",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerId = table.Column<int>(nullable: false),
                    CustomerId1 = table.Column<Guid>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MyFavorites", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MyFavorites_Customers_CustomerId1",
                        column: x => x.CustomerId1,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Notifications",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notifications", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_LastViewId",
                table: "Products",
                column: "LastViewId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_MyFavoriteId",
                table: "Products",
                column: "MyFavoriteId");

            migrationBuilder.CreateIndex(
                name: "IX_CreditCards_CustomerId1",
                table: "CreditCards",
                column: "CustomerId1");

            migrationBuilder.CreateIndex(
                name: "IX_ImageModels_CategoryId",
                table: "ImageModels",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ImageModels_ProductId",
                table: "ImageModels",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_LastViews_CustomerId1",
                table: "LastViews",
                column: "CustomerId1");

            migrationBuilder.CreateIndex(
                name: "IX_MyFavorites_CustomerId1",
                table: "MyFavorites",
                column: "CustomerId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_LastViews_LastViewId",
                table: "Products",
                column: "LastViewId",
                principalTable: "LastViews",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_MyFavorites_MyFavoriteId",
                table: "Products",
                column: "MyFavoriteId",
                principalTable: "MyFavorites",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_LastViews_LastViewId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_MyFavorites_MyFavoriteId",
                table: "Products");

            migrationBuilder.DropTable(
                name: "CreditCards");

            migrationBuilder.DropTable(
                name: "ImageModels");

            migrationBuilder.DropTable(
                name: "LastViews");

            migrationBuilder.DropTable(
                name: "MyFavorites");

            migrationBuilder.DropTable(
                name: "Notifications");

            migrationBuilder.DropIndex(
                name: "IX_Products_LastViewId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_MyFavoriteId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "LastViewId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "MyFavoriteId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "BirthDay",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "CategoryBGImage",
                table: "Categories");

            migrationBuilder.AddColumn<byte[]>(
                name: "ProductImage",
                table: "Products",
                type: "varbinary(max)",
                nullable: true);
        }
    }
}
