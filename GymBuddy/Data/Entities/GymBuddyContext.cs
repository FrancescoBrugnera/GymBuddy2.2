using GymBuddy.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace GymBuddy.Data.Entities
{
    public class GymBuddyContext : DbContext
    {
        public GymBuddyContext(DbContextOptions<GymBuddyContext> options): base(options)
        {
        }

        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<Order> Orders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Order>()
                .HasData(new Order()
                {
                    Id = 1,
                    OrderDate = DateTime.UtcNow,
                    OrderNumber = "12345"
                });
        }
    }
}

