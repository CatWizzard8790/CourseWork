using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class misssoulreap : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MissionSoulReaper",
                columns: table => new
                {
                    MissionsIdMId = table.Column<int>(type: "int", nullable: false),
                    SoulReaperIdSRId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MissionSoulReaper", x => new { x.MissionsIdMId, x.SoulReaperIdSRId });
                    table.ForeignKey(
                        name: "FK_MissionSoulReaper_Mission_MissionsIdMId",
                        column: x => x.MissionsIdMId,
                        principalTable: "Mission",
                        principalColumn: "MId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MissionSoulReaper_SoulReaper_SoulReaperIdSRId",
                        column: x => x.SoulReaperIdSRId,
                        principalTable: "SoulReaper",
                        principalColumn: "SRId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MissionSoulReaper_SoulReaperIdSRId",
                table: "MissionSoulReaper",
                column: "SoulReaperIdSRId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MissionSoulReaper");
        }
    }
}
