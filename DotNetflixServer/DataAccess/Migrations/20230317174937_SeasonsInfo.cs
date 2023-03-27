using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BackendAPI.Migrations
{
    /// <inheritdoc />
    public partial class SeasonsInfo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "SeasonsInfo",
                columns: new[] { "Id", "EpisodesCount", "MovieInfoId", "Number" },
                values: new object[,]
                {
                    { 1, 8, 6, 1 },
                    { 2, 8, 6, 2 },
                    { 3, 15, 14, 1 },
                    { 4, 20, 37, 1 },
                    { 5, 21, 37, 2 },
                    { 6, 0, 83, 1 },
                    { 7, 26, 91, 1 },
                    { 8, 26, 91, 2 },
                    { 9, 26, 91, 3 },
                    { 10, 13, 91, 4 },
                    { 11, 26, 91, 5 },
                    { 12, 8, 108, 1 },
                    { 13, 9, 108, 2 },
                    { 14, 8, 108, 3 },
                    { 15, 9, 108, 4 },
                    { 16, 1, 108, 5 },
                    { 17, 100, 115, 1 },
                    { 18, 61, 115, 2 },
                    { 19, 18, 131, 1 },
                    { 20, 23, 131, 2 },
                    { 21, 23, 131, 3 },
                    { 22, 24, 131, 4 },
                    { 23, 24, 131, 5 },
                    { 24, 24, 131, 6 },
                    { 25, 24, 131, 7 },
                    { 26, 24, 131, 8 },
                    { 27, 24, 131, 9 },
                    { 28, 25, 131, 10 },
                    { 29, 24, 131, 11 },
                    { 30, 25, 131, 12 },
                    { 31, 16, 134, 1 },
                    { 32, 16, 134, 2 },
                    { 33, 6, 138, 1 },
                    { 34, 13, 138, 2 },
                    { 35, 16, 138, 3 },
                    { 36, 16, 138, 4 },
                    { 37, 16, 138, 5 },
                    { 38, 16, 138, 6 },
                    { 39, 16, 138, 7 },
                    { 40, 16, 138, 8 },
                    { 41, 16, 138, 9 },
                    { 42, 22, 138, 10 },
                    { 43, 24, 138, 11 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "SeasonsInfo",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "SeasonsInfo",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "SeasonsInfo",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "SeasonsInfo",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "SeasonsInfo",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "SeasonsInfo",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "SeasonsInfo",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "SeasonsInfo",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "SeasonsInfo",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "SeasonsInfo",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "SeasonsInfo",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "SeasonsInfo",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "SeasonsInfo",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "SeasonsInfo",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "SeasonsInfo",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "SeasonsInfo",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "SeasonsInfo",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "SeasonsInfo",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "SeasonsInfo",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "SeasonsInfo",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "SeasonsInfo",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "SeasonsInfo",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "SeasonsInfo",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "SeasonsInfo",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "SeasonsInfo",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "SeasonsInfo",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "SeasonsInfo",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "SeasonsInfo",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "SeasonsInfo",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "SeasonsInfo",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "SeasonsInfo",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "SeasonsInfo",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "SeasonsInfo",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "SeasonsInfo",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "SeasonsInfo",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "SeasonsInfo",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "SeasonsInfo",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "SeasonsInfo",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "SeasonsInfo",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "SeasonsInfo",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "SeasonsInfo",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "SeasonsInfo",
                keyColumn: "Id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "SeasonsInfo",
                keyColumn: "Id",
                keyValue: 43);
        }
    }
}
