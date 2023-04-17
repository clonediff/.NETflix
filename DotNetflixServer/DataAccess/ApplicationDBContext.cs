using System.Text.Json;
using DataAccess.Entities.BusinessLogic;
using DataAccess.Entities.IdentityLogic;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DataAccess
{
	public class ApplicationDBContext : IdentityDbContext<User>
	{
		public DbSet<Country> Countries { get; set; }
		public DbSet<CountryMovieInfo> CountryMovieInfo { get; set; }
		public DbSet<CurrencyValue> CurrencyValues { get; set; }
		public DbSet<Fees> Fees { get; set; }
		public DbSet<Genre> Genres { get; set; }
		public DbSet<GenreMovieInfo> GenreMovieInfo { get; set; }
		public DbSet<Profession> Professions { get; set; }
		public DbSet<Person> Persons { get; set; }
		public DbSet<PersonProffessionInMovie> PersonProffessionInMovie { get; set; }
		public DbSet<SeasonsInfo> SeasonsInfos { get; set; }
		public DbSet<Types> Types { get; set; }
		public DbSet<MovieInfo> Movies { get; set; }
		public DbSet<User> Users { get; set; }
		public DbSet<Category> Categories { get; set; }

		public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options)
			: base(options)
		{
		}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.EnableSensitiveDataLogging();
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
			// Integer check constraints
			modelBuilder.Entity<CurrencyValue>()
				.ToTable(t =>
					t.HasCheckConstraint($"CK_{nameof(CurrencyValue)}_{nameof(CurrencyValue.Value)}",
						$"{nameof(CurrencyValue.Value)} >= 0"));
			modelBuilder.Entity<SeasonsInfo>()
				.ToTable(t =>
				{
					t.HasCheckConstraint($"CK_{nameof(SeasonsInfo)}_{nameof(SeasonsInfo.Number)}",
						$"{nameof(SeasonsInfo.Number)} >= 0");
					t.HasCheckConstraint($"CK_{nameof(SeasonsInfo)}_{nameof(SeasonsInfo.EpisodesCount)}",
						$"{nameof(SeasonsInfo.EpisodesCount)} >= 0");
				});
			modelBuilder.Entity<MovieInfo>()
				.ToTable(t =>
				{
					t.HasCheckConstraint($"CK_{nameof(MovieInfo)}_{nameof(MovieInfo.Year)}",
						$"{nameof(MovieInfo.Year)} >= 1900");
					t.HasCheckConstraint($"CK_{nameof(MovieInfo)}_{nameof(MovieInfo.Rating)}",
						$"0 <= {nameof(MovieInfo.Rating)} AND {nameof(MovieInfo.Rating)} <= 10");
					t.HasCheckConstraint($"CK_{nameof(MovieInfo)}_{nameof(MovieInfo.MovieLength)}",
						$"{nameof(MovieInfo.MovieLength)} > 0");
				});
			// Many to many
			modelBuilder.Entity<MovieInfo>()
				.HasMany(m => m.Countries);
			modelBuilder.Entity<Country>()
				.HasMany(c => c.Movies);
			modelBuilder.Entity<CountryMovieInfo>()
				.HasKey(x => new { x.CountryId, x.MovieInfoId });

			modelBuilder.Entity<MovieInfo>()
				.HasMany(m => m.Genres);
			modelBuilder.Entity<Genre>()
				.HasMany(g => g.Movies);
			modelBuilder.Entity<GenreMovieInfo>()
				.HasKey(x => new { x.MovieInfoId, x.GenreId });

			modelBuilder.Entity<MovieInfo>()
				.HasMany(m => m.SeasonsInfo);
			modelBuilder.Entity<SeasonsInfo>()
				.HasOne(s => s.MovieInfo);

			modelBuilder.Entity<MovieInfo>()
				.HasMany(m => m.Proffessions);
			modelBuilder.Entity<Person>()
				.HasMany(p => p.Proffessions);
			modelBuilder.Entity<PersonProffessionInMovie>()
				.HasKey(p => new { p.MovieInfoId, p.PersonId, p.ProfessionId });

			// Data
			var categories = GetData<Category>();
			modelBuilder.Entity<Category>()
				.HasData(categories);

			var countries = GetData<Country>();
			modelBuilder.Entity<Country>()
				.HasData(countries);

			var genre = GetData<Genre>();
			modelBuilder.Entity<Genre>()
				.HasData(genre);

			var type = GetData<Types>();
			modelBuilder.Entity<Types>()
				.HasData(type);

			var professions = GetData<Profession>();
			modelBuilder.Entity<Profession>()
				.HasData(professions);

			var currencyValues = GetData<CurrencyValue>();
			modelBuilder.Entity<CurrencyValue>()
				.HasData(currencyValues);

			var fees = GetData<Fees>();
			modelBuilder.Entity<Fees>()
				.HasData(fees);

			var person = GetData<Person>();
			modelBuilder.Entity<Person>()
				.HasData(person);

			var movies = GetData<MovieInfo>();
			modelBuilder.Entity<MovieInfo>()
				.HasData(movies);

			var countryMovie = GetData<CountryMovieInfo>();
			modelBuilder.Entity<CountryMovieInfo>()
				.HasData(countryMovie);

			var genreMovie = GetData<GenreMovieInfo>();
			modelBuilder.Entity<GenreMovieInfo>()
				.HasData(genreMovie);

			var personProf = GetData<PersonProffessionInMovie>();
			modelBuilder.Entity<PersonProffessionInMovie>()
				.HasData(personProf);

			var seasons = GetData<SeasonsInfo>();
			modelBuilder.Entity<SeasonsInfo>()
				.HasData(seasons);
		}

		T[]? GetData<T>()
		{
			var path = Path.Combine("../DataAccess/jsons", $"{typeof(T).Name}.txt");
			var text = File.ReadAllText(path);
            return JsonSerializer.Deserialize<T[]>(text);
		}
	}
}
