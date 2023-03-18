using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class coloctionperfect : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SpecialDivision_Division_DivisionId",
                table: "SpecialDivision");

            migrationBuilder.DropIndex(
                name: "IX_SpecialDivision_DivisionId",
                table: "SpecialDivision");

            migrationBuilder.DropIndex(
                name: "IX_SpecialDivision_LeaderId",
                table: "SpecialDivision");

            migrationBuilder.DropColumn(
                name: "DivisionId",
                table: "SpecialDivision");

            migrationBuilder.CreateIndex(
                name: "IX_SpecialDivision_LeaderId",
                table: "SpecialDivision",
                column: "LeaderId");

            migrationBuilder.CreateIndex(
                name: "IX_SoulReaper_SpecialDivisionId",
                table: "SoulReaper",
                column: "SpecialDivisionId");

            migrationBuilder.AddForeignKey(
                name: "FK_SoulReaper_SpecialDivision_SpecialDivisionId",
                table: "SoulReaper",
                column: "SpecialDivisionId",
                principalTable: "SpecialDivision",
                principalColumn: "SDId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SoulReaper_SpecialDivision_SpecialDivisionId",
                table: "SoulReaper");

            migrationBuilder.DropIndex(
                name: "IX_SpecialDivision_LeaderId",
                table: "SpecialDivision");

            migrationBuilder.DropIndex(
                name: "IX_SoulReaper_SpecialDivisionId",
                table: "SoulReaper");

            migrationBuilder.AddColumn<int>(
                name: "DivisionId",
                table: "SpecialDivision",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SpecialDivision_DivisionId",
                table: "SpecialDivision",
                column: "DivisionId");

            migrationBuilder.CreateIndex(
                name: "IX_SpecialDivision_LeaderId",
                table: "SpecialDivision",
                column: "LeaderId",
                unique: true,
                filter: "[LeaderId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_SpecialDivision_Division_DivisionId",
                table: "SpecialDivision",
                column: "DivisionId",
                principalTable: "Division",
                principalColumn: "DivisionNumber",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
