using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class plss : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Division_CaptainId",
                table: "Division");

            migrationBuilder.CreateIndex(
                name: "IX_SoulReaper_DivisionId",
                table: "SoulReaper",
                column: "DivisionId");

            migrationBuilder.CreateIndex(
                name: "IX_Division_CaptainId",
                table: "Division",
                column: "CaptainId");

            migrationBuilder.CreateIndex(
                name: "IX_Division_LieutenantId",
                table: "Division",
                column: "LieutenantId");

            migrationBuilder.AddForeignKey(
                name: "FK_Division_SoulReaper_LieutenantId",
                table: "Division",
                column: "LieutenantId",
                principalTable: "SoulReaper",
                principalColumn: "SRId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SoulReaper_Division_DivisionId",
                table: "SoulReaper",
                column: "DivisionId",
                principalTable: "Division",
                principalColumn: "DivisionNumber",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Division_SoulReaper_LieutenantId",
                table: "Division");

            migrationBuilder.DropForeignKey(
                name: "FK_SoulReaper_Division_DivisionId",
                table: "SoulReaper");

            migrationBuilder.DropIndex(
                name: "IX_SoulReaper_DivisionId",
                table: "SoulReaper");

            migrationBuilder.DropIndex(
                name: "IX_Division_CaptainId",
                table: "Division");

            migrationBuilder.DropIndex(
                name: "IX_Division_LieutenantId",
                table: "Division");

            migrationBuilder.CreateIndex(
                name: "IX_Division_CaptainId",
                table: "Division",
                column: "CaptainId",
                unique: true,
                filter: "[CaptainId] IS NOT NULL");
        }
    }
}
