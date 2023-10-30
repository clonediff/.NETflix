using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddIsFromAdminPropertyToMessageEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsFromAdmin",
                table: "Messages",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "SA",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b33c7ea8-c186-422f-8aed-ba6adef42260", "AQAAAAIAAYagAAAAEMnBvfAtnSiKb794UZd3qLnMXJ/ksOEIJeIiNAqRroz2IUKxjMUYxMoljeXg4/wqYQ==", "e3575fdb-a336-4bc7-b481-785a318e3bf8" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsFromAdmin",
                table: "Messages");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "SA",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e515fbe1-c43a-4715-adda-311ee4b31b6d", "AQAAAAIAAYagAAAAEDq8w/ueyzKlB8p65JgKgG0+q+YKoOgCwTwHjI7bDZM8+Q7bMJbWZBMJIXa+xLIBoQ==", "531accfe-faa9-42e4-8d46-ee1ee6874d61" });
        }
    }
}
