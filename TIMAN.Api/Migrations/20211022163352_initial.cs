using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TIMAN.Api.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    ThumbnailImage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_products_categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Giày nam" },
                    { 2, "Giày nữ" },
                    { 3, "Thời trang nam" },
                    { 4, "Thời trang nữ" },
                    { 5, "Thời trang bé yêu" }
                });

            migrationBuilder.InsertData(
                table: "products",
                columns: new[] { "Id", "CategoryId", "DateCreated", "Description", "Name", "Price", "ThumbnailImage" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2021, 10, 22, 23, 33, 51, 790, DateTimeKind.Local).AddTicks(7122), null, "Giày Sandal Lưới Phối Da Nam XH01", 578000m, "https://timan.vn/Thumb.ashx?s=650&file=/UploadImages/shops/giay-nam/XH01/giay-sandal-luoi-phoi-da-nam-XH01-1.jpg" },
                    { 2, 2, new DateTime(2021, 10, 22, 23, 33, 51, 791, DateTimeKind.Local).AddTicks(4501), null, "Giày Thể Thao Da Nữ SZ04", 390000m, "https://timan.vn/Thumb.ashx?s=650&file=/UploadImages/shops/giay-nu/SZ04/giay-the-thao-da-nu-SZ04-1.jpg" },
                    { 3, 3, new DateTime(2021, 10, 22, 23, 33, 51, 791, DateTimeKind.Local).AddTicks(4540), null, "Áo Blazer Nam Hàn Quốc Màu Đen", 289000m, "https://cf.shopee.vn/file/562ca3c692126d72060fab9582481c7f" },
                    { 4, 4, new DateTime(2021, 10, 22, 23, 33, 51, 791, DateTimeKind.Local).AddTicks(4558), null, "Đầm yếm kẻ sọc ca rô", 554900m, "https://cf.shopee.vn/file/1ef91962b386461ee0dd99273142772b" },
                    { 5, 5, new DateTime(2021, 10, 22, 23, 33, 51, 791, DateTimeKind.Local).AddTicks(4626), null, "Bộ quần áo thu đông trẻ em 7-17kg (1-5 tuổi) ", 39000m, "https://cf.shopee.vn/file/986dfccc518fbfd7ab7b72f070b51939" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_products_CategoryId",
                table: "products",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "products");

            migrationBuilder.DropTable(
                name: "categories");
        }
    }
}
