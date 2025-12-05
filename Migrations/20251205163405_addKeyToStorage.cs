using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DotNetWebAPIDefault.Migrations
{
    /// <inheritdoc />
    public partial class addKeyToStorage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6cd2b7b9-8016-44b9-adc6-4423b8ee5cfb");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f18e4106-84c2-425a-9f56-17793e1a3a14");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "6ba799ef-50d6-4c93-af0f-03ac6949b53b", "36fb099a-4c23-4c19-8efa-8f11b51e0faf", "User", "USER" },
                    { "6d6239cc-8fdd-46ae-8a3a-86ad1159441e", "99d88cf3-3041-4d76-b110-14add86993cd", "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6ba799ef-50d6-4c93-af0f-03ac6949b53b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6d6239cc-8fdd-46ae-8a3a-86ad1159441e");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "6cd2b7b9-8016-44b9-adc6-4423b8ee5cfb", "740b4160-a26c-415a-8eec-eb6635bdd02f", "Admin", "ADMIN" },
                    { "f18e4106-84c2-425a-9f56-17793e1a3a14", "4ffd95a3-22dc-4f11-9d10-aa8392b5c66b", "User", "USER" }
                });
        }
    }
}
