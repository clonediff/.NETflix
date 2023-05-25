using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddSubscriptionsData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Subscriptions",
                columns: new[] { "Id", "Cost", "IsAvailable", "Name", "PeriodInDays" },
                values: new object[,]
                {
                    { 1, 1000, true, "Полный доступ", null },
                    { 2, 500, true, "Киновселенная Marvel", 30 },
                    { 3, 500, true, "Вселенная Гарри Поттера", 30 }
                });

            migrationBuilder.InsertData(
                table: "SubscriptionMovies",
                columns: new[] { "MovieInfoId", "SubscriptionId" },
                values: new object[,]
                {
                    { 2, 1 },
                    { 3, 1 },
                    { 4, 1 },
                    { 7, 1 },
                    { 9, 1 },
                    { 10, 1 },
                    { 11, 1 },
                    { 16, 1 },
                    { 17, 1 },
                    { 19, 1 },
                    { 20, 1 },
                    { 21, 1 },
                    { 23, 1 },
                    { 24, 1 },
                    { 27, 1 },
                    { 27, 3 },
                    { 28, 1 },
                    { 28, 3 },
                    { 29, 1 },
                    { 29, 3 },
                    { 30, 1 },
                    { 30, 3 },
                    { 31, 1 },
                    { 31, 3 },
                    { 32, 1 },
                    { 32, 3 },
                    { 35, 1 },
                    { 36, 1 },
                    { 38, 1 },
                    { 40, 1 },
                    { 41, 1 },
                    { 43, 1 },
                    { 44, 1 },
                    { 45, 1 },
                    { 46, 1 },
                    { 47, 1 },
                    { 47, 2 },
                    { 48, 1 },
                    { 49, 1 },
                    { 51, 1 },
                    { 52, 1 },
                    { 54, 1 },
                    { 55, 1 },
                    { 56, 1 },
                    { 57, 1 },
                    { 57, 2 },
                    { 58, 1 },
                    { 58, 2 },
                    { 59, 1 },
                    { 59, 2 },
                    { 62, 1 },
                    { 63, 1 },
                    { 64, 1 },
                    { 65, 1 },
                    { 66, 1 },
                    { 67, 1 },
                    { 68, 1 },
                    { 70, 1 },
                    { 71, 1 },
                    { 72, 1 },
                    { 74, 1 },
                    { 76, 1 },
                    { 77, 1 },
                    { 78, 1 },
                    { 79, 1 },
                    { 81, 1 },
                    { 82, 1 },
                    { 83, 1 },
                    { 88, 1 },
                    { 89, 1 },
                    { 90, 1 },
                    { 92, 1 },
                    { 93, 1 },
                    { 95, 1 },
                    { 95, 2 },
                    { 96, 1 },
                    { 97, 1 },
                    { 98, 1 },
                    { 99, 1 },
                    { 100, 1 },
                    { 101, 1 },
                    { 102, 1 },
                    { 104, 1 },
                    { 105, 1 },
                    { 106, 1 },
                    { 107, 1 },
                    { 108, 1 },
                    { 109, 1 },
                    { 110, 1 },
                    { 112, 1 },
                    { 113, 1 },
                    { 114, 1 },
                    { 116, 1 },
                    { 117, 1 },
                    { 118, 1 },
                    { 120, 1 },
                    { 121, 1 },
                    { 122, 1 },
                    { 124, 1 },
                    { 125, 1 },
                    { 125, 2 },
                    { 126, 1 },
                    { 126, 2 },
                    { 127, 1 },
                    { 129, 1 },
                    { 130, 1 },
                    { 131, 1 },
                    { 132, 1 },
                    { 133, 1 },
                    { 133, 2 },
                    { 134, 1 },
                    { 135, 1 },
                    { 136, 1 },
                    { 136, 3 },
                    { 137, 1 },
                    { 138, 1 },
                    { 139, 1 },
                    { 141, 1 },
                    { 142, 1 },
                    { 143, 1 },
                    { 143, 2 },
                    { 144, 1 },
                    { 145, 1 },
                    { 146, 1 },
                    { 147, 1 },
                    { 148, 1 },
                    { 149, 1 },
                    { 150, 1 },
                    { 151, 1 },
                    { 152, 1 },
                    { 153, 1 },
                    { 154, 1 },
                    { 155, 1 },
                    { 156, 1 },
                    { 157, 1 },
                    { 158, 1 },
                    { 159, 1 },
                    { 160, 1 },
                    { 161, 1 },
                    { 162, 1 },
                    { 163, 1 },
                    { 164, 1 },
                    { 165, 1 },
                    { 166, 1 },
                    { 167, 1 },
                    { 168, 1 },
                    { 169, 1 },
                    { 170, 1 },
                    { 171, 1 },
                    { 172, 1 },
                    { 173, 1 },
                    { 174, 1 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "SubscriptionMovies",
                keyColumns: new[] { "MovieInfoId", "SubscriptionId" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                table: "SubscriptionMovies",
                keyColumns: new[] { "MovieInfoId", "SubscriptionId" },
                keyValues: new object[] { 3, 1 });

            migrationBuilder.DeleteData(
                table: "SubscriptionMovies",
                keyColumns: new[] { "MovieInfoId", "SubscriptionId" },
                keyValues: new object[] { 4, 1 });

            migrationBuilder.DeleteData(
                table: "SubscriptionMovies",
                keyColumns: new[] { "MovieInfoId", "SubscriptionId" },
                keyValues: new object[] { 7, 1 });

            migrationBuilder.DeleteData(
                table: "SubscriptionMovies",
                keyColumns: new[] { "MovieInfoId", "SubscriptionId" },
                keyValues: new object[] { 9, 1 });

            migrationBuilder.DeleteData(
                table: "SubscriptionMovies",
                keyColumns: new[] { "MovieInfoId", "SubscriptionId" },
                keyValues: new object[] { 10, 1 });

            migrationBuilder.DeleteData(
                table: "SubscriptionMovies",
                keyColumns: new[] { "MovieInfoId", "SubscriptionId" },
                keyValues: new object[] { 11, 1 });

            migrationBuilder.DeleteData(
                table: "SubscriptionMovies",
                keyColumns: new[] { "MovieInfoId", "SubscriptionId" },
                keyValues: new object[] { 16, 1 });

            migrationBuilder.DeleteData(
                table: "SubscriptionMovies",
                keyColumns: new[] { "MovieInfoId", "SubscriptionId" },
                keyValues: new object[] { 17, 1 });

            migrationBuilder.DeleteData(
                table: "SubscriptionMovies",
                keyColumns: new[] { "MovieInfoId", "SubscriptionId" },
                keyValues: new object[] { 19, 1 });

            migrationBuilder.DeleteData(
                table: "SubscriptionMovies",
                keyColumns: new[] { "MovieInfoId", "SubscriptionId" },
                keyValues: new object[] { 20, 1 });

            migrationBuilder.DeleteData(
                table: "SubscriptionMovies",
                keyColumns: new[] { "MovieInfoId", "SubscriptionId" },
                keyValues: new object[] { 21, 1 });

            migrationBuilder.DeleteData(
                table: "SubscriptionMovies",
                keyColumns: new[] { "MovieInfoId", "SubscriptionId" },
                keyValues: new object[] { 23, 1 });

            migrationBuilder.DeleteData(
                table: "SubscriptionMovies",
                keyColumns: new[] { "MovieInfoId", "SubscriptionId" },
                keyValues: new object[] { 24, 1 });

            migrationBuilder.DeleteData(
                table: "SubscriptionMovies",
                keyColumns: new[] { "MovieInfoId", "SubscriptionId" },
                keyValues: new object[] { 27, 1 });

            migrationBuilder.DeleteData(
                table: "SubscriptionMovies",
                keyColumns: new[] { "MovieInfoId", "SubscriptionId" },
                keyValues: new object[] { 27, 3 });

            migrationBuilder.DeleteData(
                table: "SubscriptionMovies",
                keyColumns: new[] { "MovieInfoId", "SubscriptionId" },
                keyValues: new object[] { 28, 1 });

            migrationBuilder.DeleteData(
                table: "SubscriptionMovies",
                keyColumns: new[] { "MovieInfoId", "SubscriptionId" },
                keyValues: new object[] { 28, 3 });

            migrationBuilder.DeleteData(
                table: "SubscriptionMovies",
                keyColumns: new[] { "MovieInfoId", "SubscriptionId" },
                keyValues: new object[] { 29, 1 });

            migrationBuilder.DeleteData(
                table: "SubscriptionMovies",
                keyColumns: new[] { "MovieInfoId", "SubscriptionId" },
                keyValues: new object[] { 29, 3 });

            migrationBuilder.DeleteData(
                table: "SubscriptionMovies",
                keyColumns: new[] { "MovieInfoId", "SubscriptionId" },
                keyValues: new object[] { 30, 1 });

            migrationBuilder.DeleteData(
                table: "SubscriptionMovies",
                keyColumns: new[] { "MovieInfoId", "SubscriptionId" },
                keyValues: new object[] { 30, 3 });

            migrationBuilder.DeleteData(
                table: "SubscriptionMovies",
                keyColumns: new[] { "MovieInfoId", "SubscriptionId" },
                keyValues: new object[] { 31, 1 });

            migrationBuilder.DeleteData(
                table: "SubscriptionMovies",
                keyColumns: new[] { "MovieInfoId", "SubscriptionId" },
                keyValues: new object[] { 31, 3 });

            migrationBuilder.DeleteData(
                table: "SubscriptionMovies",
                keyColumns: new[] { "MovieInfoId", "SubscriptionId" },
                keyValues: new object[] { 32, 1 });

            migrationBuilder.DeleteData(
                table: "SubscriptionMovies",
                keyColumns: new[] { "MovieInfoId", "SubscriptionId" },
                keyValues: new object[] { 32, 3 });

            migrationBuilder.DeleteData(
                table: "SubscriptionMovies",
                keyColumns: new[] { "MovieInfoId", "SubscriptionId" },
                keyValues: new object[] { 35, 1 });

            migrationBuilder.DeleteData(
                table: "SubscriptionMovies",
                keyColumns: new[] { "MovieInfoId", "SubscriptionId" },
                keyValues: new object[] { 36, 1 });

            migrationBuilder.DeleteData(
                table: "SubscriptionMovies",
                keyColumns: new[] { "MovieInfoId", "SubscriptionId" },
                keyValues: new object[] { 38, 1 });

            migrationBuilder.DeleteData(
                table: "SubscriptionMovies",
                keyColumns: new[] { "MovieInfoId", "SubscriptionId" },
                keyValues: new object[] { 40, 1 });

            migrationBuilder.DeleteData(
                table: "SubscriptionMovies",
                keyColumns: new[] { "MovieInfoId", "SubscriptionId" },
                keyValues: new object[] { 41, 1 });

            migrationBuilder.DeleteData(
                table: "SubscriptionMovies",
                keyColumns: new[] { "MovieInfoId", "SubscriptionId" },
                keyValues: new object[] { 43, 1 });

            migrationBuilder.DeleteData(
                table: "SubscriptionMovies",
                keyColumns: new[] { "MovieInfoId", "SubscriptionId" },
                keyValues: new object[] { 44, 1 });

            migrationBuilder.DeleteData(
                table: "SubscriptionMovies",
                keyColumns: new[] { "MovieInfoId", "SubscriptionId" },
                keyValues: new object[] { 45, 1 });

            migrationBuilder.DeleteData(
                table: "SubscriptionMovies",
                keyColumns: new[] { "MovieInfoId", "SubscriptionId" },
                keyValues: new object[] { 46, 1 });

            migrationBuilder.DeleteData(
                table: "SubscriptionMovies",
                keyColumns: new[] { "MovieInfoId", "SubscriptionId" },
                keyValues: new object[] { 47, 1 });

            migrationBuilder.DeleteData(
                table: "SubscriptionMovies",
                keyColumns: new[] { "MovieInfoId", "SubscriptionId" },
                keyValues: new object[] { 47, 2 });

            migrationBuilder.DeleteData(
                table: "SubscriptionMovies",
                keyColumns: new[] { "MovieInfoId", "SubscriptionId" },
                keyValues: new object[] { 48, 1 });

            migrationBuilder.DeleteData(
                table: "SubscriptionMovies",
                keyColumns: new[] { "MovieInfoId", "SubscriptionId" },
                keyValues: new object[] { 49, 1 });

            migrationBuilder.DeleteData(
                table: "SubscriptionMovies",
                keyColumns: new[] { "MovieInfoId", "SubscriptionId" },
                keyValues: new object[] { 51, 1 });

            migrationBuilder.DeleteData(
                table: "SubscriptionMovies",
                keyColumns: new[] { "MovieInfoId", "SubscriptionId" },
                keyValues: new object[] { 52, 1 });

            migrationBuilder.DeleteData(
                table: "SubscriptionMovies",
                keyColumns: new[] { "MovieInfoId", "SubscriptionId" },
                keyValues: new object[] { 54, 1 });

            migrationBuilder.DeleteData(
                table: "SubscriptionMovies",
                keyColumns: new[] { "MovieInfoId", "SubscriptionId" },
                keyValues: new object[] { 55, 1 });

            migrationBuilder.DeleteData(
                table: "SubscriptionMovies",
                keyColumns: new[] { "MovieInfoId", "SubscriptionId" },
                keyValues: new object[] { 56, 1 });

            migrationBuilder.DeleteData(
                table: "SubscriptionMovies",
                keyColumns: new[] { "MovieInfoId", "SubscriptionId" },
                keyValues: new object[] { 57, 1 });

            migrationBuilder.DeleteData(
                table: "SubscriptionMovies",
                keyColumns: new[] { "MovieInfoId", "SubscriptionId" },
                keyValues: new object[] { 57, 2 });

            migrationBuilder.DeleteData(
                table: "SubscriptionMovies",
                keyColumns: new[] { "MovieInfoId", "SubscriptionId" },
                keyValues: new object[] { 58, 1 });

            migrationBuilder.DeleteData(
                table: "SubscriptionMovies",
                keyColumns: new[] { "MovieInfoId", "SubscriptionId" },
                keyValues: new object[] { 58, 2 });

            migrationBuilder.DeleteData(
                table: "SubscriptionMovies",
                keyColumns: new[] { "MovieInfoId", "SubscriptionId" },
                keyValues: new object[] { 59, 1 });

            migrationBuilder.DeleteData(
                table: "SubscriptionMovies",
                keyColumns: new[] { "MovieInfoId", "SubscriptionId" },
                keyValues: new object[] { 59, 2 });

            migrationBuilder.DeleteData(
                table: "SubscriptionMovies",
                keyColumns: new[] { "MovieInfoId", "SubscriptionId" },
                keyValues: new object[] { 62, 1 });

            migrationBuilder.DeleteData(
                table: "SubscriptionMovies",
                keyColumns: new[] { "MovieInfoId", "SubscriptionId" },
                keyValues: new object[] { 63, 1 });

            migrationBuilder.DeleteData(
                table: "SubscriptionMovies",
                keyColumns: new[] { "MovieInfoId", "SubscriptionId" },
                keyValues: new object[] { 64, 1 });

            migrationBuilder.DeleteData(
                table: "SubscriptionMovies",
                keyColumns: new[] { "MovieInfoId", "SubscriptionId" },
                keyValues: new object[] { 65, 1 });

            migrationBuilder.DeleteData(
                table: "SubscriptionMovies",
                keyColumns: new[] { "MovieInfoId", "SubscriptionId" },
                keyValues: new object[] { 66, 1 });

            migrationBuilder.DeleteData(
                table: "SubscriptionMovies",
                keyColumns: new[] { "MovieInfoId", "SubscriptionId" },
                keyValues: new object[] { 67, 1 });

            migrationBuilder.DeleteData(
                table: "SubscriptionMovies",
                keyColumns: new[] { "MovieInfoId", "SubscriptionId" },
                keyValues: new object[] { 68, 1 });

            migrationBuilder.DeleteData(
                table: "SubscriptionMovies",
                keyColumns: new[] { "MovieInfoId", "SubscriptionId" },
                keyValues: new object[] { 70, 1 });

            migrationBuilder.DeleteData(
                table: "SubscriptionMovies",
                keyColumns: new[] { "MovieInfoId", "SubscriptionId" },
                keyValues: new object[] { 71, 1 });

            migrationBuilder.DeleteData(
                table: "SubscriptionMovies",
                keyColumns: new[] { "MovieInfoId", "SubscriptionId" },
                keyValues: new object[] { 72, 1 });

            migrationBuilder.DeleteData(
                table: "SubscriptionMovies",
                keyColumns: new[] { "MovieInfoId", "SubscriptionId" },
                keyValues: new object[] { 74, 1 });

            migrationBuilder.DeleteData(
                table: "SubscriptionMovies",
                keyColumns: new[] { "MovieInfoId", "SubscriptionId" },
                keyValues: new object[] { 76, 1 });

            migrationBuilder.DeleteData(
                table: "SubscriptionMovies",
                keyColumns: new[] { "MovieInfoId", "SubscriptionId" },
                keyValues: new object[] { 77, 1 });

            migrationBuilder.DeleteData(
                table: "SubscriptionMovies",
                keyColumns: new[] { "MovieInfoId", "SubscriptionId" },
                keyValues: new object[] { 78, 1 });

            migrationBuilder.DeleteData(
                table: "SubscriptionMovies",
                keyColumns: new[] { "MovieInfoId", "SubscriptionId" },
                keyValues: new object[] { 79, 1 });

            migrationBuilder.DeleteData(
                table: "SubscriptionMovies",
                keyColumns: new[] { "MovieInfoId", "SubscriptionId" },
                keyValues: new object[] { 81, 1 });

            migrationBuilder.DeleteData(
                table: "SubscriptionMovies",
                keyColumns: new[] { "MovieInfoId", "SubscriptionId" },
                keyValues: new object[] { 82, 1 });

            migrationBuilder.DeleteData(
                table: "SubscriptionMovies",
                keyColumns: new[] { "MovieInfoId", "SubscriptionId" },
                keyValues: new object[] { 83, 1 });

            migrationBuilder.DeleteData(
                table: "SubscriptionMovies",
                keyColumns: new[] { "MovieInfoId", "SubscriptionId" },
                keyValues: new object[] { 88, 1 });

            migrationBuilder.DeleteData(
                table: "SubscriptionMovies",
                keyColumns: new[] { "MovieInfoId", "SubscriptionId" },
                keyValues: new object[] { 89, 1 });

            migrationBuilder.DeleteData(
                table: "SubscriptionMovies",
                keyColumns: new[] { "MovieInfoId", "SubscriptionId" },
                keyValues: new object[] { 90, 1 });

            migrationBuilder.DeleteData(
                table: "SubscriptionMovies",
                keyColumns: new[] { "MovieInfoId", "SubscriptionId" },
                keyValues: new object[] { 92, 1 });

            migrationBuilder.DeleteData(
                table: "SubscriptionMovies",
                keyColumns: new[] { "MovieInfoId", "SubscriptionId" },
                keyValues: new object[] { 93, 1 });

            migrationBuilder.DeleteData(
                table: "SubscriptionMovies",
                keyColumns: new[] { "MovieInfoId", "SubscriptionId" },
                keyValues: new object[] { 95, 1 });

            migrationBuilder.DeleteData(
                table: "SubscriptionMovies",
                keyColumns: new[] { "MovieInfoId", "SubscriptionId" },
                keyValues: new object[] { 95, 2 });

            migrationBuilder.DeleteData(
                table: "SubscriptionMovies",
                keyColumns: new[] { "MovieInfoId", "SubscriptionId" },
                keyValues: new object[] { 96, 1 });

            migrationBuilder.DeleteData(
                table: "SubscriptionMovies",
                keyColumns: new[] { "MovieInfoId", "SubscriptionId" },
                keyValues: new object[] { 97, 1 });

            migrationBuilder.DeleteData(
                table: "SubscriptionMovies",
                keyColumns: new[] { "MovieInfoId", "SubscriptionId" },
                keyValues: new object[] { 98, 1 });

            migrationBuilder.DeleteData(
                table: "SubscriptionMovies",
                keyColumns: new[] { "MovieInfoId", "SubscriptionId" },
                keyValues: new object[] { 99, 1 });

            migrationBuilder.DeleteData(
                table: "SubscriptionMovies",
                keyColumns: new[] { "MovieInfoId", "SubscriptionId" },
                keyValues: new object[] { 100, 1 });

            migrationBuilder.DeleteData(
                table: "SubscriptionMovies",
                keyColumns: new[] { "MovieInfoId", "SubscriptionId" },
                keyValues: new object[] { 101, 1 });

            migrationBuilder.DeleteData(
                table: "SubscriptionMovies",
                keyColumns: new[] { "MovieInfoId", "SubscriptionId" },
                keyValues: new object[] { 102, 1 });

            migrationBuilder.DeleteData(
                table: "SubscriptionMovies",
                keyColumns: new[] { "MovieInfoId", "SubscriptionId" },
                keyValues: new object[] { 104, 1 });

            migrationBuilder.DeleteData(
                table: "SubscriptionMovies",
                keyColumns: new[] { "MovieInfoId", "SubscriptionId" },
                keyValues: new object[] { 105, 1 });

            migrationBuilder.DeleteData(
                table: "SubscriptionMovies",
                keyColumns: new[] { "MovieInfoId", "SubscriptionId" },
                keyValues: new object[] { 106, 1 });

            migrationBuilder.DeleteData(
                table: "SubscriptionMovies",
                keyColumns: new[] { "MovieInfoId", "SubscriptionId" },
                keyValues: new object[] { 107, 1 });

            migrationBuilder.DeleteData(
                table: "SubscriptionMovies",
                keyColumns: new[] { "MovieInfoId", "SubscriptionId" },
                keyValues: new object[] { 108, 1 });

            migrationBuilder.DeleteData(
                table: "SubscriptionMovies",
                keyColumns: new[] { "MovieInfoId", "SubscriptionId" },
                keyValues: new object[] { 109, 1 });

            migrationBuilder.DeleteData(
                table: "SubscriptionMovies",
                keyColumns: new[] { "MovieInfoId", "SubscriptionId" },
                keyValues: new object[] { 110, 1 });

            migrationBuilder.DeleteData(
                table: "SubscriptionMovies",
                keyColumns: new[] { "MovieInfoId", "SubscriptionId" },
                keyValues: new object[] { 112, 1 });

            migrationBuilder.DeleteData(
                table: "SubscriptionMovies",
                keyColumns: new[] { "MovieInfoId", "SubscriptionId" },
                keyValues: new object[] { 113, 1 });

            migrationBuilder.DeleteData(
                table: "SubscriptionMovies",
                keyColumns: new[] { "MovieInfoId", "SubscriptionId" },
                keyValues: new object[] { 114, 1 });

            migrationBuilder.DeleteData(
                table: "SubscriptionMovies",
                keyColumns: new[] { "MovieInfoId", "SubscriptionId" },
                keyValues: new object[] { 116, 1 });

            migrationBuilder.DeleteData(
                table: "SubscriptionMovies",
                keyColumns: new[] { "MovieInfoId", "SubscriptionId" },
                keyValues: new object[] { 117, 1 });

            migrationBuilder.DeleteData(
                table: "SubscriptionMovies",
                keyColumns: new[] { "MovieInfoId", "SubscriptionId" },
                keyValues: new object[] { 118, 1 });

            migrationBuilder.DeleteData(
                table: "SubscriptionMovies",
                keyColumns: new[] { "MovieInfoId", "SubscriptionId" },
                keyValues: new object[] { 120, 1 });

            migrationBuilder.DeleteData(
                table: "SubscriptionMovies",
                keyColumns: new[] { "MovieInfoId", "SubscriptionId" },
                keyValues: new object[] { 121, 1 });

            migrationBuilder.DeleteData(
                table: "SubscriptionMovies",
                keyColumns: new[] { "MovieInfoId", "SubscriptionId" },
                keyValues: new object[] { 122, 1 });

            migrationBuilder.DeleteData(
                table: "SubscriptionMovies",
                keyColumns: new[] { "MovieInfoId", "SubscriptionId" },
                keyValues: new object[] { 124, 1 });

            migrationBuilder.DeleteData(
                table: "SubscriptionMovies",
                keyColumns: new[] { "MovieInfoId", "SubscriptionId" },
                keyValues: new object[] { 125, 1 });

            migrationBuilder.DeleteData(
                table: "SubscriptionMovies",
                keyColumns: new[] { "MovieInfoId", "SubscriptionId" },
                keyValues: new object[] { 125, 2 });

            migrationBuilder.DeleteData(
                table: "SubscriptionMovies",
                keyColumns: new[] { "MovieInfoId", "SubscriptionId" },
                keyValues: new object[] { 126, 1 });

            migrationBuilder.DeleteData(
                table: "SubscriptionMovies",
                keyColumns: new[] { "MovieInfoId", "SubscriptionId" },
                keyValues: new object[] { 126, 2 });

            migrationBuilder.DeleteData(
                table: "SubscriptionMovies",
                keyColumns: new[] { "MovieInfoId", "SubscriptionId" },
                keyValues: new object[] { 127, 1 });

            migrationBuilder.DeleteData(
                table: "SubscriptionMovies",
                keyColumns: new[] { "MovieInfoId", "SubscriptionId" },
                keyValues: new object[] { 129, 1 });

            migrationBuilder.DeleteData(
                table: "SubscriptionMovies",
                keyColumns: new[] { "MovieInfoId", "SubscriptionId" },
                keyValues: new object[] { 130, 1 });

            migrationBuilder.DeleteData(
                table: "SubscriptionMovies",
                keyColumns: new[] { "MovieInfoId", "SubscriptionId" },
                keyValues: new object[] { 131, 1 });

            migrationBuilder.DeleteData(
                table: "SubscriptionMovies",
                keyColumns: new[] { "MovieInfoId", "SubscriptionId" },
                keyValues: new object[] { 132, 1 });

            migrationBuilder.DeleteData(
                table: "SubscriptionMovies",
                keyColumns: new[] { "MovieInfoId", "SubscriptionId" },
                keyValues: new object[] { 133, 1 });

            migrationBuilder.DeleteData(
                table: "SubscriptionMovies",
                keyColumns: new[] { "MovieInfoId", "SubscriptionId" },
                keyValues: new object[] { 133, 2 });

            migrationBuilder.DeleteData(
                table: "SubscriptionMovies",
                keyColumns: new[] { "MovieInfoId", "SubscriptionId" },
                keyValues: new object[] { 134, 1 });

            migrationBuilder.DeleteData(
                table: "SubscriptionMovies",
                keyColumns: new[] { "MovieInfoId", "SubscriptionId" },
                keyValues: new object[] { 135, 1 });

            migrationBuilder.DeleteData(
                table: "SubscriptionMovies",
                keyColumns: new[] { "MovieInfoId", "SubscriptionId" },
                keyValues: new object[] { 136, 1 });

            migrationBuilder.DeleteData(
                table: "SubscriptionMovies",
                keyColumns: new[] { "MovieInfoId", "SubscriptionId" },
                keyValues: new object[] { 136, 3 });

            migrationBuilder.DeleteData(
                table: "SubscriptionMovies",
                keyColumns: new[] { "MovieInfoId", "SubscriptionId" },
                keyValues: new object[] { 137, 1 });

            migrationBuilder.DeleteData(
                table: "SubscriptionMovies",
                keyColumns: new[] { "MovieInfoId", "SubscriptionId" },
                keyValues: new object[] { 138, 1 });

            migrationBuilder.DeleteData(
                table: "SubscriptionMovies",
                keyColumns: new[] { "MovieInfoId", "SubscriptionId" },
                keyValues: new object[] { 139, 1 });

            migrationBuilder.DeleteData(
                table: "SubscriptionMovies",
                keyColumns: new[] { "MovieInfoId", "SubscriptionId" },
                keyValues: new object[] { 141, 1 });

            migrationBuilder.DeleteData(
                table: "SubscriptionMovies",
                keyColumns: new[] { "MovieInfoId", "SubscriptionId" },
                keyValues: new object[] { 142, 1 });

            migrationBuilder.DeleteData(
                table: "SubscriptionMovies",
                keyColumns: new[] { "MovieInfoId", "SubscriptionId" },
                keyValues: new object[] { 143, 1 });

            migrationBuilder.DeleteData(
                table: "SubscriptionMovies",
                keyColumns: new[] { "MovieInfoId", "SubscriptionId" },
                keyValues: new object[] { 143, 2 });

            migrationBuilder.DeleteData(
                table: "SubscriptionMovies",
                keyColumns: new[] { "MovieInfoId", "SubscriptionId" },
                keyValues: new object[] { 144, 1 });

            migrationBuilder.DeleteData(
                table: "SubscriptionMovies",
                keyColumns: new[] { "MovieInfoId", "SubscriptionId" },
                keyValues: new object[] { 145, 1 });

            migrationBuilder.DeleteData(
                table: "SubscriptionMovies",
                keyColumns: new[] { "MovieInfoId", "SubscriptionId" },
                keyValues: new object[] { 146, 1 });

            migrationBuilder.DeleteData(
                table: "SubscriptionMovies",
                keyColumns: new[] { "MovieInfoId", "SubscriptionId" },
                keyValues: new object[] { 147, 1 });

            migrationBuilder.DeleteData(
                table: "SubscriptionMovies",
                keyColumns: new[] { "MovieInfoId", "SubscriptionId" },
                keyValues: new object[] { 148, 1 });

            migrationBuilder.DeleteData(
                table: "SubscriptionMovies",
                keyColumns: new[] { "MovieInfoId", "SubscriptionId" },
                keyValues: new object[] { 149, 1 });

            migrationBuilder.DeleteData(
                table: "SubscriptionMovies",
                keyColumns: new[] { "MovieInfoId", "SubscriptionId" },
                keyValues: new object[] { 150, 1 });

            migrationBuilder.DeleteData(
                table: "SubscriptionMovies",
                keyColumns: new[] { "MovieInfoId", "SubscriptionId" },
                keyValues: new object[] { 151, 1 });

            migrationBuilder.DeleteData(
                table: "SubscriptionMovies",
                keyColumns: new[] { "MovieInfoId", "SubscriptionId" },
                keyValues: new object[] { 152, 1 });

            migrationBuilder.DeleteData(
                table: "SubscriptionMovies",
                keyColumns: new[] { "MovieInfoId", "SubscriptionId" },
                keyValues: new object[] { 153, 1 });

            migrationBuilder.DeleteData(
                table: "SubscriptionMovies",
                keyColumns: new[] { "MovieInfoId", "SubscriptionId" },
                keyValues: new object[] { 154, 1 });

            migrationBuilder.DeleteData(
                table: "SubscriptionMovies",
                keyColumns: new[] { "MovieInfoId", "SubscriptionId" },
                keyValues: new object[] { 155, 1 });

            migrationBuilder.DeleteData(
                table: "SubscriptionMovies",
                keyColumns: new[] { "MovieInfoId", "SubscriptionId" },
                keyValues: new object[] { 156, 1 });

            migrationBuilder.DeleteData(
                table: "SubscriptionMovies",
                keyColumns: new[] { "MovieInfoId", "SubscriptionId" },
                keyValues: new object[] { 157, 1 });

            migrationBuilder.DeleteData(
                table: "SubscriptionMovies",
                keyColumns: new[] { "MovieInfoId", "SubscriptionId" },
                keyValues: new object[] { 158, 1 });

            migrationBuilder.DeleteData(
                table: "SubscriptionMovies",
                keyColumns: new[] { "MovieInfoId", "SubscriptionId" },
                keyValues: new object[] { 159, 1 });

            migrationBuilder.DeleteData(
                table: "SubscriptionMovies",
                keyColumns: new[] { "MovieInfoId", "SubscriptionId" },
                keyValues: new object[] { 160, 1 });

            migrationBuilder.DeleteData(
                table: "SubscriptionMovies",
                keyColumns: new[] { "MovieInfoId", "SubscriptionId" },
                keyValues: new object[] { 161, 1 });

            migrationBuilder.DeleteData(
                table: "SubscriptionMovies",
                keyColumns: new[] { "MovieInfoId", "SubscriptionId" },
                keyValues: new object[] { 162, 1 });

            migrationBuilder.DeleteData(
                table: "SubscriptionMovies",
                keyColumns: new[] { "MovieInfoId", "SubscriptionId" },
                keyValues: new object[] { 163, 1 });

            migrationBuilder.DeleteData(
                table: "SubscriptionMovies",
                keyColumns: new[] { "MovieInfoId", "SubscriptionId" },
                keyValues: new object[] { 164, 1 });

            migrationBuilder.DeleteData(
                table: "SubscriptionMovies",
                keyColumns: new[] { "MovieInfoId", "SubscriptionId" },
                keyValues: new object[] { 165, 1 });

            migrationBuilder.DeleteData(
                table: "SubscriptionMovies",
                keyColumns: new[] { "MovieInfoId", "SubscriptionId" },
                keyValues: new object[] { 166, 1 });

            migrationBuilder.DeleteData(
                table: "SubscriptionMovies",
                keyColumns: new[] { "MovieInfoId", "SubscriptionId" },
                keyValues: new object[] { 167, 1 });

            migrationBuilder.DeleteData(
                table: "SubscriptionMovies",
                keyColumns: new[] { "MovieInfoId", "SubscriptionId" },
                keyValues: new object[] { 168, 1 });

            migrationBuilder.DeleteData(
                table: "SubscriptionMovies",
                keyColumns: new[] { "MovieInfoId", "SubscriptionId" },
                keyValues: new object[] { 169, 1 });

            migrationBuilder.DeleteData(
                table: "SubscriptionMovies",
                keyColumns: new[] { "MovieInfoId", "SubscriptionId" },
                keyValues: new object[] { 170, 1 });

            migrationBuilder.DeleteData(
                table: "SubscriptionMovies",
                keyColumns: new[] { "MovieInfoId", "SubscriptionId" },
                keyValues: new object[] { 171, 1 });

            migrationBuilder.DeleteData(
                table: "SubscriptionMovies",
                keyColumns: new[] { "MovieInfoId", "SubscriptionId" },
                keyValues: new object[] { 172, 1 });

            migrationBuilder.DeleteData(
                table: "SubscriptionMovies",
                keyColumns: new[] { "MovieInfoId", "SubscriptionId" },
                keyValues: new object[] { 173, 1 });

            migrationBuilder.DeleteData(
                table: "SubscriptionMovies",
                keyColumns: new[] { "MovieInfoId", "SubscriptionId" },
                keyValues: new object[] { 174, 1 });

            migrationBuilder.DeleteData(
                table: "Subscriptions",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Subscriptions",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Subscriptions",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
