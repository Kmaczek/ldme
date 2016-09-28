using Ldme.Models.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Ldme.DB.Setup
{
    public class LdmeContext : IdentityDbContext<LdmeUser>
    {
        public LdmeContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Player> Players { get; set; }
        public DbSet<Quest> Quests { get; set; }
        public DbSet<Activity> Activities { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Player>();
            modelBuilder.Entity<Quest>();
            modelBuilder.Entity<Activity>();
        }
    }
}
