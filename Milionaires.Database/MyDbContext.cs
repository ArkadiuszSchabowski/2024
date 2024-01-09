using Microsoft.EntityFrameworkCore;

namespace Milionaires.Database
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {
                
        }
    }
}
