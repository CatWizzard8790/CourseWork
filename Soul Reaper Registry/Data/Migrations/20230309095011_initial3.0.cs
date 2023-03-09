using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class initial30 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_SoulReaper_WeaponPowerId",
                table: "SoulReaper",
                column: "WeaponPowerId");

            migrationBuilder.AddForeignKey(
                name: "FK_SoulReaper_WeaponPower_WeaponPowerId",
                table: "SoulReaper",
                column: "WeaponPowerId",
                principalTable: "WeaponPower",
                principalColumn: "WPId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SoulReaper_WeaponPower_WeaponPowerId",
                table: "SoulReaper");

            migrationBuilder.DropIndex(
                name: "IX_SoulReaper_WeaponPowerId",
                table: "SoulReaper");
        }
    }
}
