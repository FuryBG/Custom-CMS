using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.DataAccess
{
    public class CmsDbContext : DbContext
    {
        public CmsDbContext(DbContextOptions<CmsDbContext> options): base(options)
        { }

        public CmsDbContext() { }

        public DbSet<User> Users { get; set; }
        public DbSet<DataContent> DataContent { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }

    }
}
