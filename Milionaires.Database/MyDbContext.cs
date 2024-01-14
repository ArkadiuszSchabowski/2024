using Microsoft.EntityFrameworkCore;
using Milionaires.Database.Entities;

namespace Milionaires.Database
{
    public class MyDbContext : DbContext
    {
        public DbSet<Score> Scores { get; set; }
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Score>().HasData(new Score
            {
                Id = 1,
                Name = "Ania",
                Result = 500,
                Date = new DateTime(2023, 1, 7)
            },
            new Score
            {
                Id = 2,
                Name = "Maciek",
                Result = 2000,
                Date = new DateTime(2023, 1, 9)
            },
            new Score
            {
                Id = 3,
                Name = "Lena",
                Result = 10000,
                Date = new DateTime(2023, 1, 8)
            });
        }
    }
}
