using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TIMAN.Api.Migrations
{
    public partial class addLogin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "logins",
                columns: table => new
                {
                    UserName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_logins", x => x.UserName);
                });

            migrationBuilder.InsertData(
                table: "logins",
                columns: new[] { "UserName", "Password" },
                values: new object[] { "admin", "admin123" });

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2021, 11, 6, 16, 29, 39, 335, DateTimeKind.Local).AddTicks(1386));

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2021, 11, 6, 16, 29, 39, 335, DateTimeKind.Local).AddTicks(8444));

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2021, 11, 6, 16, 29, 39, 335, DateTimeKind.Local).AddTicks(8477));

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "Id",
                keyValue: 4,
                column: "DateCreated",
                value: new DateTime(2021, 11, 6, 16, 29, 39, 335, DateTimeKind.Local).AddTicks(8530));

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "Id",
                keyValue: 5,
                column: "DateCreated",
                value: new DateTime(2021, 11, 6, 16, 29, 39, 335, DateTimeKind.Local).AddTicks(8547));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "logins");

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2021, 10, 22, 23, 33, 51, 790, DateTimeKind.Local).AddTicks(7122));

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2021, 10, 22, 23, 33, 51, 791, DateTimeKind.Local).AddTicks(4501));

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateCreated",
                value: new DateTime(2021, 10, 22, 23, 33, 51, 791, DateTimeKind.Local).AddTicks(4540));

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "Id",
                keyValue: 4,
                column: "DateCreated",
                value: new DateTime(2021, 10, 22, 23, 33, 51, 791, DateTimeKind.Local).AddTicks(4558));

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "Id",
                keyValue: 5,
                column: "DateCreated",
                value: new DateTime(2021, 10, 22, 23, 33, 51, 791, DateTimeKind.Local).AddTicks(4626));
        }
    }
}
