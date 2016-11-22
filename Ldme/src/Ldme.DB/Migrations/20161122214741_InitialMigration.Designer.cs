using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Ldme.DB.Setup;

namespace Ldme.DB.Migrations
{
    [DbContext(typeof(LdmeContext))]
    [Migration("20161122214741_InitialMigration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
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

                    b.Property<int>("Gold");

                    b.Property<int>("Honor");

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

                    b.Property<int>("GoldPenalty");

                    b.Property<int>("GoldReward");

                    b.Property<int>("HonorPenalty");

                    b.Property<int>("HonorReward");

                    b.Property<int>("MaxRepetitions");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<int>("QuestCreatorId");

                    b.Property<int>("QuestOwnerId");

                    b.Property<string>("QuestType");

                    b.Property<int>("RequiredRepetitions");

                    b.Property<DateTime?>("StartedDate");

                    b.HasKey("Id");

                    b.HasIndex("QuestCreatorId");

                    b.HasIndex("QuestOwnerId");

                    b.ToTable("Quests");
                });

            modelBuilder.Entity("Ldme.Models.Models.RepTag", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CompletionDate");

                    b.Property<int>("GoldGain");

                    b.Property<int>("HonorGain");

                    b.Property<int>("ReferencedQuestId");

                    b.Property<int>("TagingPlayerId");

                    b.HasKey("Id");

                    b.HasIndex("ReferencedQuestId");

                    b.HasIndex("TagingPlayerId");

                    b.ToTable("RepTags");
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

            modelBuilder.Entity("Ldme.Models.Models.RepTag", b =>
                {
                    b.HasOne("Ldme.Models.Models.Quest", "ReferencedQuest")
                        .WithMany()
                        .HasForeignKey("ReferencedQuestId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Ldme.Models.Models.Player", "TagingPlayer")
                        .WithMany()
                        .HasForeignKey("TagingPlayerId")
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
