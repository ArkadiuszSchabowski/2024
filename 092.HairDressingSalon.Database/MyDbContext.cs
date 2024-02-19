using _092.HairDressingSalon.Database.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace _092.HairDressingSalon.Database
{
    public class MyDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
                modelBuilder.Entity<Role>().HasData(
                    new Role { Id = 1, Name = "User" },
                    new Role { Id = 2, Name = "Manager" },
                    new Role { Id = 3, Name = "Admin" }
                );
        }
    }
}
