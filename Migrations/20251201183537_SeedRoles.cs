using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DotNetWebAPIDefault.Migrations
{
    /// <inheritdoc />
    public partial class SeedRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "476a579c-6384-479a-9ff8-ab02090176cf", "c66101ee-b0f5-456f-90af-5cf72c5f77e0", "Admin", "ADMIN" },
                    { "a38393eb-4881-4cf3-bf3d-7bb726499d26", "ca149e6f-c8d0-452c-b243-25084d54fb75", "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "476a579c-6384-479a-9ff8-ab02090176cf");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a38393eb-4881-4cf3-bf3d-7bb726499d26");
        }
    }
}
