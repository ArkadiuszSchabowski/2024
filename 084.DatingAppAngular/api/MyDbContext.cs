using api.Entities;
using Microsoft.EntityFrameworkCore;

namespace api
{
    public class MyDbContext : DbContext
    {
        public DbSet<AppUser> Users { get; set; }
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {
            
        }
    }
}
