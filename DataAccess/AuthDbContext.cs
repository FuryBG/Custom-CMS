using Microsoft.EntityFrameworkCore;

namespace WebApplication1.DataAccess
{
    public class AuthDbContext : DbContext
    {
        public AuthDbContext(DbContextOptions<AuthDbContext> options): base(options)
        { }

        public AuthDbContext() { }

        public DbSet<User> Users { get; set; }
        public DbSet<DataContent> DataContent { get; set; }

    }
}
