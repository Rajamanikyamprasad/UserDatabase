using Microsoft.EntityFrameworkCore.Migrations;


#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace UserDatabase.Api.Migrations
{
    /// <inheritdoc />
    public partial class RolesSeeded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "7b82d34b-f8fb-4a3d-8613-e9e13af7b2c4", "2", "User", "User" },
                    { "a7f270be-556f-43e7-8e01-a9096100f81f", "1", "Admin", "Admin" },
                    { "bf2a7110-dc12-408a-8e9e-5cdcf142c1a1", "3", "Hr", "Hr" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7b82d34b-f8fb-4a3d-8613-e9e13af7b2c4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a7f270be-556f-43e7-8e01-a9096100f81f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bf2a7110-dc12-408a-8e9e-5cdcf142c1a1");
        }
    }
}
