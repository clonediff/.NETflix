using System.Text.Json;
using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DataAccess
{
	public class ApplicationDBContext : IdentityDbContext<User>
	{
		public DbSet<Country> Countries { get; set; } = null!;
		public DbSet<CountryMovieInfo> CountryMovieInfo { get; set; } = null!;
		public DbSet<CurrencyValue> CurrencyValues { get; set; } = null!;
		public DbSet<Fees> Fees { get; set; } = null!;
		public DbSet<Genre> Genres { get; set; } = null!;
		public DbSet<GenreMovieInfo> GenreMovieInfo { get; set; } = null!;
		public DbSet<Profession> Professions { get; set; } = null!;
		public DbSet<Person> Persons { get; set; } = null!;
		public DbSet<PersonProffessionInMovie> PersonProffessionInMovie { get; set; } = null!;
		public DbSet<SeasonsInfo> SeasonsInfos { get; set; } = null!;
		public DbSet<Types> Types { get; set; } = null!;
		public DbSet<MovieInfo> Movies { get; set; } = null!;
		public DbSet<Category> Categories { get; set; } = null!; 
		public DbSet<Subscription> Subscriptions { get; set; } = null!;
		public DbSet<UserSubscription> UserSubscriptions { get; set; } = null!;
		public DbSet<SubscriptionMovieInfo> SubscriptionMovies { get; set; } = null!;
		public DbSet<Message> Messages { get; set; } = default!;

		public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options)
			: base(options)
		{
		}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.EnableSensitiveDataLogging();
		}

		protected override void OnModelCreating(ModelBuilder builder)
		{
			base.OnModelCreating(builder);
			// Integer check constraints
			builder.Entity<CurrencyValue>()
				.ToTable(t =>
					t.HasCheckConstraint($"CK_{nameof(CurrencyValue)}_{nameof(CurrencyValue.Value)}",
						$"{nameof(CurrencyValue.Value)} >= 0"));
			builder.Entity<SeasonsInfo>()
				.ToTable(t =>
				{
					t.HasCheckConstraint($"CK_{nameof(SeasonsInfo)}_{nameof(SeasonsInfo.Number)}",
						$"{nameof(SeasonsInfo.Number)} >= 0");
					t.HasCheckConstraint($"CK_{nameof(SeasonsInfo)}_{nameof(SeasonsInfo.EpisodesCount)}",
						$"{nameof(SeasonsInfo.EpisodesCount)} >= 0");
				});
			builder.Entity<MovieInfo>()
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
			builder.Entity<MovieInfo>()
				.HasMany(m => m.Countries);
			builder.Entity<Country>()
				.HasMany(c => c.Movies);
			builder.Entity<CountryMovieInfo>()
				.HasKey(x => new { x.CountryId, x.MovieInfoId });

			builder.Entity<MovieInfo>()
				.HasMany(m => m.Genres);
			builder.Entity<Genre>()
				.HasMany(g => g.Movies);
			builder.Entity<GenreMovieInfo>()
				.HasKey(x => new { x.MovieInfoId, x.GenreId });

			builder.Entity<MovieInfo>()
				.HasMany(m => m.SeasonsInfo);
			builder.Entity<SeasonsInfo>()
				.HasOne(s => s.MovieInfo);

			builder.Entity<MovieInfo>()
				.HasMany(m => m.Proffessions);
			builder.Entity<Person>()
				.HasMany(p => p.Proffessions);
			builder.Entity<PersonProffessionInMovie>()
				.HasKey(p => new { p.MovieInfoId, p.PersonId, p.ProfessionId });

			builder.Entity<MovieInfo>()
				.HasMany(m => m.Subscriptions)
				.WithMany(s => s.Movies)
				.UsingEntity<SubscriptionMovieInfo>();
			builder.Entity<User>()
				.HasMany(u => u.Subscriptions)
				.WithMany(s => s.Users)
				.UsingEntity<UserSubscription>();

			builder.Entity<User>()
				.HasMany(u => u.Messages);
			builder.Entity<Message>()
				.HasOne(m => m.User);

			// Data
			var categories = GetData<Category>();
			builder.Entity<Category>()
				.HasData(categories!);

			var countries = GetData<Country>();
			builder.Entity<Country>()
				.HasData(countries!);

			var genre = GetData<Genre>();
			builder.Entity<Genre>()
				.HasData(genre!);

			var type = GetData<Types>();
			builder.Entity<Types>()
				.HasData(type!);

			var professions = GetData<Profession>();
			builder.Entity<Profession>()
				.HasData(professions!);

			var currencyValues = GetData<CurrencyValue>();
			builder.Entity<CurrencyValue>()
				.HasData(currencyValues!);

			var fees = GetData<Fees>();
			builder.Entity<Fees>()
				.HasData(fees!);

			var person = GetData<Person>();
			builder.Entity<Person>()
				.HasData(person!);

			var movies = GetData<MovieInfo>();
			builder.Entity<MovieInfo>()
				.HasData(movies!);

			var countryMovie = GetData<CountryMovieInfo>();
			builder.Entity<CountryMovieInfo>()
				.HasData(countryMovie!);

			var genreMovie = GetData<GenreMovieInfo>();
			builder.Entity<GenreMovieInfo>()
				.HasData(genreMovie!);

			var personProf = GetData<PersonProffessionInMovie>();
			builder.Entity<PersonProffessionInMovie>()
				.HasData(personProf!);

			var seasons = GetData<SeasonsInfo>();
			builder.Entity<SeasonsInfo>()
				.HasData(seasons!);

			var subscriptions = GetData<Subscription>();
			builder.Entity<Subscription>()
				.HasData(subscriptions!);
			
			var subscriptionMovies = GetData<SubscriptionMovieInfo>();
			builder.Entity<SubscriptionMovieInfo>()
				.HasData(subscriptionMovies!);

            builder.Entity<IdentityRole>()
                .HasData(new IdentityRole
                {
	                Id = "1",
	                Name = "user",
	                NormalizedName = "USER"
                }, new IdentityRole
                {
	                Id = "2",
	                Name = "manager",
	                NormalizedName = "MANAGER"
                }, new IdentityRole
                {
	                Id = "3",
	                Name = "admin",
	                NormalizedName = "ADMIN"
                });
		}

		static T[]? GetData<T>()
		{
			var path = Path.Combine("../Domain/jsons", $"{typeof(T).Name}.txt");
			var text = File.ReadAllText(path);
            return JsonSerializer.Deserialize<T[]>(text);
		}
	}
}
