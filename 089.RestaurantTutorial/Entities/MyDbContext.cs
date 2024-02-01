﻿using Microsoft.EntityFrameworkCore;
using System.Net;

namespace _089.RestaurantTutorial.Entities
{
    public class MyDbContext : DbContext
    {

        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<Address> Adresses { get; set; }
        public DbSet<Dish> Dishes { get; set; }

        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Restaurant>()
                .HasOne(r => r.Address)
                .WithOne(a => a.Restaurant)
                .HasForeignKey<Restaurant>(r => r.AddressId);

            modelBuilder.Entity<Restaurant>().Property(r => r.Name).IsRequired().HasMaxLength(25);
            modelBuilder.Entity<Dish>().Property(d => d.Name).IsRequired().HasMaxLength(50);
        }
    }
}
