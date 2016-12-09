﻿using Ldme.Models.Models;
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

        //TODO: Double foreign keys are generated
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Quest>()
                .HasOne(q => q.QuestCreator)
                .WithMany(p => p.QuestsCreated)
                .HasForeignKey(p => p.QuestCreatorId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Quest>()
                .HasOne(q => q.QuestOwner)
                .WithMany(p => p.QuestsOwned)
                .HasForeignKey(p => p.QuestOwnerId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<FriendRequest>()
                .HasOne(q => q.RequestedBy)
                .WithMany()
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<FriendRequest>()
                .HasOne(q => q.RequestTarget)
                .WithMany()
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Repetition>()
                .HasOne(q => q.ReferencedQuest)
                .WithMany()
                .HasForeignKey(k => k.ReferencedQuestId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Repetition>()
                .HasOne(q => q.TagingPlayer)
                .WithMany()
                .HasForeignKey(k => k.TagingPlayerId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Reward>()
                .HasOne(q => q.RewardCreator)
                .WithMany()
                .HasForeignKey(k => k.RewardCreatorId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
