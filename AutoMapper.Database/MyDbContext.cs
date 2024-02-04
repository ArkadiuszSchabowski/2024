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
    }
}
