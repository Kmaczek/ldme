using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Ldme.DB.Setup;

namespace Ldme.DB.Migrations
{
    [DbContext(typeof(LdmeContext))]
    [Migration("20160927164348_InitialMigration")]
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

                    b.Property<DateTime>("ActivityDate");

                    b.Property<int?>("PlayerId");

                    b.Property<int?>("ReferencedQuestId");

                    b.HasKey("Id");

                    b.HasIndex("PlayerId");

                    b.HasIndex("ReferencedQuestId");

                    b.ToTable("Activities");
                });

            modelBuilder.Entity("Ldme.Models.Models.Player", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<double>("Gold");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Players");
                });

            modelBuilder.Entity("Ldme.Models.Models.Quest", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedDate");

                    b.Property<DateTime>("DeadlineDate");

                    b.Property<string>("Description");

                    b.Property<DateTime>("FinishedDate");

                    b.Property<string>("Name");

                    b.Property<double>("PenaltyGold");

                    b.Property<double>("PenaltyHonor");

                    b.Property<int?>("QuestGiverId");

                    b.Property<string>("QuestType");

                    b.Property<double>("RewardedGold");

                    b.Property<double>("RewardedHonor");

                    b.HasKey("Id");

                    b.HasIndex("QuestGiverId");

                    b.ToTable("Quests");
                });

            modelBuilder.Entity("Ldme.Models.Models.Activity", b =>
                {
                    b.HasOne("Ldme.Models.Models.Player", "Player")
                        .WithMany()
                        .HasForeignKey("PlayerId");

                    b.HasOne("Ldme.Models.Models.Quest", "ReferencedQuest")
                        .WithMany()
                        .HasForeignKey("ReferencedQuestId");
                });

            modelBuilder.Entity("Ldme.Models.Models.Quest", b =>
                {
                    b.HasOne("Ldme.Models.Models.Player", "QuestGiver")
                        .WithMany("Quests")
                        .HasForeignKey("QuestGiverId");
                });
        }
    }
}
