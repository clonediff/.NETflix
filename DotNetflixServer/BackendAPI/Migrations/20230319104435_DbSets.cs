using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BackendAPI.Migrations
{
    /// <inheritdoc />
    public partial class DbSets : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CountryMovieInfo_Country_CountryId",
                table: "CountryMovieInfo");

            migrationBuilder.DropForeignKey(
                name: "FK_Fees_CurrencyValue_RussiaId",
                table: "Fees");

            migrationBuilder.DropForeignKey(
                name: "FK_Fees_CurrencyValue_USAId",
                table: "Fees");

            migrationBuilder.DropForeignKey(
                name: "FK_Fees_CurrencyValue_WorldId",
                table: "Fees");

            migrationBuilder.DropForeignKey(
                name: "FK_GenreMovieInfo_Genre_GenreId",
                table: "GenreMovieInfo");

            migrationBuilder.DropForeignKey(
                name: "FK_Movies_CurrencyValue_BudgetId",
                table: "Movies");

            migrationBuilder.DropForeignKey(
                name: "FK_PersonProffessionInMovie_Person_PersonId",
                table: "PersonProffessionInMovie");

            migrationBuilder.DropForeignKey(
                name: "FK_SeasonsInfo_Movies_MovieInfoId",
                table: "SeasonsInfo");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SeasonsInfo",
                table: "SeasonsInfo");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Person",
                table: "Person");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Genre",
                table: "Genre");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CurrencyValue",
                table: "CurrencyValue");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Country",
                table: "Country");

            migrationBuilder.DeleteData(
                table: "Fees",
                keyColumn: "Id",
                keyValue: 120);

            migrationBuilder.DeleteData(
                table: "Fees",
                keyColumn: "Id",
                keyValue: 121);

            migrationBuilder.DeleteData(
                table: "Fees",
                keyColumn: "Id",
                keyValue: 122);

            migrationBuilder.DeleteData(
                table: "Fees",
                keyColumn: "Id",
                keyValue: 123);

            migrationBuilder.DeleteData(
                table: "Fees",
                keyColumn: "Id",
                keyValue: 124);

            migrationBuilder.DeleteData(
                table: "Fees",
                keyColumn: "Id",
                keyValue: 125);

            migrationBuilder.DeleteData(
                table: "Fees",
                keyColumn: "Id",
                keyValue: 126);

            migrationBuilder.DeleteData(
                table: "Fees",
                keyColumn: "Id",
                keyValue: 127);

            migrationBuilder.DeleteData(
                table: "Fees",
                keyColumn: "Id",
                keyValue: 128);

            migrationBuilder.DeleteData(
                table: "Fees",
                keyColumn: "Id",
                keyValue: 129);

            migrationBuilder.DeleteData(
                table: "Fees",
                keyColumn: "Id",
                keyValue: 130);

            migrationBuilder.DeleteData(
                table: "Fees",
                keyColumn: "Id",
                keyValue: 131);

            migrationBuilder.DeleteData(
                table: "Fees",
                keyColumn: "Id",
                keyValue: 132);

            migrationBuilder.DeleteData(
                table: "Fees",
                keyColumn: "Id",
                keyValue: 133);

            migrationBuilder.DeleteData(
                table: "Fees",
                keyColumn: "Id",
                keyValue: 134);

            migrationBuilder.DeleteData(
                table: "Fees",
                keyColumn: "Id",
                keyValue: 135);

            migrationBuilder.DeleteData(
                table: "Fees",
                keyColumn: "Id",
                keyValue: 136);

            migrationBuilder.DeleteData(
                table: "Fees",
                keyColumn: "Id",
                keyValue: 137);

            migrationBuilder.DeleteData(
                table: "Fees",
                keyColumn: "Id",
                keyValue: 138);

            migrationBuilder.DeleteData(
                table: "Fees",
                keyColumn: "Id",
                keyValue: 139);

            migrationBuilder.DeleteData(
                table: "Fees",
                keyColumn: "Id",
                keyValue: 140);

            migrationBuilder.DeleteData(
                table: "Fees",
                keyColumn: "Id",
                keyValue: 141);

            migrationBuilder.DeleteData(
                table: "Fees",
                keyColumn: "Id",
                keyValue: 142);

            migrationBuilder.DeleteData(
                table: "Fees",
                keyColumn: "Id",
                keyValue: 143);

            migrationBuilder.DeleteData(
                table: "Fees",
                keyColumn: "Id",
                keyValue: 144);

            migrationBuilder.DeleteData(
                table: "Fees",
                keyColumn: "Id",
                keyValue: 145);

            migrationBuilder.DeleteData(
                table: "Fees",
                keyColumn: "Id",
                keyValue: 146);

            migrationBuilder.DeleteData(
                table: "Fees",
                keyColumn: "Id",
                keyValue: 147);

            migrationBuilder.DeleteData(
                table: "Fees",
                keyColumn: "Id",
                keyValue: 148);

            migrationBuilder.DeleteData(
                table: "Fees",
                keyColumn: "Id",
                keyValue: 149);

            migrationBuilder.RenameTable(
                name: "SeasonsInfo",
                newName: "SeasonsInfos");

            migrationBuilder.RenameTable(
                name: "Person",
                newName: "Persons");

            migrationBuilder.RenameTable(
                name: "Genre",
                newName: "Genres");

            migrationBuilder.RenameTable(
                name: "CurrencyValue",
                newName: "CurrencyValues");

            migrationBuilder.RenameTable(
                name: "Country",
                newName: "Countries");

            migrationBuilder.RenameIndex(
                name: "IX_SeasonsInfo_MovieInfoId",
                table: "SeasonsInfos",
                newName: "IX_SeasonsInfos_MovieInfoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SeasonsInfos",
                table: "SeasonsInfos",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Persons",
                table: "Persons",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Genres",
                table: "Genres",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CurrencyValues",
                table: "CurrencyValues",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Countries",
                table: "Countries",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "Fees",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "RussiaId", "USAId", "WorldId" },
                values: new object[] { 131, 132, 133 });

            migrationBuilder.UpdateData(
                table: "Fees",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "RussiaId", "USAId", "WorldId" },
                values: new object[] { 134, 135, 136 });

            migrationBuilder.UpdateData(
                table: "Fees",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "RussiaId", "USAId", "WorldId" },
                values: new object[] { 137, 138, 139 });

            migrationBuilder.UpdateData(
                table: "Fees",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "RussiaId", "USAId", "WorldId" },
                values: new object[] { null, 140, 141 });

            migrationBuilder.UpdateData(
                table: "Fees",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "RussiaId", "USAId", "WorldId" },
                values: new object[] { 142, null, 143 });

            migrationBuilder.UpdateData(
                table: "Fees",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "USAId", "WorldId" },
                values: new object[] { null, 144 });

            migrationBuilder.UpdateData(
                table: "Fees",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "RussiaId", "USAId", "WorldId" },
                values: new object[] { 145, 146, 147 });

            migrationBuilder.UpdateData(
                table: "Fees",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "RussiaId", "USAId", "WorldId" },
                values: new object[] { 148, 149, 150 });

            migrationBuilder.UpdateData(
                table: "Fees",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "RussiaId", "USAId", "WorldId" },
                values: new object[] { 151, 152, 153 });

            migrationBuilder.UpdateData(
                table: "Fees",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "RussiaId", "USAId", "WorldId" },
                values: new object[] { 154, 155, 156 });

            migrationBuilder.UpdateData(
                table: "Fees",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "RussiaId", "USAId", "WorldId" },
                values: new object[] { 157, 158, 159 });

            migrationBuilder.UpdateData(
                table: "Fees",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "RussiaId", "USAId", "WorldId" },
                values: new object[] { 160, 161, 162 });

            migrationBuilder.UpdateData(
                table: "Fees",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "RussiaId", "USAId", "WorldId" },
                values: new object[] { 163, 164, 165 });

            migrationBuilder.UpdateData(
                table: "Fees",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "RussiaId", "USAId", "WorldId" },
                values: new object[] { 166, 167, 168 });

            migrationBuilder.UpdateData(
                table: "Fees",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "RussiaId", "USAId", "WorldId" },
                values: new object[] { 169, 170, 171 });

            migrationBuilder.UpdateData(
                table: "Fees",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "RussiaId", "USAId", "WorldId" },
                values: new object[] { 172, 173, 174 });

            migrationBuilder.UpdateData(
                table: "Fees",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "RussiaId", "USAId", "WorldId" },
                values: new object[] { 175, 176, 177 });

            migrationBuilder.UpdateData(
                table: "Fees",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "RussiaId", "USAId", "WorldId" },
                values: new object[] { 178, 179, 180 });

            migrationBuilder.UpdateData(
                table: "Fees",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "RussiaId", "USAId", "WorldId" },
                values: new object[] { 181, 182, 183 });

            migrationBuilder.UpdateData(
                table: "Fees",
                keyColumn: "Id",
                keyValue: 25,
                columns: new[] { "RussiaId", "USAId", "WorldId" },
                values: new object[] { 184, 185, 186 });

            migrationBuilder.UpdateData(
                table: "Fees",
                keyColumn: "Id",
                keyValue: 26,
                columns: new[] { "RussiaId", "USAId", "WorldId" },
                values: new object[] { 187, 188, 189 });

            migrationBuilder.UpdateData(
                table: "Fees",
                keyColumn: "Id",
                keyValue: 27,
                columns: new[] { "RussiaId", "USAId", "WorldId" },
                values: new object[] { 190, 191, 192 });

            migrationBuilder.UpdateData(
                table: "Fees",
                keyColumn: "Id",
                keyValue: 28,
                columns: new[] { "RussiaId", "USAId", "WorldId" },
                values: new object[] { 193, 194, 195 });

            migrationBuilder.UpdateData(
                table: "Fees",
                keyColumn: "Id",
                keyValue: 29,
                columns: new[] { "RussiaId", "USAId", "WorldId" },
                values: new object[] { 196, 197, 198 });

            migrationBuilder.UpdateData(
                table: "Fees",
                keyColumn: "Id",
                keyValue: 30,
                columns: new[] { "RussiaId", "USAId", "WorldId" },
                values: new object[] { 199, 200, 201 });

            migrationBuilder.UpdateData(
                table: "Fees",
                keyColumn: "Id",
                keyValue: 31,
                columns: new[] { "RussiaId", "USAId", "WorldId" },
                values: new object[] { 202, 203, 204 });

            migrationBuilder.UpdateData(
                table: "Fees",
                keyColumn: "Id",
                keyValue: 32,
                columns: new[] { "RussiaId", "USAId", "WorldId" },
                values: new object[] { null, 205, 206 });

            migrationBuilder.UpdateData(
                table: "Fees",
                keyColumn: "Id",
                keyValue: 33,
                columns: new[] { "RussiaId", "USAId", "WorldId" },
                values: new object[] { 207, 208, 209 });

            migrationBuilder.UpdateData(
                table: "Fees",
                keyColumn: "Id",
                keyValue: 34,
                columns: new[] { "RussiaId", "USAId", "WorldId" },
                values: new object[] { null, null, 210 });

            migrationBuilder.UpdateData(
                table: "Fees",
                keyColumn: "Id",
                keyValue: 35,
                columns: new[] { "RussiaId", "USAId", "WorldId" },
                values: new object[] { 211, 212, 213 });

            migrationBuilder.UpdateData(
                table: "Fees",
                keyColumn: "Id",
                keyValue: 36,
                columns: new[] { "RussiaId", "USAId", "WorldId" },
                values: new object[] { 214, 215, 216 });

            migrationBuilder.UpdateData(
                table: "Fees",
                keyColumn: "Id",
                keyValue: 37,
                columns: new[] { "RussiaId", "USAId", "WorldId" },
                values: new object[] { 217, 218, 219 });

            migrationBuilder.UpdateData(
                table: "Fees",
                keyColumn: "Id",
                keyValue: 38,
                columns: new[] { "RussiaId", "USAId", "WorldId" },
                values: new object[] { 220, 221, 222 });

            migrationBuilder.UpdateData(
                table: "Fees",
                keyColumn: "Id",
                keyValue: 39,
                columns: new[] { "RussiaId", "USAId", "WorldId" },
                values: new object[] { 223, 224, 225 });

            migrationBuilder.UpdateData(
                table: "Fees",
                keyColumn: "Id",
                keyValue: 40,
                columns: new[] { "RussiaId", "USAId", "WorldId" },
                values: new object[] { 226, 227, 228 });

            migrationBuilder.UpdateData(
                table: "Fees",
                keyColumn: "Id",
                keyValue: 41,
                columns: new[] { "RussiaId", "USAId", "WorldId" },
                values: new object[] { null, 229, 230 });

            migrationBuilder.UpdateData(
                table: "Fees",
                keyColumn: "Id",
                keyValue: 42,
                columns: new[] { "RussiaId", "WorldId" },
                values: new object[] { 231, 232 });

            migrationBuilder.UpdateData(
                table: "Fees",
                keyColumn: "Id",
                keyValue: 43,
                columns: new[] { "RussiaId", "USAId", "WorldId" },
                values: new object[] { 233, 234, 235 });

            migrationBuilder.UpdateData(
                table: "Fees",
                keyColumn: "Id",
                keyValue: 44,
                columns: new[] { "RussiaId", "USAId", "WorldId" },
                values: new object[] { 236, 237, 238 });

            migrationBuilder.UpdateData(
                table: "Fees",
                keyColumn: "Id",
                keyValue: 45,
                columns: new[] { "RussiaId", "USAId", "WorldId" },
                values: new object[] { 239, 240, 241 });

            migrationBuilder.UpdateData(
                table: "Fees",
                keyColumn: "Id",
                keyValue: 46,
                columns: new[] { "RussiaId", "USAId", "WorldId" },
                values: new object[] { 242, 243, 244 });

            migrationBuilder.UpdateData(
                table: "Fees",
                keyColumn: "Id",
                keyValue: 47,
                columns: new[] { "RussiaId", "USAId", "WorldId" },
                values: new object[] { 245, 246, 247 });

            migrationBuilder.UpdateData(
                table: "Fees",
                keyColumn: "Id",
                keyValue: 48,
                columns: new[] { "RussiaId", "USAId", "WorldId" },
                values: new object[] { 248, 249, 250 });

            migrationBuilder.UpdateData(
                table: "Fees",
                keyColumn: "Id",
                keyValue: 49,
                columns: new[] { "RussiaId", "USAId", "WorldId" },
                values: new object[] { 251, 252, 253 });

            migrationBuilder.UpdateData(
                table: "Fees",
                keyColumn: "Id",
                keyValue: 50,
                columns: new[] { "RussiaId", "USAId", "WorldId" },
                values: new object[] { 254, 255, 256 });

            migrationBuilder.UpdateData(
                table: "Fees",
                keyColumn: "Id",
                keyValue: 51,
                columns: new[] { "RussiaId", "USAId", "WorldId" },
                values: new object[] { 257, 258, 259 });

            migrationBuilder.UpdateData(
                table: "Fees",
                keyColumn: "Id",
                keyValue: 52,
                columns: new[] { "RussiaId", "USAId", "WorldId" },
                values: new object[] { 260, 261, 262 });

            migrationBuilder.UpdateData(
                table: "Fees",
                keyColumn: "Id",
                keyValue: 53,
                columns: new[] { "RussiaId", "USAId", "WorldId" },
                values: new object[] { 263, 264, 265 });

            migrationBuilder.UpdateData(
                table: "Fees",
                keyColumn: "Id",
                keyValue: 54,
                columns: new[] { "RussiaId", "USAId", "WorldId" },
                values: new object[] { 266, 267, 268 });

            migrationBuilder.UpdateData(
                table: "Fees",
                keyColumn: "Id",
                keyValue: 55,
                columns: new[] { "RussiaId", "USAId", "WorldId" },
                values: new object[] { null, 269, 270 });

            migrationBuilder.UpdateData(
                table: "Fees",
                keyColumn: "Id",
                keyValue: 56,
                columns: new[] { "RussiaId", "USAId", "WorldId" },
                values: new object[] { 271, 272, 273 });

            migrationBuilder.UpdateData(
                table: "Fees",
                keyColumn: "Id",
                keyValue: 57,
                columns: new[] { "RussiaId", "USAId", "WorldId" },
                values: new object[] { 274, 275, 276 });

            migrationBuilder.UpdateData(
                table: "Fees",
                keyColumn: "Id",
                keyValue: 58,
                columns: new[] { "RussiaId", "USAId", "WorldId" },
                values: new object[] { 277, 278, 279 });

            migrationBuilder.UpdateData(
                table: "Fees",
                keyColumn: "Id",
                keyValue: 59,
                columns: new[] { "RussiaId", "USAId", "WorldId" },
                values: new object[] { 280, 281, 282 });

            migrationBuilder.UpdateData(
                table: "Fees",
                keyColumn: "Id",
                keyValue: 60,
                columns: new[] { "RussiaId", "USAId", "WorldId" },
                values: new object[] { 283, 284, 285 });

            migrationBuilder.UpdateData(
                table: "Fees",
                keyColumn: "Id",
                keyValue: 61,
                columns: new[] { "USAId", "WorldId" },
                values: new object[] { 286, 287 });

            migrationBuilder.UpdateData(
                table: "Fees",
                keyColumn: "Id",
                keyValue: 62,
                columns: new[] { "RussiaId", "USAId", "WorldId" },
                values: new object[] { 288, 289, 290 });

            migrationBuilder.UpdateData(
                table: "Fees",
                keyColumn: "Id",
                keyValue: 63,
                columns: new[] { "RussiaId", "USAId", "WorldId" },
                values: new object[] { 291, 292, 293 });

            migrationBuilder.UpdateData(
                table: "Fees",
                keyColumn: "Id",
                keyValue: 64,
                columns: new[] { "RussiaId", "USAId", "WorldId" },
                values: new object[] { 294, 295, 296 });

            migrationBuilder.UpdateData(
                table: "Fees",
                keyColumn: "Id",
                keyValue: 65,
                columns: new[] { "RussiaId", "USAId", "WorldId" },
                values: new object[] { 297, 298, 299 });

            migrationBuilder.UpdateData(
                table: "Fees",
                keyColumn: "Id",
                keyValue: 66,
                columns: new[] { "RussiaId", "USAId", "WorldId" },
                values: new object[] { 300, 301, 302 });

            migrationBuilder.UpdateData(
                table: "Fees",
                keyColumn: "Id",
                keyValue: 67,
                columns: new[] { "RussiaId", "USAId", "WorldId" },
                values: new object[] { 303, 304, 305 });

            migrationBuilder.UpdateData(
                table: "Fees",
                keyColumn: "Id",
                keyValue: 68,
                columns: new[] { "USAId", "WorldId" },
                values: new object[] { 306, 307 });

            migrationBuilder.UpdateData(
                table: "Fees",
                keyColumn: "Id",
                keyValue: 69,
                columns: new[] { "RussiaId", "USAId", "WorldId" },
                values: new object[] { 308, 309, 310 });

            migrationBuilder.UpdateData(
                table: "Fees",
                keyColumn: "Id",
                keyValue: 70,
                columns: new[] { "RussiaId", "USAId", "WorldId" },
                values: new object[] { null, 311, 312 });

            migrationBuilder.UpdateData(
                table: "Fees",
                keyColumn: "Id",
                keyValue: 71,
                columns: new[] { "RussiaId", "USAId", "WorldId" },
                values: new object[] { null, 313, 314 });

            migrationBuilder.UpdateData(
                table: "Fees",
                keyColumn: "Id",
                keyValue: 72,
                columns: new[] { "RussiaId", "USAId", "WorldId" },
                values: new object[] { null, 315, 316 });

            migrationBuilder.UpdateData(
                table: "Fees",
                keyColumn: "Id",
                keyValue: 73,
                column: "WorldId",
                value: 317);

            migrationBuilder.UpdateData(
                table: "Fees",
                keyColumn: "Id",
                keyValue: 74,
                columns: new[] { "RussiaId", "USAId", "WorldId" },
                values: new object[] { 318, 319, 320 });

            migrationBuilder.UpdateData(
                table: "Fees",
                keyColumn: "Id",
                keyValue: 75,
                columns: new[] { "RussiaId", "USAId", "WorldId" },
                values: new object[] { 321, 322, 323 });

            migrationBuilder.UpdateData(
                table: "Fees",
                keyColumn: "Id",
                keyValue: 76,
                columns: new[] { "RussiaId", "USAId", "WorldId" },
                values: new object[] { 324, 325, 326 });

            migrationBuilder.UpdateData(
                table: "Fees",
                keyColumn: "Id",
                keyValue: 77,
                columns: new[] { "RussiaId", "USAId", "WorldId" },
                values: new object[] { null, 327, 328 });

            migrationBuilder.UpdateData(
                table: "Fees",
                keyColumn: "Id",
                keyValue: 78,
                columns: new[] { "RussiaId", "USAId", "WorldId" },
                values: new object[] { 329, 330, 331 });

            migrationBuilder.UpdateData(
                table: "Fees",
                keyColumn: "Id",
                keyValue: 79,
                columns: new[] { "RussiaId", "USAId", "WorldId" },
                values: new object[] { 332, 333, 334 });

            migrationBuilder.UpdateData(
                table: "Fees",
                keyColumn: "Id",
                keyValue: 80,
                columns: new[] { "RussiaId", "USAId", "WorldId" },
                values: new object[] { null, 335, 336 });

            migrationBuilder.UpdateData(
                table: "Fees",
                keyColumn: "Id",
                keyValue: 81,
                columns: new[] { "RussiaId", "USAId", "WorldId" },
                values: new object[] { 337, 338, 339 });

            migrationBuilder.UpdateData(
                table: "Fees",
                keyColumn: "Id",
                keyValue: 82,
                columns: new[] { "RussiaId", "USAId", "WorldId" },
                values: new object[] { 340, 341, 342 });

            migrationBuilder.UpdateData(
                table: "Fees",
                keyColumn: "Id",
                keyValue: 83,
                columns: new[] { "RussiaId", "USAId", "WorldId" },
                values: new object[] { 343, 344, 345 });

            migrationBuilder.UpdateData(
                table: "Fees",
                keyColumn: "Id",
                keyValue: 84,
                columns: new[] { "RussiaId", "USAId", "WorldId" },
                values: new object[] { 346, 347, 348 });

            migrationBuilder.UpdateData(
                table: "Fees",
                keyColumn: "Id",
                keyValue: 85,
                columns: new[] { "RussiaId", "USAId", "WorldId" },
                values: new object[] { 349, 350, 351 });

            migrationBuilder.UpdateData(
                table: "Fees",
                keyColumn: "Id",
                keyValue: 86,
                columns: new[] { "RussiaId", "USAId", "WorldId" },
                values: new object[] { 352, 353, 354 });

            migrationBuilder.UpdateData(
                table: "Fees",
                keyColumn: "Id",
                keyValue: 87,
                columns: new[] { "RussiaId", "USAId", "WorldId" },
                values: new object[] { 355, 356, 357 });

            migrationBuilder.UpdateData(
                table: "Fees",
                keyColumn: "Id",
                keyValue: 88,
                columns: new[] { "RussiaId", "USAId", "WorldId" },
                values: new object[] { 358, 359, 360 });

            migrationBuilder.UpdateData(
                table: "Fees",
                keyColumn: "Id",
                keyValue: 89,
                columns: new[] { "RussiaId", "USAId", "WorldId" },
                values: new object[] { 361, 362, 363 });

            migrationBuilder.UpdateData(
                table: "Fees",
                keyColumn: "Id",
                keyValue: 90,
                columns: new[] { "RussiaId", "USAId", "WorldId" },
                values: new object[] { 364, 365, 366 });

            migrationBuilder.UpdateData(
                table: "Fees",
                keyColumn: "Id",
                keyValue: 91,
                columns: new[] { "RussiaId", "USAId", "WorldId" },
                values: new object[] { 367, 368, 369 });

            migrationBuilder.UpdateData(
                table: "Fees",
                keyColumn: "Id",
                keyValue: 92,
                columns: new[] { "RussiaId", "USAId", "WorldId" },
                values: new object[] { 370, 371, 372 });

            migrationBuilder.UpdateData(
                table: "Fees",
                keyColumn: "Id",
                keyValue: 93,
                columns: new[] { "RussiaId", "USAId", "WorldId" },
                values: new object[] { 373, 374, 375 });

            migrationBuilder.UpdateData(
                table: "Fees",
                keyColumn: "Id",
                keyValue: 94,
                columns: new[] { "RussiaId", "USAId", "WorldId" },
                values: new object[] { 376, 377, 378 });

            migrationBuilder.UpdateData(
                table: "Fees",
                keyColumn: "Id",
                keyValue: 95,
                columns: new[] { "RussiaId", "USAId", "WorldId" },
                values: new object[] { null, 379, 380 });

            migrationBuilder.UpdateData(
                table: "Fees",
                keyColumn: "Id",
                keyValue: 96,
                columns: new[] { "RussiaId", "USAId", "WorldId" },
                values: new object[] { 381, 382, 383 });

            migrationBuilder.UpdateData(
                table: "Fees",
                keyColumn: "Id",
                keyValue: 97,
                columns: new[] { "RussiaId", "USAId", "WorldId" },
                values: new object[] { null, 384, 385 });

            migrationBuilder.UpdateData(
                table: "Fees",
                keyColumn: "Id",
                keyValue: 98,
                columns: new[] { "USAId", "WorldId" },
                values: new object[] { 386, 387 });

            migrationBuilder.UpdateData(
                table: "Fees",
                keyColumn: "Id",
                keyValue: 99,
                columns: new[] { "RussiaId", "USAId", "WorldId" },
                values: new object[] { 388, 389, 390 });

            migrationBuilder.UpdateData(
                table: "Fees",
                keyColumn: "Id",
                keyValue: 100,
                columns: new[] { "RussiaId", "USAId", "WorldId" },
                values: new object[] { 391, 392, 393 });

            migrationBuilder.UpdateData(
                table: "Fees",
                keyColumn: "Id",
                keyValue: 101,
                columns: new[] { "RussiaId", "USAId", "WorldId" },
                values: new object[] { 394, 395, 396 });

            migrationBuilder.UpdateData(
                table: "Fees",
                keyColumn: "Id",
                keyValue: 102,
                columns: new[] { "RussiaId", "USAId", "WorldId" },
                values: new object[] { 397, null, 398 });

            migrationBuilder.UpdateData(
                table: "Fees",
                keyColumn: "Id",
                keyValue: 103,
                columns: new[] { "RussiaId", "USAId", "WorldId" },
                values: new object[] { 399, 400, 401 });

            migrationBuilder.UpdateData(
                table: "Fees",
                keyColumn: "Id",
                keyValue: 104,
                columns: new[] { "RussiaId", "USAId", "WorldId" },
                values: new object[] { 402, 403, 404 });

            migrationBuilder.UpdateData(
                table: "Fees",
                keyColumn: "Id",
                keyValue: 105,
                columns: new[] { "RussiaId", "USAId", "WorldId" },
                values: new object[] { 405, 406, 407 });

            migrationBuilder.UpdateData(
                table: "Fees",
                keyColumn: "Id",
                keyValue: 106,
                columns: new[] { "RussiaId", "USAId", "WorldId" },
                values: new object[] { 408, 409, 410 });

            migrationBuilder.UpdateData(
                table: "Fees",
                keyColumn: "Id",
                keyValue: 107,
                columns: new[] { "RussiaId", "USAId", "WorldId" },
                values: new object[] { 411, 412, 413 });

            migrationBuilder.UpdateData(
                table: "Fees",
                keyColumn: "Id",
                keyValue: 108,
                columns: new[] { "RussiaId", "USAId", "WorldId" },
                values: new object[] { 414, 415, 416 });

            migrationBuilder.UpdateData(
                table: "Fees",
                keyColumn: "Id",
                keyValue: 109,
                columns: new[] { "RussiaId", "USAId", "WorldId" },
                values: new object[] { 417, 418, 419 });

            migrationBuilder.UpdateData(
                table: "Fees",
                keyColumn: "Id",
                keyValue: 110,
                columns: new[] { "RussiaId", "USAId", "WorldId" },
                values: new object[] { null, 420, 421 });

            migrationBuilder.UpdateData(
                table: "Fees",
                keyColumn: "Id",
                keyValue: 111,
                columns: new[] { "RussiaId", "USAId", "WorldId" },
                values: new object[] { 422, 423, 424 });

            migrationBuilder.UpdateData(
                table: "Fees",
                keyColumn: "Id",
                keyValue: 112,
                columns: new[] { "RussiaId", "USAId", "WorldId" },
                values: new object[] { 425, null, 426 });

            migrationBuilder.UpdateData(
                table: "Fees",
                keyColumn: "Id",
                keyValue: 113,
                columns: new[] { "RussiaId", "USAId", "WorldId" },
                values: new object[] { 427, 428, 429 });

            migrationBuilder.UpdateData(
                table: "Fees",
                keyColumn: "Id",
                keyValue: 114,
                columns: new[] { "RussiaId", "USAId", "WorldId" },
                values: new object[] { 430, 431, 432 });

            migrationBuilder.UpdateData(
                table: "Fees",
                keyColumn: "Id",
                keyValue: 115,
                columns: new[] { "RussiaId", "USAId", "WorldId" },
                values: new object[] { 433, 434, 435 });

            migrationBuilder.UpdateData(
                table: "Fees",
                keyColumn: "Id",
                keyValue: 116,
                columns: new[] { "RussiaId", "USAId", "WorldId" },
                values: new object[] { null, 436, 437 });

            migrationBuilder.UpdateData(
                table: "Fees",
                keyColumn: "Id",
                keyValue: 117,
                columns: new[] { "RussiaId", "USAId", "WorldId" },
                values: new object[] { 438, 439, 440 });

            migrationBuilder.UpdateData(
                table: "Fees",
                keyColumn: "Id",
                keyValue: 118,
                columns: new[] { "RussiaId", "USAId", "WorldId" },
                values: new object[] { 441, 442, 443 });

            migrationBuilder.UpdateData(
                table: "Fees",
                keyColumn: "Id",
                keyValue: 119,
                columns: new[] { "RussiaId", "USAId", "WorldId" },
                values: new object[] { 444, 445, 446 });

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 6,
                column: "FeesId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 7,
                column: "FeesId",
                value: 6);

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 8,
                column: "FeesId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 9,
                column: "FeesId",
                value: 7);

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 10,
                column: "FeesId",
                value: 8);

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 11,
                column: "FeesId",
                value: 9);

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 12,
                column: "FeesId",
                value: 10);

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 13,
                column: "FeesId",
                value: 11);

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 14,
                column: "FeesId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 15,
                column: "FeesId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 16,
                column: "FeesId",
                value: 12);

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 17,
                column: "FeesId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 18,
                column: "FeesId",
                value: 13);

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 19,
                column: "FeesId",
                value: 14);

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 20,
                column: "FeesId",
                value: 15);

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 21,
                column: "FeesId",
                value: 16);

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 22,
                column: "FeesId",
                value: 17);

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 23,
                column: "FeesId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 24,
                column: "FeesId",
                value: 18);

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 25,
                column: "FeesId",
                value: 19);

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 26,
                column: "FeesId",
                value: 20);

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 27,
                column: "FeesId",
                value: 21);

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 28,
                column: "FeesId",
                value: 22);

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 29,
                column: "FeesId",
                value: 23);

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 30,
                column: "FeesId",
                value: 24);

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 31,
                column: "FeesId",
                value: 25);

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 32,
                column: "FeesId",
                value: 26);

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 33,
                column: "FeesId",
                value: 27);

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 34,
                column: "FeesId",
                value: 28);

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 35,
                column: "FeesId",
                value: 29);

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 36,
                column: "FeesId",
                value: 30);

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 37,
                column: "FeesId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 38,
                column: "FeesId",
                value: 31);

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 39,
                column: "FeesId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 40,
                column: "FeesId",
                value: 32);

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 41,
                column: "FeesId",
                value: 33);

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 42,
                column: "FeesId",
                value: 34);

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 43,
                column: "FeesId",
                value: 35);

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 44,
                column: "FeesId",
                value: 36);

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 45,
                column: "FeesId",
                value: 37);

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 46,
                column: "FeesId",
                value: 38);

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 47,
                column: "FeesId",
                value: 39);

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 48,
                column: "FeesId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 49,
                column: "FeesId",
                value: 40);

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 50,
                column: "FeesId",
                value: 41);

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 51,
                column: "FeesId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 52,
                column: "FeesId",
                value: 42);

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 53,
                column: "FeesId",
                value: 43);

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 54,
                column: "FeesId",
                value: 44);

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 55,
                column: "FeesId",
                value: 45);

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 56,
                column: "FeesId",
                value: 46);

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 57,
                column: "FeesId",
                value: 47);

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 58,
                column: "FeesId",
                value: 48);

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 59,
                column: "FeesId",
                value: 49);

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 60,
                column: "FeesId",
                value: 50);

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 61,
                column: "FeesId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 62,
                column: "FeesId",
                value: 51);

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 63,
                column: "FeesId",
                value: 52);

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 64,
                column: "FeesId",
                value: 53);

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 65,
                column: "FeesId",
                value: 54);

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 66,
                column: "FeesId",
                value: 55);

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 67,
                column: "FeesId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 68,
                column: "FeesId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 69,
                column: "FeesId",
                value: 56);

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 70,
                column: "FeesId",
                value: 57);

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 71,
                column: "FeesId",
                value: 58);

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 72,
                column: "FeesId",
                value: 59);

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 73,
                column: "FeesId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 74,
                column: "FeesId",
                value: 60);

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 75,
                column: "FeesId",
                value: 61);

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 76,
                column: "FeesId",
                value: 62);

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 77,
                column: "FeesId",
                value: 63);

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 78,
                column: "FeesId",
                value: 64);

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 79,
                column: "FeesId",
                value: 65);

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 80,
                column: "FeesId",
                value: 66);

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 81,
                column: "FeesId",
                value: 67);

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 82,
                column: "FeesId",
                value: 68);

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 83,
                column: "FeesId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 84,
                column: "FeesId",
                value: 69);

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 85,
                column: "FeesId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 86,
                column: "FeesId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 87,
                column: "FeesId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 88,
                column: "FeesId",
                value: 70);

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 89,
                column: "FeesId",
                value: 71);

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 90,
                column: "FeesId",
                value: 72);

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 91,
                column: "FeesId",
                value: 73);

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 92,
                column: "FeesId",
                value: 74);

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 93,
                column: "FeesId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 94,
                column: "FeesId",
                value: 75);

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 95,
                column: "FeesId",
                value: 76);

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 96,
                column: "FeesId",
                value: 77);

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 97,
                column: "FeesId",
                value: 78);

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 98,
                column: "FeesId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 99,
                column: "FeesId",
                value: 79);

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 100,
                column: "FeesId",
                value: 80);

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 101,
                column: "FeesId",
                value: 81);

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 102,
                column: "FeesId",
                value: 82);

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 103,
                column: "FeesId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 104,
                column: "FeesId",
                value: 83);

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 105,
                column: "FeesId",
                value: 84);

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 106,
                column: "FeesId",
                value: 85);

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 107,
                column: "FeesId",
                value: 86);

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 108,
                column: "FeesId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 109,
                column: "FeesId",
                value: 87);

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 110,
                column: "FeesId",
                value: 88);

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 111,
                column: "FeesId",
                value: 89);

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 112,
                column: "FeesId",
                value: 90);

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 113,
                column: "FeesId",
                value: 91);

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 114,
                column: "FeesId",
                value: 92);

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 115,
                column: "FeesId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 116,
                column: "FeesId",
                value: 93);

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 117,
                column: "FeesId",
                value: 94);

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 118,
                column: "FeesId",
                value: 95);

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 119,
                column: "FeesId",
                value: 96);

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 120,
                column: "FeesId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 121,
                column: "FeesId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 122,
                column: "FeesId",
                value: 97);

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 123,
                column: "FeesId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 124,
                column: "FeesId",
                value: 98);

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 125,
                column: "FeesId",
                value: 99);

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 126,
                column: "FeesId",
                value: 100);

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 127,
                column: "FeesId",
                value: 101);

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 128,
                column: "FeesId",
                value: 102);

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 129,
                column: "FeesId",
                value: 103);

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 130,
                column: "FeesId",
                value: 104);

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 131,
                column: "FeesId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 132,
                column: "FeesId",
                value: 105);

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 133,
                column: "FeesId",
                value: 106);

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 134,
                column: "FeesId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 135,
                column: "FeesId",
                value: 107);

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 136,
                column: "FeesId",
                value: 108);

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 137,
                column: "FeesId",
                value: 109);

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 138,
                column: "FeesId",
                value: 110);

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 139,
                column: "FeesId",
                value: 111);

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 140,
                column: "FeesId",
                value: 112);

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 141,
                column: "FeesId",
                value: 113);

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 142,
                column: "FeesId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 143,
                column: "FeesId",
                value: 114);

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 144,
                column: "FeesId",
                value: 115);

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 145,
                column: "FeesId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 146,
                column: "FeesId",
                value: 116);

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 147,
                column: "FeesId",
                value: 117);

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 148,
                column: "FeesId",
                value: 118);

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 149,
                column: "FeesId",
                value: 119);

            migrationBuilder.AddForeignKey(
                name: "FK_CountryMovieInfo_Countries_CountryId",
                table: "CountryMovieInfo",
                column: "CountryId",
                principalTable: "Countries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Fees_CurrencyValues_RussiaId",
                table: "Fees",
                column: "RussiaId",
                principalTable: "CurrencyValues",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Fees_CurrencyValues_USAId",
                table: "Fees",
                column: "USAId",
                principalTable: "CurrencyValues",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Fees_CurrencyValues_WorldId",
                table: "Fees",
                column: "WorldId",
                principalTable: "CurrencyValues",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_GenreMovieInfo_Genres_GenreId",
                table: "GenreMovieInfo",
                column: "GenreId",
                principalTable: "Genres",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Movies_CurrencyValues_BudgetId",
                table: "Movies",
                column: "BudgetId",
                principalTable: "CurrencyValues",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PersonProffessionInMovie_Persons_PersonId",
                table: "PersonProffessionInMovie",
                column: "PersonId",
                principalTable: "Persons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SeasonsInfos_Movies_MovieInfoId",
                table: "SeasonsInfos",
                column: "MovieInfoId",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CountryMovieInfo_Countries_CountryId",
                table: "CountryMovieInfo");

            migrationBuilder.DropForeignKey(
                name: "FK_Fees_CurrencyValues_RussiaId",
                table: "Fees");

            migrationBuilder.DropForeignKey(
                name: "FK_Fees_CurrencyValues_USAId",
                table: "Fees");

            migrationBuilder.DropForeignKey(
                name: "FK_Fees_CurrencyValues_WorldId",
                table: "Fees");

            migrationBuilder.DropForeignKey(
                name: "FK_GenreMovieInfo_Genres_GenreId",
                table: "GenreMovieInfo");

            migrationBuilder.DropForeignKey(
                name: "FK_Movies_CurrencyValues_BudgetId",
                table: "Movies");

            migrationBuilder.DropForeignKey(
                name: "FK_PersonProffessionInMovie_Persons_PersonId",
                table: "PersonProffessionInMovie");

            migrationBuilder.DropForeignKey(
                name: "FK_SeasonsInfos_Movies_MovieInfoId",
                table: "SeasonsInfos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SeasonsInfos",
                table: "SeasonsInfos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Persons",
                table: "Persons");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Genres",
                table: "Genres");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CurrencyValues",
                table: "CurrencyValues");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Countries",
                table: "Countries");

            migrationBuilder.RenameTable(
                name: "SeasonsInfos",
                newName: "SeasonsInfo");

            migrationBuilder.RenameTable(
                name: "Persons",
                newName: "Person");

            migrationBuilder.RenameTable(
                name: "Genres",
                newName: "Genre");

            migrationBuilder.RenameTable(
                name: "CurrencyValues",
                newName: "CurrencyValue");

            migrationBuilder.RenameTable(
                name: "Countries",
                newName: "Country");

            migrationBuilder.RenameIndex(
                name: "IX_SeasonsInfos_MovieInfoId",
                table: "SeasonsInfo",
                newName: "IX_SeasonsInfo_MovieInfoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SeasonsInfo",
                table: "SeasonsInfo",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Person",
                table: "Person",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Genre",
                table: "Genre",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CurrencyValue",
                table: "CurrencyValue",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Country",
                table: "Country",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "Fees",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "RussiaId", "USAId", "WorldId" },
                values: new object[] { null, null, null });

            migrationBuilder.UpdateData(
                table: "Fees",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "RussiaId", "USAId", "WorldId" },
                values: new object[] { 131, 132, 133 });

            migrationBuilder.UpdateData(
                table: "Fees",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "RussiaId", "USAId", "WorldId" },
                values: new object[] { null, null, null });

            migrationBuilder.UpdateData(
                table: "Fees",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "RussiaId", "USAId", "WorldId" },
                values: new object[] { 134, 135, 136 });

            migrationBuilder.UpdateData(
                table: "Fees",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "RussiaId", "USAId", "WorldId" },
                values: new object[] { 137, 138, 139 });

            migrationBuilder.UpdateData(
                table: "Fees",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "USAId", "WorldId" },
                values: new object[] { 140, 141 });

            migrationBuilder.UpdateData(
                table: "Fees",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "RussiaId", "USAId", "WorldId" },
                values: new object[] { 142, null, 143 });

            migrationBuilder.UpdateData(
                table: "Fees",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "RussiaId", "USAId", "WorldId" },
                values: new object[] { null, null, 144 });

            migrationBuilder.UpdateData(
                table: "Fees",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "RussiaId", "USAId", "WorldId" },
                values: new object[] { null, null, null });

            migrationBuilder.UpdateData(
                table: "Fees",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "RussiaId", "USAId", "WorldId" },
                values: new object[] { null, null, null });

            migrationBuilder.UpdateData(
                table: "Fees",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "RussiaId", "USAId", "WorldId" },
                values: new object[] { 145, 146, 147 });

            migrationBuilder.UpdateData(
                table: "Fees",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "RussiaId", "USAId", "WorldId" },
                values: new object[] { null, null, null });

            migrationBuilder.UpdateData(
                table: "Fees",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "RussiaId", "USAId", "WorldId" },
                values: new object[] { 148, 149, 150 });

            migrationBuilder.UpdateData(
                table: "Fees",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "RussiaId", "USAId", "WorldId" },
                values: new object[] { 151, 152, 153 });

            migrationBuilder.UpdateData(
                table: "Fees",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "RussiaId", "USAId", "WorldId" },
                values: new object[] { 154, 155, 156 });

            migrationBuilder.UpdateData(
                table: "Fees",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "RussiaId", "USAId", "WorldId" },
                values: new object[] { 157, 158, 159 });

            migrationBuilder.UpdateData(
                table: "Fees",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "RussiaId", "USAId", "WorldId" },
                values: new object[] { 160, 161, 162 });

            migrationBuilder.UpdateData(
                table: "Fees",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "RussiaId", "USAId", "WorldId" },
                values: new object[] { null, null, null });

            migrationBuilder.UpdateData(
                table: "Fees",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "RussiaId", "USAId", "WorldId" },
                values: new object[] { 163, 164, 165 });

            migrationBuilder.UpdateData(
                table: "Fees",
                keyColumn: "Id",
                keyValue: 25,
                columns: new[] { "RussiaId", "USAId", "WorldId" },
                values: new object[] { 166, 167, 168 });

            migrationBuilder.UpdateData(
                table: "Fees",
                keyColumn: "Id",
                keyValue: 26,
                columns: new[] { "RussiaId", "USAId", "WorldId" },
                values: new object[] { 169, 170, 171 });

            migrationBuilder.UpdateData(
                table: "Fees",
                keyColumn: "Id",
                keyValue: 27,
                columns: new[] { "RussiaId", "USAId", "WorldId" },
                values: new object[] { 172, 173, 174 });

            migrationBuilder.UpdateData(
                table: "Fees",
                keyColumn: "Id",
                keyValue: 28,
                columns: new[] { "RussiaId", "USAId", "WorldId" },
                values: new object[] { 175, 176, 177 });

            migrationBuilder.UpdateData(
                table: "Fees",
                keyColumn: "Id",
                keyValue: 29,
                columns: new[] { "RussiaId", "USAId", "WorldId" },
                values: new object[] { 178, 179, 180 });

            migrationBuilder.UpdateData(
                table: "Fees",
                keyColumn: "Id",
                keyValue: 30,
                columns: new[] { "RussiaId", "USAId", "WorldId" },
                values: new object[] { 181, 182, 183 });

            migrationBuilder.UpdateData(
                table: "Fees",
                keyColumn: "Id",
                keyValue: 31,
                columns: new[] { "RussiaId", "USAId", "WorldId" },
                values: new object[] { 184, 185, 186 });

            migrationBuilder.UpdateData(
                table: "Fees",
                keyColumn: "Id",
                keyValue: 32,
                columns: new[] { "RussiaId", "USAId", "WorldId" },
                values: new object[] { 187, 188, 189 });

            migrationBuilder.UpdateData(
                table: "Fees",
                keyColumn: "Id",
                keyValue: 33,
                columns: new[] { "RussiaId", "USAId", "WorldId" },
                values: new object[] { 190, 191, 192 });

            migrationBuilder.UpdateData(
                table: "Fees",
                keyColumn: "Id",
                keyValue: 34,
                columns: new[] { "RussiaId", "USAId", "WorldId" },
                values: new object[] { 193, 194, 195 });

            migrationBuilder.UpdateData(
                table: "Fees",
                keyColumn: "Id",
                keyValue: 35,
                columns: new[] { "RussiaId", "USAId", "WorldId" },
                values: new object[] { 196, 197, 198 });

            migrationBuilder.UpdateData(
                table: "Fees",
                keyColumn: "Id",
                keyValue: 36,
                columns: new[] { "RussiaId", "USAId", "WorldId" },
                values: new object[] { 199, 200, 201 });

            migrationBuilder.UpdateData(
                table: "Fees",
                keyColumn: "Id",
                keyValue: 37,
                columns: new[] { "RussiaId", "USAId", "WorldId" },
                values: new object[] { null, null, null });

            migrationBuilder.UpdateData(
                table: "Fees",
                keyColumn: "Id",
                keyValue: 38,
                columns: new[] { "RussiaId", "USAId", "WorldId" },
                values: new object[] { 202, 203, 204 });

            migrationBuilder.UpdateData(
                table: "Fees",
                keyColumn: "Id",
                keyValue: 39,
                columns: new[] { "RussiaId", "USAId", "WorldId" },
                values: new object[] { null, null, null });

            migrationBuilder.UpdateData(
                table: "Fees",
                keyColumn: "Id",
                keyValue: 40,
                columns: new[] { "RussiaId", "USAId", "WorldId" },
                values: new object[] { null, 205, 206 });

            migrationBuilder.UpdateData(
                table: "Fees",
                keyColumn: "Id",
                keyValue: 41,
                columns: new[] { "RussiaId", "USAId", "WorldId" },
                values: new object[] { 207, 208, 209 });

            migrationBuilder.UpdateData(
                table: "Fees",
                keyColumn: "Id",
                keyValue: 42,
                columns: new[] { "RussiaId", "WorldId" },
                values: new object[] { null, 210 });

            migrationBuilder.UpdateData(
                table: "Fees",
                keyColumn: "Id",
                keyValue: 43,
                columns: new[] { "RussiaId", "USAId", "WorldId" },
                values: new object[] { 211, 212, 213 });

            migrationBuilder.UpdateData(
                table: "Fees",
                keyColumn: "Id",
                keyValue: 44,
                columns: new[] { "RussiaId", "USAId", "WorldId" },
                values: new object[] { 214, 215, 216 });

            migrationBuilder.UpdateData(
                table: "Fees",
                keyColumn: "Id",
                keyValue: 45,
                columns: new[] { "RussiaId", "USAId", "WorldId" },
                values: new object[] { 217, 218, 219 });

            migrationBuilder.UpdateData(
                table: "Fees",
                keyColumn: "Id",
                keyValue: 46,
                columns: new[] { "RussiaId", "USAId", "WorldId" },
                values: new object[] { 220, 221, 222 });

            migrationBuilder.UpdateData(
                table: "Fees",
                keyColumn: "Id",
                keyValue: 47,
                columns: new[] { "RussiaId", "USAId", "WorldId" },
                values: new object[] { 223, 224, 225 });

            migrationBuilder.UpdateData(
                table: "Fees",
                keyColumn: "Id",
                keyValue: 48,
                columns: new[] { "RussiaId", "USAId", "WorldId" },
                values: new object[] { null, null, null });

            migrationBuilder.UpdateData(
                table: "Fees",
                keyColumn: "Id",
                keyValue: 49,
                columns: new[] { "RussiaId", "USAId", "WorldId" },
                values: new object[] { 226, 227, 228 });

            migrationBuilder.UpdateData(
                table: "Fees",
                keyColumn: "Id",
                keyValue: 50,
                columns: new[] { "RussiaId", "USAId", "WorldId" },
                values: new object[] { null, 229, 230 });

            migrationBuilder.UpdateData(
                table: "Fees",
                keyColumn: "Id",
                keyValue: 51,
                columns: new[] { "RussiaId", "USAId", "WorldId" },
                values: new object[] { null, null, null });

            migrationBuilder.UpdateData(
                table: "Fees",
                keyColumn: "Id",
                keyValue: 52,
                columns: new[] { "RussiaId", "USAId", "WorldId" },
                values: new object[] { 231, null, 232 });

            migrationBuilder.UpdateData(
                table: "Fees",
                keyColumn: "Id",
                keyValue: 53,
                columns: new[] { "RussiaId", "USAId", "WorldId" },
                values: new object[] { 233, 234, 235 });

            migrationBuilder.UpdateData(
                table: "Fees",
                keyColumn: "Id",
                keyValue: 54,
                columns: new[] { "RussiaId", "USAId", "WorldId" },
                values: new object[] { 236, 237, 238 });

            migrationBuilder.UpdateData(
                table: "Fees",
                keyColumn: "Id",
                keyValue: 55,
                columns: new[] { "RussiaId", "USAId", "WorldId" },
                values: new object[] { 239, 240, 241 });

            migrationBuilder.UpdateData(
                table: "Fees",
                keyColumn: "Id",
                keyValue: 56,
                columns: new[] { "RussiaId", "USAId", "WorldId" },
                values: new object[] { 242, 243, 244 });

            migrationBuilder.UpdateData(
                table: "Fees",
                keyColumn: "Id",
                keyValue: 57,
                columns: new[] { "RussiaId", "USAId", "WorldId" },
                values: new object[] { 245, 246, 247 });

            migrationBuilder.UpdateData(
                table: "Fees",
                keyColumn: "Id",
                keyValue: 58,
                columns: new[] { "RussiaId", "USAId", "WorldId" },
                values: new object[] { 248, 249, 250 });

            migrationBuilder.UpdateData(
                table: "Fees",
                keyColumn: "Id",
                keyValue: 59,
                columns: new[] { "RussiaId", "USAId", "WorldId" },
                values: new object[] { 251, 252, 253 });

            migrationBuilder.UpdateData(
                table: "Fees",
                keyColumn: "Id",
                keyValue: 60,
                columns: new[] { "RussiaId", "USAId", "WorldId" },
                values: new object[] { 254, 255, 256 });

            migrationBuilder.UpdateData(
                table: "Fees",
                keyColumn: "Id",
                keyValue: 61,
                columns: new[] { "USAId", "WorldId" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Fees",
                keyColumn: "Id",
                keyValue: 62,
                columns: new[] { "RussiaId", "USAId", "WorldId" },
                values: new object[] { 257, 258, 259 });

            migrationBuilder.UpdateData(
                table: "Fees",
                keyColumn: "Id",
                keyValue: 63,
                columns: new[] { "RussiaId", "USAId", "WorldId" },
                values: new object[] { 260, 261, 262 });

            migrationBuilder.UpdateData(
                table: "Fees",
                keyColumn: "Id",
                keyValue: 64,
                columns: new[] { "RussiaId", "USAId", "WorldId" },
                values: new object[] { 263, 264, 265 });

            migrationBuilder.UpdateData(
                table: "Fees",
                keyColumn: "Id",
                keyValue: 65,
                columns: new[] { "RussiaId", "USAId", "WorldId" },
                values: new object[] { 266, 267, 268 });

            migrationBuilder.UpdateData(
                table: "Fees",
                keyColumn: "Id",
                keyValue: 66,
                columns: new[] { "RussiaId", "USAId", "WorldId" },
                values: new object[] { null, 269, 270 });

            migrationBuilder.UpdateData(
                table: "Fees",
                keyColumn: "Id",
                keyValue: 67,
                columns: new[] { "RussiaId", "USAId", "WorldId" },
                values: new object[] { null, null, null });

            migrationBuilder.UpdateData(
                table: "Fees",
                keyColumn: "Id",
                keyValue: 68,
                columns: new[] { "USAId", "WorldId" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Fees",
                keyColumn: "Id",
                keyValue: 69,
                columns: new[] { "RussiaId", "USAId", "WorldId" },
                values: new object[] { 271, 272, 273 });

            migrationBuilder.UpdateData(
                table: "Fees",
                keyColumn: "Id",
                keyValue: 70,
                columns: new[] { "RussiaId", "USAId", "WorldId" },
                values: new object[] { 274, 275, 276 });

            migrationBuilder.UpdateData(
                table: "Fees",
                keyColumn: "Id",
                keyValue: 71,
                columns: new[] { "RussiaId", "USAId", "WorldId" },
                values: new object[] { 277, 278, 279 });

            migrationBuilder.UpdateData(
                table: "Fees",
                keyColumn: "Id",
                keyValue: 72,
                columns: new[] { "RussiaId", "USAId", "WorldId" },
                values: new object[] { 280, 281, 282 });

            migrationBuilder.UpdateData(
                table: "Fees",
                keyColumn: "Id",
                keyValue: 73,
                column: "WorldId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Fees",
                keyColumn: "Id",
                keyValue: 74,
                columns: new[] { "RussiaId", "USAId", "WorldId" },
                values: new object[] { 283, 284, 285 });

            migrationBuilder.UpdateData(
                table: "Fees",
                keyColumn: "Id",
                keyValue: 75,
                columns: new[] { "RussiaId", "USAId", "WorldId" },
                values: new object[] { null, 286, 287 });

            migrationBuilder.UpdateData(
                table: "Fees",
                keyColumn: "Id",
                keyValue: 76,
                columns: new[] { "RussiaId", "USAId", "WorldId" },
                values: new object[] { 288, 289, 290 });

            migrationBuilder.UpdateData(
                table: "Fees",
                keyColumn: "Id",
                keyValue: 77,
                columns: new[] { "RussiaId", "USAId", "WorldId" },
                values: new object[] { 291, 292, 293 });

            migrationBuilder.UpdateData(
                table: "Fees",
                keyColumn: "Id",
                keyValue: 78,
                columns: new[] { "RussiaId", "USAId", "WorldId" },
                values: new object[] { 294, 295, 296 });

            migrationBuilder.UpdateData(
                table: "Fees",
                keyColumn: "Id",
                keyValue: 79,
                columns: new[] { "RussiaId", "USAId", "WorldId" },
                values: new object[] { 297, 298, 299 });

            migrationBuilder.UpdateData(
                table: "Fees",
                keyColumn: "Id",
                keyValue: 80,
                columns: new[] { "RussiaId", "USAId", "WorldId" },
                values: new object[] { 300, 301, 302 });

            migrationBuilder.UpdateData(
                table: "Fees",
                keyColumn: "Id",
                keyValue: 81,
                columns: new[] { "RussiaId", "USAId", "WorldId" },
                values: new object[] { 303, 304, 305 });

            migrationBuilder.UpdateData(
                table: "Fees",
                keyColumn: "Id",
                keyValue: 82,
                columns: new[] { "RussiaId", "USAId", "WorldId" },
                values: new object[] { null, 306, 307 });

            migrationBuilder.UpdateData(
                table: "Fees",
                keyColumn: "Id",
                keyValue: 83,
                columns: new[] { "RussiaId", "USAId", "WorldId" },
                values: new object[] { null, null, null });

            migrationBuilder.UpdateData(
                table: "Fees",
                keyColumn: "Id",
                keyValue: 84,
                columns: new[] { "RussiaId", "USAId", "WorldId" },
                values: new object[] { 308, 309, 310 });

            migrationBuilder.UpdateData(
                table: "Fees",
                keyColumn: "Id",
                keyValue: 85,
                columns: new[] { "RussiaId", "USAId", "WorldId" },
                values: new object[] { null, null, null });

            migrationBuilder.UpdateData(
                table: "Fees",
                keyColumn: "Id",
                keyValue: 86,
                columns: new[] { "RussiaId", "USAId", "WorldId" },
                values: new object[] { null, null, null });

            migrationBuilder.UpdateData(
                table: "Fees",
                keyColumn: "Id",
                keyValue: 87,
                columns: new[] { "RussiaId", "USAId", "WorldId" },
                values: new object[] { null, null, null });

            migrationBuilder.UpdateData(
                table: "Fees",
                keyColumn: "Id",
                keyValue: 88,
                columns: new[] { "RussiaId", "USAId", "WorldId" },
                values: new object[] { null, 311, 312 });

            migrationBuilder.UpdateData(
                table: "Fees",
                keyColumn: "Id",
                keyValue: 89,
                columns: new[] { "RussiaId", "USAId", "WorldId" },
                values: new object[] { null, 313, 314 });

            migrationBuilder.UpdateData(
                table: "Fees",
                keyColumn: "Id",
                keyValue: 90,
                columns: new[] { "RussiaId", "USAId", "WorldId" },
                values: new object[] { null, 315, 316 });

            migrationBuilder.UpdateData(
                table: "Fees",
                keyColumn: "Id",
                keyValue: 91,
                columns: new[] { "RussiaId", "USAId", "WorldId" },
                values: new object[] { null, null, 317 });

            migrationBuilder.UpdateData(
                table: "Fees",
                keyColumn: "Id",
                keyValue: 92,
                columns: new[] { "RussiaId", "USAId", "WorldId" },
                values: new object[] { 318, 319, 320 });

            migrationBuilder.UpdateData(
                table: "Fees",
                keyColumn: "Id",
                keyValue: 93,
                columns: new[] { "RussiaId", "USAId", "WorldId" },
                values: new object[] { null, null, null });

            migrationBuilder.UpdateData(
                table: "Fees",
                keyColumn: "Id",
                keyValue: 94,
                columns: new[] { "RussiaId", "USAId", "WorldId" },
                values: new object[] { 321, 322, 323 });

            migrationBuilder.UpdateData(
                table: "Fees",
                keyColumn: "Id",
                keyValue: 95,
                columns: new[] { "RussiaId", "USAId", "WorldId" },
                values: new object[] { 324, 325, 326 });

            migrationBuilder.UpdateData(
                table: "Fees",
                keyColumn: "Id",
                keyValue: 96,
                columns: new[] { "RussiaId", "USAId", "WorldId" },
                values: new object[] { null, 327, 328 });

            migrationBuilder.UpdateData(
                table: "Fees",
                keyColumn: "Id",
                keyValue: 97,
                columns: new[] { "RussiaId", "USAId", "WorldId" },
                values: new object[] { 329, 330, 331 });

            migrationBuilder.UpdateData(
                table: "Fees",
                keyColumn: "Id",
                keyValue: 98,
                columns: new[] { "USAId", "WorldId" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Fees",
                keyColumn: "Id",
                keyValue: 99,
                columns: new[] { "RussiaId", "USAId", "WorldId" },
                values: new object[] { 332, 333, 334 });

            migrationBuilder.UpdateData(
                table: "Fees",
                keyColumn: "Id",
                keyValue: 100,
                columns: new[] { "RussiaId", "USAId", "WorldId" },
                values: new object[] { null, 335, 336 });

            migrationBuilder.UpdateData(
                table: "Fees",
                keyColumn: "Id",
                keyValue: 101,
                columns: new[] { "RussiaId", "USAId", "WorldId" },
                values: new object[] { 337, 338, 339 });

            migrationBuilder.UpdateData(
                table: "Fees",
                keyColumn: "Id",
                keyValue: 102,
                columns: new[] { "RussiaId", "USAId", "WorldId" },
                values: new object[] { 340, 341, 342 });

            migrationBuilder.UpdateData(
                table: "Fees",
                keyColumn: "Id",
                keyValue: 103,
                columns: new[] { "RussiaId", "USAId", "WorldId" },
                values: new object[] { null, null, null });

            migrationBuilder.UpdateData(
                table: "Fees",
                keyColumn: "Id",
                keyValue: 104,
                columns: new[] { "RussiaId", "USAId", "WorldId" },
                values: new object[] { 343, 344, 345 });

            migrationBuilder.UpdateData(
                table: "Fees",
                keyColumn: "Id",
                keyValue: 105,
                columns: new[] { "RussiaId", "USAId", "WorldId" },
                values: new object[] { 346, 347, 348 });

            migrationBuilder.UpdateData(
                table: "Fees",
                keyColumn: "Id",
                keyValue: 106,
                columns: new[] { "RussiaId", "USAId", "WorldId" },
                values: new object[] { 349, 350, 351 });

            migrationBuilder.UpdateData(
                table: "Fees",
                keyColumn: "Id",
                keyValue: 107,
                columns: new[] { "RussiaId", "USAId", "WorldId" },
                values: new object[] { 352, 353, 354 });

            migrationBuilder.UpdateData(
                table: "Fees",
                keyColumn: "Id",
                keyValue: 108,
                columns: new[] { "RussiaId", "USAId", "WorldId" },
                values: new object[] { null, null, null });

            migrationBuilder.UpdateData(
                table: "Fees",
                keyColumn: "Id",
                keyValue: 109,
                columns: new[] { "RussiaId", "USAId", "WorldId" },
                values: new object[] { 355, 356, 357 });

            migrationBuilder.UpdateData(
                table: "Fees",
                keyColumn: "Id",
                keyValue: 110,
                columns: new[] { "RussiaId", "USAId", "WorldId" },
                values: new object[] { 358, 359, 360 });

            migrationBuilder.UpdateData(
                table: "Fees",
                keyColumn: "Id",
                keyValue: 111,
                columns: new[] { "RussiaId", "USAId", "WorldId" },
                values: new object[] { 361, 362, 363 });

            migrationBuilder.UpdateData(
                table: "Fees",
                keyColumn: "Id",
                keyValue: 112,
                columns: new[] { "RussiaId", "USAId", "WorldId" },
                values: new object[] { 364, 365, 366 });

            migrationBuilder.UpdateData(
                table: "Fees",
                keyColumn: "Id",
                keyValue: 113,
                columns: new[] { "RussiaId", "USAId", "WorldId" },
                values: new object[] { 367, 368, 369 });

            migrationBuilder.UpdateData(
                table: "Fees",
                keyColumn: "Id",
                keyValue: 114,
                columns: new[] { "RussiaId", "USAId", "WorldId" },
                values: new object[] { 370, 371, 372 });

            migrationBuilder.UpdateData(
                table: "Fees",
                keyColumn: "Id",
                keyValue: 115,
                columns: new[] { "RussiaId", "USAId", "WorldId" },
                values: new object[] { null, null, null });

            migrationBuilder.UpdateData(
                table: "Fees",
                keyColumn: "Id",
                keyValue: 116,
                columns: new[] { "RussiaId", "USAId", "WorldId" },
                values: new object[] { 373, 374, 375 });

            migrationBuilder.UpdateData(
                table: "Fees",
                keyColumn: "Id",
                keyValue: 117,
                columns: new[] { "RussiaId", "USAId", "WorldId" },
                values: new object[] { 376, 377, 378 });

            migrationBuilder.UpdateData(
                table: "Fees",
                keyColumn: "Id",
                keyValue: 118,
                columns: new[] { "RussiaId", "USAId", "WorldId" },
                values: new object[] { null, 379, 380 });

            migrationBuilder.UpdateData(
                table: "Fees",
                keyColumn: "Id",
                keyValue: 119,
                columns: new[] { "RussiaId", "USAId", "WorldId" },
                values: new object[] { 381, 382, 383 });

            migrationBuilder.InsertData(
                table: "Fees",
                columns: new[] { "Id", "RussiaId", "USAId", "WorldId" },
                values: new object[,]
                {
                    { 120, null, null, null },
                    { 121, null, null, null },
                    { 122, null, 384, 385 },
                    { 123, null, null, null },
                    { 124, null, 386, 387 },
                    { 125, 388, 389, 390 },
                    { 126, 391, 392, 393 },
                    { 127, 394, 395, 396 },
                    { 128, 397, null, 398 },
                    { 129, 399, 400, 401 },
                    { 130, 402, 403, 404 },
                    { 131, null, null, null },
                    { 132, 405, 406, 407 },
                    { 133, 408, 409, 410 },
                    { 134, null, null, null },
                    { 135, 411, 412, 413 },
                    { 136, 414, 415, 416 },
                    { 137, 417, 418, 419 },
                    { 138, null, 420, 421 },
                    { 139, 422, 423, 424 },
                    { 140, 425, null, 426 },
                    { 141, 427, 428, 429 },
                    { 142, null, null, null },
                    { 143, 430, 431, 432 },
                    { 144, 433, 434, 435 },
                    { 145, null, null, null },
                    { 146, null, 436, 437 },
                    { 147, 438, 439, 440 },
                    { 148, 441, 442, 443 },
                    { 149, 444, 445, 446 }
                });

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 6,
                column: "FeesId",
                value: 6);

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 7,
                column: "FeesId",
                value: 7);

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 8,
                column: "FeesId",
                value: 8);

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 9,
                column: "FeesId",
                value: 9);

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 10,
                column: "FeesId",
                value: 10);

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 11,
                column: "FeesId",
                value: 11);

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 12,
                column: "FeesId",
                value: 12);

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 13,
                column: "FeesId",
                value: 13);

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 14,
                column: "FeesId",
                value: 14);

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 15,
                column: "FeesId",
                value: 15);

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 16,
                column: "FeesId",
                value: 16);

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 17,
                column: "FeesId",
                value: 17);

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 18,
                column: "FeesId",
                value: 18);

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 19,
                column: "FeesId",
                value: 19);

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 20,
                column: "FeesId",
                value: 20);

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 21,
                column: "FeesId",
                value: 21);

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 22,
                column: "FeesId",
                value: 22);

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 23,
                column: "FeesId",
                value: 23);

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 24,
                column: "FeesId",
                value: 24);

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 25,
                column: "FeesId",
                value: 25);

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 26,
                column: "FeesId",
                value: 26);

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 27,
                column: "FeesId",
                value: 27);

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 28,
                column: "FeesId",
                value: 28);

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 29,
                column: "FeesId",
                value: 29);

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 30,
                column: "FeesId",
                value: 30);

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 31,
                column: "FeesId",
                value: 31);

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 32,
                column: "FeesId",
                value: 32);

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 33,
                column: "FeesId",
                value: 33);

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 34,
                column: "FeesId",
                value: 34);

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 35,
                column: "FeesId",
                value: 35);

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 36,
                column: "FeesId",
                value: 36);

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 37,
                column: "FeesId",
                value: 37);

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 38,
                column: "FeesId",
                value: 38);

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 39,
                column: "FeesId",
                value: 39);

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 40,
                column: "FeesId",
                value: 40);

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 41,
                column: "FeesId",
                value: 41);

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 42,
                column: "FeesId",
                value: 42);

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 43,
                column: "FeesId",
                value: 43);

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 44,
                column: "FeesId",
                value: 44);

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 45,
                column: "FeesId",
                value: 45);

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 46,
                column: "FeesId",
                value: 46);

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 47,
                column: "FeesId",
                value: 47);

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 48,
                column: "FeesId",
                value: 48);

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 49,
                column: "FeesId",
                value: 49);

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 50,
                column: "FeesId",
                value: 50);

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 51,
                column: "FeesId",
                value: 51);

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 52,
                column: "FeesId",
                value: 52);

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 53,
                column: "FeesId",
                value: 53);

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 54,
                column: "FeesId",
                value: 54);

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 55,
                column: "FeesId",
                value: 55);

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 56,
                column: "FeesId",
                value: 56);

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 57,
                column: "FeesId",
                value: 57);

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 58,
                column: "FeesId",
                value: 58);

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 59,
                column: "FeesId",
                value: 59);

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 60,
                column: "FeesId",
                value: 60);

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 61,
                column: "FeesId",
                value: 61);

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 62,
                column: "FeesId",
                value: 62);

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 63,
                column: "FeesId",
                value: 63);

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 64,
                column: "FeesId",
                value: 64);

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 65,
                column: "FeesId",
                value: 65);

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 66,
                column: "FeesId",
                value: 66);

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 67,
                column: "FeesId",
                value: 67);

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 68,
                column: "FeesId",
                value: 68);

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 69,
                column: "FeesId",
                value: 69);

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 70,
                column: "FeesId",
                value: 70);

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 71,
                column: "FeesId",
                value: 71);

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 72,
                column: "FeesId",
                value: 72);

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 73,
                column: "FeesId",
                value: 73);

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 74,
                column: "FeesId",
                value: 74);

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 75,
                column: "FeesId",
                value: 75);

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 76,
                column: "FeesId",
                value: 76);

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 77,
                column: "FeesId",
                value: 77);

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 78,
                column: "FeesId",
                value: 78);

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 79,
                column: "FeesId",
                value: 79);

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 80,
                column: "FeesId",
                value: 80);

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 81,
                column: "FeesId",
                value: 81);

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 82,
                column: "FeesId",
                value: 82);

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 83,
                column: "FeesId",
                value: 83);

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 84,
                column: "FeesId",
                value: 84);

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 85,
                column: "FeesId",
                value: 85);

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 86,
                column: "FeesId",
                value: 86);

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 87,
                column: "FeesId",
                value: 87);

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 88,
                column: "FeesId",
                value: 88);

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 89,
                column: "FeesId",
                value: 89);

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 90,
                column: "FeesId",
                value: 90);

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 91,
                column: "FeesId",
                value: 91);

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 92,
                column: "FeesId",
                value: 92);

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 93,
                column: "FeesId",
                value: 93);

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 94,
                column: "FeesId",
                value: 94);

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 95,
                column: "FeesId",
                value: 95);

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 96,
                column: "FeesId",
                value: 96);

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 97,
                column: "FeesId",
                value: 97);

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 98,
                column: "FeesId",
                value: 98);

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 99,
                column: "FeesId",
                value: 99);

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 100,
                column: "FeesId",
                value: 100);

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 101,
                column: "FeesId",
                value: 101);

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 102,
                column: "FeesId",
                value: 102);

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 103,
                column: "FeesId",
                value: 103);

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 104,
                column: "FeesId",
                value: 104);

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 105,
                column: "FeesId",
                value: 105);

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 106,
                column: "FeesId",
                value: 106);

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 107,
                column: "FeesId",
                value: 107);

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 108,
                column: "FeesId",
                value: 108);

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 109,
                column: "FeesId",
                value: 109);

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 110,
                column: "FeesId",
                value: 110);

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 111,
                column: "FeesId",
                value: 111);

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 112,
                column: "FeesId",
                value: 112);

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 113,
                column: "FeesId",
                value: 113);

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 114,
                column: "FeesId",
                value: 114);

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 115,
                column: "FeesId",
                value: 115);

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 116,
                column: "FeesId",
                value: 116);

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 117,
                column: "FeesId",
                value: 117);

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 118,
                column: "FeesId",
                value: 118);

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 119,
                column: "FeesId",
                value: 119);

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 120,
                column: "FeesId",
                value: 120);

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 121,
                column: "FeesId",
                value: 121);

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 122,
                column: "FeesId",
                value: 122);

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 123,
                column: "FeesId",
                value: 123);

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 124,
                column: "FeesId",
                value: 124);

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 125,
                column: "FeesId",
                value: 125);

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 126,
                column: "FeesId",
                value: 126);

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 127,
                column: "FeesId",
                value: 127);

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 128,
                column: "FeesId",
                value: 128);

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 129,
                column: "FeesId",
                value: 129);

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 130,
                column: "FeesId",
                value: 130);

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 131,
                column: "FeesId",
                value: 131);

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 132,
                column: "FeesId",
                value: 132);

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 133,
                column: "FeesId",
                value: 133);

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 134,
                column: "FeesId",
                value: 134);

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 135,
                column: "FeesId",
                value: 135);

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 136,
                column: "FeesId",
                value: 136);

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 137,
                column: "FeesId",
                value: 137);

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 138,
                column: "FeesId",
                value: 138);

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 139,
                column: "FeesId",
                value: 139);

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 140,
                column: "FeesId",
                value: 140);

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 141,
                column: "FeesId",
                value: 141);

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 142,
                column: "FeesId",
                value: 142);

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 143,
                column: "FeesId",
                value: 143);

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 144,
                column: "FeesId",
                value: 144);

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 145,
                column: "FeesId",
                value: 145);

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 146,
                column: "FeesId",
                value: 146);

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 147,
                column: "FeesId",
                value: 147);

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 148,
                column: "FeesId",
                value: 148);

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 149,
                column: "FeesId",
                value: 149);

            migrationBuilder.AddForeignKey(
                name: "FK_CountryMovieInfo_Country_CountryId",
                table: "CountryMovieInfo",
                column: "CountryId",
                principalTable: "Country",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Fees_CurrencyValue_RussiaId",
                table: "Fees",
                column: "RussiaId",
                principalTable: "CurrencyValue",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Fees_CurrencyValue_USAId",
                table: "Fees",
                column: "USAId",
                principalTable: "CurrencyValue",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Fees_CurrencyValue_WorldId",
                table: "Fees",
                column: "WorldId",
                principalTable: "CurrencyValue",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_GenreMovieInfo_Genre_GenreId",
                table: "GenreMovieInfo",
                column: "GenreId",
                principalTable: "Genre",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Movies_CurrencyValue_BudgetId",
                table: "Movies",
                column: "BudgetId",
                principalTable: "CurrencyValue",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PersonProffessionInMovie_Person_PersonId",
                table: "PersonProffessionInMovie",
                column: "PersonId",
                principalTable: "Person",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SeasonsInfo_Movies_MovieInfoId",
                table: "SeasonsInfo",
                column: "MovieInfoId",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
