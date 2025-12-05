using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DotNetWebAPIDefault.Migrations
{
    /// <inheritdoc />
    public partial class editStorage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7d1cc812-2506-46c6-9c29-452a75989162");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a9b9b97b-8974-4b56-9997-95cfd8dab36d");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "328e599e-b897-4537-877a-53d9301a82fb", "4661597b-48ad-4e90-b389-2bac6984ca50", "User", "USER" },
                    { "3e6554ac-3f52-47d3-a1fb-8642e5b52910", "2a2f11e4-8883-4f19-8d1d-aa82b45267a1", "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "328e599e-b897-4537-877a-53d9301a82fb");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3e6554ac-3f52-47d3-a1fb-8642e5b52910");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "7d1cc812-2506-46c6-9c29-452a75989162", "ddc42820-b379-4514-ad57-0586f32300a8", "User", "USER" },
                    { "a9b9b97b-8974-4b56-9997-95cfd8dab36d", "a52e3aea-365a-4587-aaec-8d7de5e29b85", "Admin", "ADMIN" }
                });
        }
    }
}
