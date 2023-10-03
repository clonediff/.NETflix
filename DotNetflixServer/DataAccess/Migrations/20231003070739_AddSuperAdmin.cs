using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddSuperAdmin : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "BannedUntil", "Birthday", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "SA", 0, null, new DateTime(2021, 9, 1, 0, 0, 0, 0, DateTimeKind.Utc), "e515fbe1-c43a-4715-adda-311ee4b31b6d", "oristask@gmail.com", false, false, null, "ORISTASK@GMAIL.COM", "SA", "AQAAAAIAAYagAAAAEDq8w/ueyzKlB8p65JgKgG0+q+YKoOgCwTwHjI7bDZM8+Q7bMJbWZBMJIXa+xLIBoQ==", null, false, "531accfe-faa9-42e4-8d46-ee1ee6874d61", false, "SA" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "3", "SA" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "3", "SA" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "SA");
        }
    }
}
