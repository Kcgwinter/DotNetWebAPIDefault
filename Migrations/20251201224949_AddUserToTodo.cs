using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DotNetWebAPIDefault.Migrations
{
    /// <inheritdoc />
    public partial class AddUserToTodo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "63818880-1ab6-42c6-8129-bbaa6aa3ea08");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8b2fc44b-cbec-4989-9713-3d16c4135ad4");

            migrationBuilder.AddColumn<string>(
                name: "AppUserId",
                table: "Todos",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "030255b5-34e1-40a6-862e-db81085aaa13", "70b195fc-117a-4fea-833f-27c5c29ad965", "User", "USER" },
                    { "c701c6f0-13fe-4ad6-9529-b85fce9ffc2e", "1844991a-8106-46a7-95fd-ef67aa10f43a", "Admin", "ADMIN" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Todos_AppUserId",
                table: "Todos",
                column: "AppUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Todos_AspNetUsers_AppUserId",
                table: "Todos",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Todos_AspNetUsers_AppUserId",
                table: "Todos");

            migrationBuilder.DropIndex(
                name: "IX_Todos_AppUserId",
                table: "Todos");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "030255b5-34e1-40a6-862e-db81085aaa13");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c701c6f0-13fe-4ad6-9529-b85fce9ffc2e");

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "Todos");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "63818880-1ab6-42c6-8129-bbaa6aa3ea08", "f9a28acd-9746-4020-a59e-89c31cccb8b5", "User", "USER" },
                    { "8b2fc44b-cbec-4989-9713-3d16c4135ad4", "570ddd49-2e0c-4dbb-9a78-354cca155450", "Admin", "ADMIN" }
                });
        }
    }
}
