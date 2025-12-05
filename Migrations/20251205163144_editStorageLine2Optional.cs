using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DotNetWebAPIDefault.Migrations
{
    /// <inheritdoc />
    public partial class editStorageLine2Optional : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "328e599e-b897-4537-877a-53d9301a82fb");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3e6554ac-3f52-47d3-a1fb-8642e5b52910");

            migrationBuilder.AlterColumn<string>(
                name: "Line2",
                table: "Storages",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "6cd2b7b9-8016-44b9-adc6-4423b8ee5cfb", "740b4160-a26c-415a-8eec-eb6635bdd02f", "Admin", "ADMIN" },
                    { "f18e4106-84c2-425a-9f56-17793e1a3a14", "4ffd95a3-22dc-4f11-9d10-aa8392b5c66b", "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6cd2b7b9-8016-44b9-adc6-4423b8ee5cfb");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f18e4106-84c2-425a-9f56-17793e1a3a14");

            migrationBuilder.AlterColumn<string>(
                name: "Line2",
                table: "Storages",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "328e599e-b897-4537-877a-53d9301a82fb", "4661597b-48ad-4e90-b389-2bac6984ca50", "User", "USER" },
                    { "3e6554ac-3f52-47d3-a1fb-8642e5b52910", "2a2f11e4-8883-4f19-8d1d-aa82b45267a1", "Admin", "ADMIN" }
                });
        }
    }
}
