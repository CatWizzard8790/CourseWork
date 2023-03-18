using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class changesinhollow : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Hollow_HollowClassification_HollowClassificationHCId",
                table: "Hollow");

            migrationBuilder.DropForeignKey(
                name: "FK_Hollow_SoulReaper_SoulReaperSRId",
                table: "Hollow");

            migrationBuilder.DropIndex(
                name: "IX_Hollow_HollowClassificationHCId",
                table: "Hollow");

            migrationBuilder.DropIndex(
                name: "IX_Hollow_SoulReaperSRId",
                table: "Hollow");

            migrationBuilder.DropColumn(
                name: "HollowClassificationHCId",
                table: "Hollow");

            migrationBuilder.DropColumn(
                name: "SoulReaperSRId",
                table: "Hollow");

            migrationBuilder.RenameColumn(
                name: "SRId",
                table: "SoulReaper",
                newName: "SRId");

            migrationBuilder.RenameColumn(
                name: "ClassId",
                table: "Hollow",
                newName: "HollowClassificationId");

            migrationBuilder.CreateIndex(
                name: "IX_Hollow_HollowClassificationId",
                table: "Hollow",
                column: "HollowClassificationId");

            migrationBuilder.CreateIndex(
                name: "IX_Hollow_SoulReaperId",
                table: "Hollow",
                column: "SRId");

            migrationBuilder.AddForeignKey(
                name: "FK_Hollow_HollowClassification_HollowClassificationId",
                table: "Hollow",
                column: "HollowClassificationId",
                principalTable: "HollowClassification",
                principalColumn: "HCId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Hollow_SoulReaper_SoulReaperId",
                table: "Hollow",
                column: "SRId",
                principalTable: "SoulReaper",
                principalColumn: "SRId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Hollow_HollowClassification_HollowClassificationId",
                table: "Hollow");

            migrationBuilder.DropForeignKey(
                name: "FK_Hollow_SoulReaper_SoulReaperId",
                table: "Hollow");

            migrationBuilder.DropIndex(
                name: "IX_Hollow_HollowClassificationId",
                table: "Hollow");

            migrationBuilder.DropIndex(
                name: "IX_Hollow_SoulReaperId",
                table: "Hollow");

            migrationBuilder.RenameColumn(
                name: "SRId",
                table: "SoulReaper",
                newName: "SRId");

            migrationBuilder.RenameColumn(
                name: "HollowClassificationId",
                table: "Hollow",
                newName: "ClassId");

            migrationBuilder.AddColumn<int>(
                name: "HollowClassificationHCId",
                table: "Hollow",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SoulReaperSRId",
                table: "Hollow",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Hollow_HollowClassificationHCId",
                table: "Hollow",
                column: "HollowClassificationHCId");

            migrationBuilder.CreateIndex(
                name: "IX_Hollow_SoulReaperSRId",
                table: "Hollow",
                column: "SoulReaperSRId");

            migrationBuilder.AddForeignKey(
                name: "FK_Hollow_HollowClassification_HollowClassificationHCId",
                table: "Hollow",
                column: "HollowClassificationHCId",
                principalTable: "HollowClassification",
                principalColumn: "HCId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Hollow_SoulReaper_SoulReaperSRId",
                table: "Hollow",
                column: "SoulReaperSRId",
                principalTable: "SoulReaper",
                principalColumn: "SRId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
