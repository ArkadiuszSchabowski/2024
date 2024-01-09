using _088.Milionaires8.Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace _088.Milionaires8.Database
{
    public class MyDbContext : DbContext
    {
        public DbSet<Score> Scores { get; set; }
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {

        }
    }
}
