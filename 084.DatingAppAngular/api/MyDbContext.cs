using api.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace api
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
            modelBuilder.Entity<Role>().HasData(new Role
            {
                Id = 1,
                Name = "User"
            },
            new Role
            {
                Id = 2,
                Name = "Manager"
            },
            new Role
            {
                Id = 3,
                Name = "Admin"

            });

            modelBuilder.Entity<User>()
                .HasOne(u => u.Role)
                .WithMany(r => r.Users)
                .HasForeignKey(u => u.RoleId);


            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 1,
                    Name = "Świnka",
                    RoleId = 1
                },
                new User
                {
                    Id = 2,
                    Name = "Owca",
                    RoleId = 1
                },
                new User
                {
                    Id = 3,
                    Name = "Krowa",
                    RoleId = 1
                });
        }
    }
}
