using DutchTreat.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace GymBuddy.Data.Entities
{
    public class GymBuddyContext : DbContext
    {
        public GymBuddyContext(DbContextOptions<GymBuddyContext> options): base(options)
        {
        }

        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<Order> Orders { get; set; }
    }
}

