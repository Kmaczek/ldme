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

        public DbSet<FriendRequest> FriendRequests { get; set; }

        public DbSet<Repetition> Repetitions { get; set; }

        public DbSet<Reward> Rewards { get; set; }

        public DbSet<RewardClaim> RewardClaims { get; set; }

        //TODO: Double foreign keys are generated
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Quest>()
                .HasOne(q => q.QuestCreator)
                .WithMany(p => p.QuestsCreated)
                .HasForeignKey(q => q.QuestCreatorId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Quest>()
                .HasOne(q => q.QuestOwner)
                .WithMany(p => p.QuestsOwned)
                .HasForeignKey(q => q.QuestOwnerId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<FriendRequest>()
                .HasOne(fr => fr.RequestedBy)
                .WithMany()
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<FriendRequest>()
                .HasOne(fr => fr.RequestTarget)
                .WithMany()
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Repetition>()
                .HasOne(r => r.ReferencedQuest)
                .WithMany(q => q.RepetitionTags)
                .HasForeignKey(r => r.ReferencedQuestId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Repetition>()
                .HasOne(r => r.TagingPlayer)
                .WithMany(p => p.RepetitionTags)
                .HasForeignKey(r => r.TagingPlayerId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Reward>()
                .HasOne(r => r.RewardCreator)
                .WithMany(p => p.RewardsCreated)
                .HasForeignKey(r => r.RewardCreatorId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
