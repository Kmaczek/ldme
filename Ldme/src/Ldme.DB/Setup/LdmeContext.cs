using Ldme.Models.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
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
            modelBuilder.Entity<Quest>()
                .HasOne(q => q.QuestGiver)
                .WithMany(p => p.QuestsCreated)
                .HasForeignKey(p => p.QuestGiverId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Quest>()
                .HasOne(q => q.QuestRevceiver)
                .WithMany(p => p.QuestsOwned)
                .HasForeignKey(p => p.QuestRevceiverId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Activity>();
        }
    }
}
