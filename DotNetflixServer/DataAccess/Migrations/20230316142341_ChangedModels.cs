using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BackendAPI.Migrations
{
    /// <inheritdoc />
    public partial class ChangedModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CountryMovieInfo_Country_CountriesId",
                table: "CountryMovieInfo");

            migrationBuilder.DropForeignKey(
                name: "FK_GenreMovieInfo_Genre_GenresId",
                table: "GenreMovieInfo");

            migrationBuilder.DropForeignKey(
                name: "FK_Movies_Fees_FeesId",
                table: "Movies");

            migrationBuilder.DropTable(
                name: "MovieInfoSeasonsInfo");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GenreMovieInfo",
                table: "GenreMovieInfo");

            migrationBuilder.DropIndex(
                name: "IX_GenreMovieInfo_MovieInfoId",
                table: "GenreMovieInfo");

            migrationBuilder.DropCheckConstraint(
                name: "CK_CurrencyValue_Value",
                table: "CurrencyValue");

            migrationBuilder.RenameColumn(
                name: "GenresId",
                table: "GenreMovieInfo",
                newName: "GenreId");

            migrationBuilder.RenameColumn(
                name: "CountriesId",
                table: "CountryMovieInfo",
                newName: "CountryId");

            migrationBuilder.AddColumn<int>(
                name: "MovieInfoId",
                table: "SeasonsInfo",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "FeesId",
                table: "Movies",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GenreMovieInfo",
                table: "GenreMovieInfo",
                columns: new[] { "MovieInfoId", "GenreId" });

            migrationBuilder.CreateIndex(
                name: "IX_SeasonsInfo_MovieInfoId",
                table: "SeasonsInfo",
                column: "MovieInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_GenreMovieInfo_GenreId",
                table: "GenreMovieInfo",
                column: "GenreId");

            migrationBuilder.AddCheckConstraint(
                name: "CK_CurrencyValue_Value",
                table: "CurrencyValue",
                sql: "Value >= 0");

            migrationBuilder.AddForeignKey(
                name: "FK_CountryMovieInfo_Country_CountryId",
                table: "CountryMovieInfo",
                column: "CountryId",
                principalTable: "Country",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GenreMovieInfo_Genre_GenreId",
                table: "GenreMovieInfo",
                column: "GenreId",
                principalTable: "Genre",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Movies_Fees_FeesId",
                table: "Movies",
                column: "FeesId",
                principalTable: "Fees",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SeasonsInfo_Movies_MovieInfoId",
                table: "SeasonsInfo",
                column: "MovieInfoId",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CountryMovieInfo_Country_CountryId",
                table: "CountryMovieInfo");

            migrationBuilder.DropForeignKey(
                name: "FK_GenreMovieInfo_Genre_GenreId",
                table: "GenreMovieInfo");

            migrationBuilder.DropForeignKey(
                name: "FK_Movies_Fees_FeesId",
                table: "Movies");

            migrationBuilder.DropForeignKey(
                name: "FK_SeasonsInfo_Movies_MovieInfoId",
                table: "SeasonsInfo");

            migrationBuilder.DropIndex(
                name: "IX_SeasonsInfo_MovieInfoId",
                table: "SeasonsInfo");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GenreMovieInfo",
                table: "GenreMovieInfo");

            migrationBuilder.DropIndex(
                name: "IX_GenreMovieInfo_GenreId",
                table: "GenreMovieInfo");

            migrationBuilder.DropCheckConstraint(
                name: "CK_CurrencyValue_Value",
                table: "CurrencyValue");

            migrationBuilder.DropColumn(
                name: "MovieInfoId",
                table: "SeasonsInfo");

            migrationBuilder.RenameColumn(
                name: "GenreId",
                table: "GenreMovieInfo",
                newName: "GenresId");

            migrationBuilder.RenameColumn(
                name: "CountryId",
                table: "CountryMovieInfo",
                newName: "CountriesId");

            migrationBuilder.AlterColumn<int>(
                name: "FeesId",
                table: "Movies",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_GenreMovieInfo",
                table: "GenreMovieInfo",
                columns: new[] { "GenresId", "MovieInfoId" });

            migrationBuilder.CreateTable(
                name: "MovieInfoSeasonsInfo",
                columns: table => new
                {
                    MovieInfoId = table.Column<int>(type: "int", nullable: false),
                    SeasonsInfoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieInfoSeasonsInfo", x => new { x.MovieInfoId, x.SeasonsInfoId });
                    table.ForeignKey(
                        name: "FK_MovieInfoSeasonsInfo_Movies_MovieInfoId",
                        column: x => x.MovieInfoId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MovieInfoSeasonsInfo_SeasonsInfo_SeasonsInfoId",
                        column: x => x.SeasonsInfoId,
                        principalTable: "SeasonsInfo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GenreMovieInfo_MovieInfoId",
                table: "GenreMovieInfo",
                column: "MovieInfoId");

            migrationBuilder.AddCheckConstraint(
                name: "CK_CurrencyValue_Value",
                table: "CurrencyValue",
                sql: "Value > 0");

            migrationBuilder.CreateIndex(
                name: "IX_MovieInfoSeasonsInfo_SeasonsInfoId",
                table: "MovieInfoSeasonsInfo",
                column: "SeasonsInfoId");

            migrationBuilder.AddForeignKey(
                name: "FK_CountryMovieInfo_Country_CountriesId",
                table: "CountryMovieInfo",
                column: "CountriesId",
                principalTable: "Country",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GenreMovieInfo_Genre_GenresId",
                table: "GenreMovieInfo",
                column: "GenresId",
                principalTable: "Genre",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Movies_Fees_FeesId",
                table: "Movies",
                column: "FeesId",
                principalTable: "Fees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
