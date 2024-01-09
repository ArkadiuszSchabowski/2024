using Microsoft.EntityFrameworkCore;
using MigrationTest.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MigrationTest.Database
{
    public class MyDbContext : DbContext
    {
        public DbSet<Test> Tests { get; set; }
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            if (Database.IsInMemory())
            {
                // Ignoruj migracje dla bazy danych w pamięci
                base.OnModelCreating(modelBuilder);
            }
        }
    }
}
