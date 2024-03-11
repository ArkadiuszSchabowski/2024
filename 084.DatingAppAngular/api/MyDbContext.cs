using api.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace api
{
    public class MyDbContext : DbContext
    {
        public DbSet<AppUser> Users { get; set; }
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AppUser>().HasData(
                new AppUser
                {
                    Id = 1,
                    UserName = "Świnka"
                },
                new AppUser
                {
                    Id = 2,
                    UserName = "Owca"
                },
                new AppUser
                {
                    Id = 3,
                    UserName = "Krowa"
                });
        }
    }
}
