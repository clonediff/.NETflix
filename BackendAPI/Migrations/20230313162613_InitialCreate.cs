using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BackendAPI.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Country",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Slug = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Country", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CurrencyValue",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<long>(type: "bigint", nullable: false),
                    Currency = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CurrencyValue", x => x.Id);
                    table.CheckConstraint("CK_CurrencyValue_Value", "Value > 0");
                });

            migrationBuilder.CreateTable(
                name: "Genre",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Slug = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genre", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Person",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Photo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Person", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SeasonsInfo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Number = table.Column<int>(type: "int", nullable: false),
                    EpisodesCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SeasonsInfo", x => x.Id);
                    table.CheckConstraint("CK_SeasonsInfo_EpisodesCount", "EpisodesCount >= 0");
                    table.CheckConstraint("CK_SeasonsInfo_Number", "Number > 0");
                });

            migrationBuilder.CreateTable(
                name: "Types",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Slug = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Types", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Fees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WorldId = table.Column<int>(type: "int", nullable: true),
                    RussiaId = table.Column<int>(type: "int", nullable: true),
                    USAId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Fees_CurrencyValue_RussiaId",
                        column: x => x.RussiaId,
                        principalTable: "CurrencyValue",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Fees_CurrencyValue_USAId",
                        column: x => x.USAId,
                        principalTable: "CurrencyValue",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Fees_CurrencyValue_WorldId",
                        column: x => x.WorldId,
                        principalTable: "CurrencyValue",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ShortDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Slogan = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Rating = table.Column<double>(type: "float", nullable: true),
                    MovieLength = table.Column<int>(type: "int", nullable: false),
                    AgeRating = table.Column<int>(type: "int", nullable: true),
                    PosterURL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TypeId = table.Column<int>(type: "int", nullable: false),
                    BudgetId = table.Column<int>(type: "int", nullable: true),
                    FeesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.Id);
                    table.CheckConstraint("CK_MovieInfo_MovieLength", "MovieLength > 0");
                    table.CheckConstraint("CK_MovieInfo_Rating", "0 <= Rating AND Rating <= 10");
                    table.CheckConstraint("CK_MovieInfo_Year", "Year >= 1900");
                    table.ForeignKey(
                        name: "FK_Movies_CurrencyValue_BudgetId",
                        column: x => x.BudgetId,
                        principalTable: "CurrencyValue",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Movies_Fees_FeesId",
                        column: x => x.FeesId,
                        principalTable: "Fees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Movies_Types_TypeId",
                        column: x => x.TypeId,
                        principalTable: "Types",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CountryMovieInfo",
                columns: table => new
                {
                    CountriesId = table.Column<int>(type: "int", nullable: false),
                    MovieInfoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CountryMovieInfo", x => new { x.CountriesId, x.MovieInfoId });
                    table.ForeignKey(
                        name: "FK_CountryMovieInfo_Country_CountriesId",
                        column: x => x.CountriesId,
                        principalTable: "Country",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CountryMovieInfo_Movies_MovieInfoId",
                        column: x => x.MovieInfoId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GenreMovieInfo",
                columns: table => new
                {
                    GenresId = table.Column<int>(type: "int", nullable: false),
                    MovieInfoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GenreMovieInfo", x => new { x.GenresId, x.MovieInfoId });
                    table.ForeignKey(
                        name: "FK_GenreMovieInfo_Genre_GenresId",
                        column: x => x.GenresId,
                        principalTable: "Genre",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GenreMovieInfo_Movies_MovieInfoId",
                        column: x => x.MovieInfoId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateTable(
                name: "PersonProffessionInMovie",
                columns: table => new
                {
                    PersonId = table.Column<int>(type: "int", nullable: false),
                    MovieInfoId = table.Column<int>(type: "int", nullable: false),
                    Proffession = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonProffessionInMovie", x => new { x.MovieInfoId, x.PersonId, x.Proffession });
                    table.ForeignKey(
                        name: "FK_PersonProffessionInMovie_Movies_MovieInfoId",
                        column: x => x.MovieInfoId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PersonProffessionInMovie_Person_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CountryMovieInfo_MovieInfoId",
                table: "CountryMovieInfo",
                column: "MovieInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_Fees_RussiaId",
                table: "Fees",
                column: "RussiaId");

            migrationBuilder.CreateIndex(
                name: "IX_Fees_USAId",
                table: "Fees",
                column: "USAId");

            migrationBuilder.CreateIndex(
                name: "IX_Fees_WorldId",
                table: "Fees",
                column: "WorldId");

            migrationBuilder.CreateIndex(
                name: "IX_GenreMovieInfo_MovieInfoId",
                table: "GenreMovieInfo",
                column: "MovieInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_MovieInfoSeasonsInfo_SeasonsInfoId",
                table: "MovieInfoSeasonsInfo",
                column: "SeasonsInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_Movies_BudgetId",
                table: "Movies",
                column: "BudgetId");

            migrationBuilder.CreateIndex(
                name: "IX_Movies_FeesId",
                table: "Movies",
                column: "FeesId");

            migrationBuilder.CreateIndex(
                name: "IX_Movies_TypeId",
                table: "Movies",
                column: "TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonProffessionInMovie_PersonId",
                table: "PersonProffessionInMovie",
                column: "PersonId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CountryMovieInfo");

            migrationBuilder.DropTable(
                name: "GenreMovieInfo");

            migrationBuilder.DropTable(
                name: "MovieInfoSeasonsInfo");

            migrationBuilder.DropTable(
                name: "PersonProffessionInMovie");

            migrationBuilder.DropTable(
                name: "Country");

            migrationBuilder.DropTable(
                name: "Genre");

            migrationBuilder.DropTable(
                name: "SeasonsInfo");

            migrationBuilder.DropTable(
                name: "Movies");

            migrationBuilder.DropTable(
                name: "Person");

            migrationBuilder.DropTable(
                name: "Fees");

            migrationBuilder.DropTable(
                name: "Types");

            migrationBuilder.DropTable(
                name: "CurrencyValue");
        }
    }
}
