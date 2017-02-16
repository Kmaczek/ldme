using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Ldme.DB.Migrations
{
    public partial class Repetitions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Repetitions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CompletionDate = table.Column<DateTime>(nullable: false),
                    GoldGain = table.Column<float>(nullable: false),
                    HonorGain = table.Column<float>(nullable: false),
                    ReferencedQuestId = table.Column<int>(nullable: false),
                    TagingPlayerId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Repetitions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Repetitions_Quests_ReferencedQuestId",
                        column: x => x.ReferencedQuestId,
                        principalTable: "Quests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Repetitions_Players_TagingPlayerId",
                        column: x => x.TagingPlayerId,
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Repetitions_ReferencedQuestId",
                table: "Repetitions",
                column: "ReferencedQuestId");

            migrationBuilder.CreateIndex(
                name: "IX_Repetitions_TagingPlayerId",
                table: "Repetitions",
                column: "TagingPlayerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Repetitions");
        }
    }
}
