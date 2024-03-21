using api.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace api
{
    public class MyDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 1,
                    Name = "Świnka"
                },
                new User
                {
                    Id = 2,
                    Name = "Owca"
                },
                new User
                {
                    Id = 3,
                    Name = "Krowa"
                });
        }
    }
}
