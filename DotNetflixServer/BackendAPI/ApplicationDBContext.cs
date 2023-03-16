using DBModels.BusinessLogic;
using DBModels.IdentityLogic;
using Microsoft.EntityFrameworkCore;

namespace BackendAPI
{
	public class ApplicationDBContext : DbContext
	{
		public DbSet<MovieInfo> Movies { get; set; }        
		public DbSet<User> Users { get; set; }
		public DbSet<Role> Roles { get; set; }
 
		public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options)
			: base(options)
		{
		}
	}
}
