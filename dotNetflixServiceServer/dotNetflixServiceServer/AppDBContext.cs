using Microsoft.EntityFrameworkCore;
using dotNetflixServiceServer.DBModels;

namespace dotNetflixServiceServer
{
    public class AppDBContext : DbContext
    {
        public AppDBContext()
        {

        }

        public AppDBContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<User?> Users { get; set; }
        public DbSet<Role?> Roles { get; set; }
    }
}
