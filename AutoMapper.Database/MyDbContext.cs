using AutoMapper.Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace AutoMapper.Database
{
    public class MyDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {
                
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(new User
            {
                Id = 1,
                Name = "Świnka",
                City = "Chorzów",
                Phone = "7806969",
                isAdmin = true,
                isPremiumAccount = true
            },
            new User
            {
                Id = 2,
                Name = "Paulina",
                City = "Chorzów",
                Phone = "500100200",
                isAdmin = false,
                isPremiumAccount = true
            },
            new User
            {
                Id = 3,
                Name = "Dominika",
                City = "Chorzów",
                Phone = "600200300",
                isAdmin = false,
                isPremiumAccount = true
            });
        }
    }
}
