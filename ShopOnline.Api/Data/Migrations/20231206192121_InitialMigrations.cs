using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ShopOnline.Api.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigrations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Carts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductCategories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ParentCategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductCategories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductCategories_ProductCategories_ParentCategoryId",
                        column: x => x.ParentCategoryId,
                        principalTable: "ProductCategories",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    QuantityInStock = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CartItems",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CartId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CartItems_Carts_CartId",
                        column: x => x.CartId,
                        principalTable: "Carts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CartItems_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Carts",
                columns: new[] { "Id", "UserId" },
                values: new object[,]
                {
                    { new Guid("57231904-1a9b-40e6-aa24-2b553dfff1b0"), new Guid("aca965a5-2f95-4ead-b00d-25725191bf3e") },
                    { new Guid("81f68227-7f88-41ef-b4ba-bfa82974c875"), new Guid("74076fe3-548f-440c-aa95-7c5946b7964f") },
                    { new Guid("9bdf513e-91b0-4994-bc6e-4c7da68c01ba"), new Guid("10d98ec0-90ec-4f7a-be9a-781eb2561a0b") },
                    { new Guid("bbba4eac-1059-4e87-bab6-03c8dc987b31"), new Guid("0fbb2ddf-3d17-443b-a2ef-7193321a4058") }
                });

            migrationBuilder.InsertData(
                table: "ProductCategories",
                columns: new[] { "Id", "Description", "Name", "ParentCategoryId" },
                values: new object[,]
                {
                    { new Guid("86fe484d-ce15-4aa7-8602-e5a0aebce749"), "Description for Category3", "Category3", null },
                    { new Guid("a40b943e-a36a-441a-9300-a3ebbdfea2af"), "Description for Category2", "Category2", null },
                    { new Guid("ed6439e9-5944-4e66-8d5c-aa72dc841215"), "Description for Category1", "Category1", null },
                    { new Guid("f870a658-1ed2-49f8-8857-641158020c8b"), "Description for Category5", "Category5", null },
                    { new Guid("fa205792-e69e-4e43-9eac-9c20069db346"), "Description for Category4", "Category4", null }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Description", "ImageUrl", "Name", "Price", "QuantityInStock" },
                values: new object[,]
                {
                    { new Guid("188dd069-813e-48df-9af8-b6b71ce616de"), new Guid("1d2d2635-8e2d-48ef-b515-2f9a10e6ac99"), "Description for Product1", "Image1.png", "Product1", 11.99m, 51 },
                    { new Guid("1af2dd61-0332-49c3-8a83-3d9bd477d85c"), new Guid("bcb593f3-d55e-4741-b1ce-9d0ae81a0fba"), "Description for Product2", "Image2.png", "Product2", 12.99m, 52 },
                    { new Guid("9e638083-06d5-4ef0-8646-8d736f402fbc"), new Guid("26e89824-bc11-4d57-9caf-4c56a9fe1053"), "Description for Product4", "Image4.png", "Product4", 14.99m, 54 },
                    { new Guid("b2196f0f-9bf6-49c6-baaa-4819be92796a"), new Guid("c57b8a61-9eb4-4879-afba-aaf104363736"), "Description for Product3", "Image3.png", "Product3", 13.99m, 53 },
                    { new Guid("ec9ef09c-9f31-4f7a-8a69-11be86e3422d"), new Guid("4e40e13d-a415-4e61-9709-614caae50788"), "Description for Product5", "Image5.png", "Product5", 15.99m, 55 }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Username" },
                values: new object[,]
                {
                    { new Guid("0fbb2ddf-3d17-443b-a2ef-7193321a4058"), "User2" },
                    { new Guid("10d98ec0-90ec-4f7a-be9a-781eb2561a0b"), "User4" },
                    { new Guid("74076fe3-548f-440c-aa95-7c5946b7964f"), "User3" },
                    { new Guid("aca965a5-2f95-4ead-b00d-25725191bf3e"), "User1" },
                    { new Guid("c0ea0ba0-4971-4aad-9fa3-2cc9366478b8"), "User5" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CartItems_CartId",
                table: "CartItems",
                column: "CartId");

            migrationBuilder.CreateIndex(
                name: "IX_CartItems_ProductId",
                table: "CartItems",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductCategories_ParentCategoryId",
                table: "ProductCategories",
                column: "ParentCategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CartItems");

            migrationBuilder.DropTable(
                name: "ProductCategories");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Carts");

            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
