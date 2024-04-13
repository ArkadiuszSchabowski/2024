using Microsoft.EntityFrameworkCore;
using WordMaster.ServerDatabase.Entities;

namespace WordMaster.ServerDatabase
{
    public class MyDbContext : DbContext
    {
        public DbSet<FlashCard> FlashCards { get; set; }
        public DbSet<User> Users { get; set; }
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {
            
        }
    }
}
