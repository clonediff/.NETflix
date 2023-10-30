using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddUserChatMessages : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserChatMessages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SendingDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserChatMessages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserChatMessages_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "SA",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fa164b83-b921-4048-b45b-49bd49e670ef", "AQAAAAIAAYagAAAAEFYDG/XiZ87u5a3QHtvDpfuwt2UfprCMF0LOPl27NoU5zS38N2p746ssPRN9P5YTCA==", "f66183b1-c984-4e0d-9e50-aeb81c93b860" });

            migrationBuilder.CreateIndex(
                name: "IX_UserChatMessages_UserId",
                table: "UserChatMessages",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserChatMessages");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "SA",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b33c7ea8-c186-422f-8aed-ba6adef42260", "AQAAAAIAAYagAAAAEMnBvfAtnSiKb794UZd3qLnMXJ/ksOEIJeIiNAqRroz2IUKxjMUYxMoljeXg4/wqYQ==", "e3575fdb-a336-4bc7-b481-785a318e3bf8" });
        }
    }
}
