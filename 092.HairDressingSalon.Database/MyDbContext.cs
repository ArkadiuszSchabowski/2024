using Microsoft.EntityFrameworkCore;

namespace _092.HairDressingSalon.Database
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {

        }
    }
}