using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Ldme.DB.Setup;

namespace Ldme.DB.Migrations
{
    [DbContext(typeof(LdmeContext))]
    partial class LdmeContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.1")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Ldme.Models.Models.Activity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ActivityCreatorId");

                    b.Property<DateTime>("CompletionDate");

                    b.Property<DateTime>("CreationDate");

                    b.Property<string>("Description");

                    b.Property<int>("ReferencedQuestId");

                    b.HasKey("Id");

                    b.HasIndex("ActivityCreatorId");

                    b.HasIndex("ReferencedQuestId");

                    b.ToTable("Activities");
                });

            modelBuilder.Entity("Ldme.Models.Models.FriendRequest", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("RequestTargetId");

                    b.Property<int>("RequestedById");

                    b.Property<string>("Status");

                    b.HasKey("Id");

                    b.HasIndex("RequestTargetId");

                    b.HasIndex("RequestedById");

                    b.ToTable("FriendRequests");
                });

            modelBuilder.Entity("Ldme.Models.Models.LdmeUser", b =>
                {
                    b.Property<string>("Id");

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("NormalizedUserName")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<int>("PlayerId");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasAnnotation("MaxLength", 256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex");

                    b.HasIndex("PlayerId");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Ldme.Models.Models.Player", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<float>("Gold");

                    b.Property<float>("Honor");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Players");
                });

            modelBuilder.Entity("Ldme.Models.Models.Quest", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Accepted");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<DateTime?>("DeadlineDate");

                    b.Property<string>("Description");

                    b.Property<DateTime?>("FinishedDate");

                    b.Property<float>("GoldPenalty");

                    b.Property<float>("GoldReward");

                    b.Property<float>("HonorPenalty");

                    b.Property<float>("HonorReward");

                    b.Property<int>("MaxRepetitions");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<int>("QuestCreatorId");

                    b.Property<int>("QuestOwnerId");

                    b.Property<string>("QuestState");

                    b.Property<string>("QuestType");

                    b.Property<float>("RepetitionBonusMultiplier");

                    b.Property<string>("RepetitionBonusType");

                    b.Property<int>("RepetitionsForMaxBonus");

                    b.Property<int>("RequiredRepetitions");

                    b.HasKey("Id");

                    b.HasIndex("QuestCreatorId");

                    b.HasIndex("QuestOwnerId");

                    b.ToTable("Quests");
                });

            modelBuilder.Entity("Ldme.Models.Models.Repetition", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CompletionDate");

                    b.Property<float>("GoldGain");

                    b.Property<float>("HonorGain");

                    b.Property<int?>("PlayerId");

                    b.Property<int?>("QuestId");

                    b.Property<int>("ReferencedQuestId");

                    b.Property<int>("TagingPlayerId");

                    b.HasKey("Id");

                    b.HasIndex("PlayerId");

                    b.HasIndex("QuestId");

                    b.HasIndex("ReferencedQuestId");

                    b.HasIndex("TagingPlayerId");

                    b.ToTable("Repetitions");
                });

            modelBuilder.Entity("Ldme.Models.Models.Reward", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<int>("GoldPrice");

                    b.Property<int>("HonorPrice");

                    b.Property<int?>("PlayerId");

                    b.Property<int>("RewardCreatorId");

                    b.HasKey("Id");

                    b.HasIndex("PlayerId");

                    b.HasIndex("RewardCreatorId");

                    b.ToTable("Reward");
                });

            modelBuilder.Entity("Ldme.Models.Models.RewardClaim", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("ClaimDate");

                    b.Property<int>("ClaimedById");

                    b.HasKey("Id");

                    b.HasIndex("ClaimedById");

                    b.ToTable("RewardClaim");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole", b =>
                {
                    b.Property<string>("Id");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("NormalizedName")
                        .HasAnnotation("MaxLength", 256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .HasName("RoleNameIndex");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("Ldme.Models.Models.Activity", b =>
                {
                    b.HasOne("Ldme.Models.Models.Player", "ActivityCreator")
                        .WithMany()
                        .HasForeignKey("ActivityCreatorId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Ldme.Models.Models.Quest", "ReferencedQuest")
                        .WithMany()
                        .HasForeignKey("ReferencedQuestId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Ldme.Models.Models.FriendRequest", b =>
                {
                    b.HasOne("Ldme.Models.Models.Player", "RequestTarget")
                        .WithMany()
                        .HasForeignKey("RequestTargetId");

                    b.HasOne("Ldme.Models.Models.Player", "RequestedBy")
                        .WithMany()
                        .HasForeignKey("RequestedById");
                });

            modelBuilder.Entity("Ldme.Models.Models.LdmeUser", b =>
                {
                    b.HasOne("Ldme.Models.Models.Player", "Player")
                        .WithMany()
                        .HasForeignKey("PlayerId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Ldme.Models.Models.Quest", b =>
                {
                    b.HasOne("Ldme.Models.Models.Player", "QuestCreator")
                        .WithMany("QuestsCreated")
                        .HasForeignKey("QuestCreatorId");

                    b.HasOne("Ldme.Models.Models.Player", "QuestOwner")
                        .WithMany("QuestsOwned")
                        .HasForeignKey("QuestOwnerId");
                });

            modelBuilder.Entity("Ldme.Models.Models.Repetition", b =>
                {
                    b.HasOne("Ldme.Models.Models.Player")
                        .WithMany("RepetitionTags")
                        .HasForeignKey("PlayerId");

                    b.HasOne("Ldme.Models.Models.Quest")
                        .WithMany("RepetitionTags")
                        .HasForeignKey("QuestId");

                    b.HasOne("Ldme.Models.Models.Quest", "ReferencedQuest")
                        .WithMany()
                        .HasForeignKey("ReferencedQuestId");

                    b.HasOne("Ldme.Models.Models.Player", "TagingPlayer")
                        .WithMany()
                        .HasForeignKey("TagingPlayerId");
                });

            modelBuilder.Entity("Ldme.Models.Models.Reward", b =>
                {
                    b.HasOne("Ldme.Models.Models.Player")
                        .WithMany("RewardsCreated")
                        .HasForeignKey("PlayerId");

                    b.HasOne("Ldme.Models.Models.Player", "RewardCreator")
                        .WithMany()
                        .HasForeignKey("RewardCreatorId");
                });

            modelBuilder.Entity("Ldme.Models.Models.RewardClaim", b =>
                {
                    b.HasOne("Ldme.Models.Models.Player", "ClaimedBy")
                        .WithMany("RewardsClaimed")
                        .HasForeignKey("ClaimedById")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole")
                        .WithMany("Claims")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Ldme.Models.Models.LdmeUser")
                        .WithMany("Claims")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Ldme.Models.Models.LdmeUser")
                        .WithMany("Logins")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Ldme.Models.Models.LdmeUser")
                        .WithMany("Roles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
