using _085.RelationsDatabase.Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace _085.RelationsDatabase.Database
{
    public class MyDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<AllegroUser> AllegroUsers { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasOne(u => u.Adress)
                .WithOne(a => a.User)
                .HasForeignKey<Address>(a => a.UserId);

            modelBuilder.Entity<User>().HasData(new User
            {
                Id = 1,
                Name = "Arek",
                Email = "abc@o2.pl",
                Phone = "700-600-500"
            }, new User
            {
                Id = 2,
                Name = "Damian",
                Email = "cdf@o2.pl",
                Phone = "100-600-100"
            });
            modelBuilder.Entity<Address>().HasData(new Address
            {
                Id = 1,
                Street = "Nowa",
                City = "Kraków",
                Country = "Polska",
                UserId = 1
            },
            new Address
            {
                Id = 2,
                Street = "Stara",
                City = "Poznań",
                Country = "Polska",
                UserId = 2
            });
            modelBuilder.Entity<AllegroUser>()
                .HasMany(a => a.Comments)
                .WithOne(c => c.User)
                .HasForeignKey(c => c.UserId);
        }
    }
}
