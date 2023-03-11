using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class hollowMission : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HollowMission",
                columns: table => new
                {
                    HollowIdHId = table.Column<int>(type: "int", nullable: false),
                    MissionIdMId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HollowMission", x => new { x.HollowIdHId, x.MissionIdMId });
                    table.ForeignKey(
                        name: "FK_HollowMission_Hollow_HollowIdHId",
                        column: x => x.HollowIdHId,
                        principalTable: "Hollow",
                        principalColumn: "HId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HollowMission_Mission_MissionIdMId",
                        column: x => x.MissionIdMId,
                        principalTable: "Mission",
                        principalColumn: "MId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HollowMission_MissionIdMId",
                table: "HollowMission",
                column: "MissionIdMId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HollowMission");
        }
    }
}
