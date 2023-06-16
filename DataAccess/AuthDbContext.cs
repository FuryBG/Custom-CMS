using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.DataAccess
{
    public class AuthDbContext : DbContext
    {
        public AuthDbContext(DbContextOptions<AuthDbContext> options): base(options)
        { }

        public AuthDbContext() { }

        public DbSet<User> Users { get; set; }
        public DbSet<DataContent> DataContent { get; set; }
        public DbSet<DatatoData> DatatoData { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
            .Entity<DatatoData>
            (
                eb =>
                {
                    eb.HasNoKey();
                }
            );
        }

    }
}
