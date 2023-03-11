using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class keys : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_MissionsSoulReaper",
                table: "MissionsSoulReaper");

            migrationBuilder.DropIndex(
                name: "IX_MissionsSoulReaper_MissionId",
                table: "MissionsSoulReaper");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MissionsHollow",
                table: "MissionsHollow");

            migrationBuilder.AlterColumn<int>(
                name: "SRId",
                table: "MissionsSoulReaper",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "MissionsId",
                table: "MissionsHollow",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MissionsSoulReaper",
                table: "MissionsSoulReaper",
                columns: new[] { "MissionId", "SRId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_MissionsHollow",
                table: "MissionsHollow",
                columns: new[] { "HollowsId", "MissionsId" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_MissionsSoulReaper",
                table: "MissionsSoulReaper");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MissionsHollow",
                table: "MissionsHollow");

            migrationBuilder.AlterColumn<int>(
                name: "SRId",
                table: "MissionsSoulReaper",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "MissionsId",
                table: "MissionsHollow",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MissionsSoulReaper",
                table: "MissionsSoulReaper",
                column: "SRId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MissionsHollow",
                table: "MissionsHollow",
                column: "MissionsId");

            migrationBuilder.CreateIndex(
                name: "IX_MissionsSoulReaper_MissionId",
                table: "MissionsSoulReaper",
                column: "MissionId");
        }
    }
}
