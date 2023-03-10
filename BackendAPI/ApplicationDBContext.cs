using DBModels;
using Microsoft.EntityFrameworkCore;

namespace BackendAPI
{
	public class ApplicationDBContext : DbContext
	{
		public DbSet<MovieInfo> Movies { get; set; }
 
		public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options)
			: base(options)
		{
			Database.EnsureCreated();
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
			// Integer check constraints
			modelBuilder.Entity<CurrencyValue>()
				.ToTable(t =>
					t.HasCheckConstraint($"CK_{nameof(CurrencyValue)}_{nameof(CurrencyValue.Value)}", 
						$"{nameof(CurrencyValue.Value)} > 0"));
			modelBuilder.Entity<SeasonsInfo>()
				.ToTable(t =>
				{
					t.HasCheckConstraint($"CK_{nameof(SeasonsInfo)}_{nameof(SeasonsInfo.Number)}", 
						$"{nameof(SeasonsInfo.Number)} > 0");
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
				.HasMany(m => m.Countries)
				.WithMany();
			modelBuilder.Entity<MovieInfo>()
				.HasMany(m => m.Genres)
				.WithMany();
			modelBuilder.Entity<MovieInfo>()
				.HasMany(m => m.SeasonsInfo)
				.WithMany();
			modelBuilder.Entity<MovieInfo>()
				.HasMany(m => m.Proffessions);
			modelBuilder.Entity<Person>()
				.HasMany(p => p.Proffessions);
			modelBuilder.Entity<PersonProffessionInMovie>()
				.HasKey(p => new { p.MovieId, p.PersonId });
		}
	}
}
