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
