using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Ldme.DB.Migrations
{
    public partial class Rewards : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Rewards",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Deactivated = table.Column<DateTime>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    GoldPrice = table.Column<int>(nullable: false),
                    HonorPrice = table.Column<int>(nullable: false),
                    RewardCreatorId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rewards", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rewards_Players_RewardCreatorId",
                        column: x => x.RewardCreatorId,
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RewardClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ClaimDate = table.Column<DateTime>(nullable: false),
                    ClaimedById = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RewardClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RewardClaims_Players_ClaimedById",
                        column: x => x.ClaimedById,
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Rewards_RewardCreatorId",
                table: "Rewards",
                column: "RewardCreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_RewardClaims_ClaimedById",
                table: "RewardClaims",
                column: "ClaimedById");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Rewards");

            migrationBuilder.DropTable(
                name: "RewardClaims");
        }
    }
}
