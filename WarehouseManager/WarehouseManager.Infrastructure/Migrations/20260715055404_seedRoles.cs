using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WarehouseManager.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class seedRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0000-000000000000"), 0 },
                    { new Guid("00000001-0000-0000-0000-000000000000"), 1 },
                    { new Guid("00000002-0000-0000-0000-000000000000"), 2 },
                    { new Guid("00000003-0000-0000-0000-000000000000"), 3 },
                    { new Guid("00000004-0000-0000-0000-000000000000"), 4 },
                    { new Guid("00000005-0000-0000-0000-000000000000"), 5 },
                    { new Guid("00000006-0000-0000-0000-000000000000"), 6 },
                    { new Guid("00000007-0000-0000-0000-000000000000"), 7 },
                    { new Guid("00000008-0000-0000-0000-000000000000"), 8 },
                    { new Guid("00000009-0000-0000-0000-000000000000"), 9 },
                    { new Guid("0000000a-0000-0000-0000-000000000000"), 10 },
                    { new Guid("0000000b-0000-0000-0000-000000000000"), 11 },
                    { new Guid("0000000c-0000-0000-0000-000000000000"), 12 },
                    { new Guid("0000000d-0000-0000-0000-000000000000"), 13 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("00000001-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("00000002-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("00000003-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("00000004-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("00000005-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("00000006-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("00000007-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("00000008-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("00000009-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("0000000a-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("0000000b-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("0000000c-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("0000000d-0000-0000-0000-000000000000"));
        }
    }
}
