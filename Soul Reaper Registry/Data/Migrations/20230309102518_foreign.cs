using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class foreign : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HollowStatus",
                table: "MissionsHollow");

            migrationBuilder.DropColumn(
                name: "Alive",
                table: "Hollow");

            migrationBuilder.AddColumn<int>(
                name: "HollowHId",
                table: "MissionsHollow",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HollowClassificationHCId",
                table: "Hollow",
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

            migrationBuilder.CreateIndex(
                name: "IX_MissionsSoulReaper_MissionId",
                table: "MissionsSoulReaper",
                column: "MissionId");

            migrationBuilder.CreateIndex(
                name: "IX_MissionsHollow_HollowHId",
                table: "MissionsHollow",
                column: "HollowHId");

            migrationBuilder.CreateIndex(
                name: "IX_Hollow_HollowClassificationHCId",
                table: "Hollow",
                column: "HollowClassificationHCId");

            migrationBuilder.CreateIndex(
                name: "IX_Hollow_WeaponPowerId",
                table: "Hollow",
                column: "WeaponPowerId");

            migrationBuilder.CreateIndex(
                name: "IX_Division_CaptainId",
                table: "Division",
                column: "CaptainId",
                unique: true,
                filter: "[CaptainId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Division_SoulReaper_CaptainId",
                table: "Division",
                column: "CaptainId",
                principalTable: "SoulReaper",
                principalColumn: "SRId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Hollow_HollowClassification_HollowClassificationHCId",
                table: "Hollow",
                column: "HollowClassificationHCId",
                principalTable: "HollowClassification",
                principalColumn: "HCId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Hollow_WeaponPower_WeaponPowerId",
                table: "Hollow",
                column: "WeaponPowerId",
                principalTable: "WeaponPower",
                principalColumn: "WPId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MissionsHollow_Hollow_HollowHId",
                table: "MissionsHollow",
                column: "HollowHId",
                principalTable: "Hollow",
                principalColumn: "HId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MissionsSoulReaper_Mission_MissionId",
                table: "MissionsSoulReaper",
                column: "MissionId",
                principalTable: "Mission",
                principalColumn: "MId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SpecialDivision_Division_DivisionId",
                table: "SpecialDivision",
                column: "DivisionId",
                principalTable: "Division",
                principalColumn: "DivisionNumber",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SpecialDivision_SoulReaper_LeaderId",
                table: "SpecialDivision",
                column: "LeaderId",
                principalTable: "SoulReaper",
                principalColumn: "SRId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Division_SoulReaper_CaptainId",
                table: "Division");

            migrationBuilder.DropForeignKey(
                name: "FK_Hollow_HollowClassification_HollowClassificationHCId",
                table: "Hollow");

            migrationBuilder.DropForeignKey(
                name: "FK_Hollow_WeaponPower_WeaponPowerId",
                table: "Hollow");

            migrationBuilder.DropForeignKey(
                name: "FK_MissionsHollow_Hollow_HollowHId",
                table: "MissionsHollow");

            migrationBuilder.DropForeignKey(
                name: "FK_MissionsSoulReaper_Mission_MissionId",
                table: "MissionsSoulReaper");

            migrationBuilder.DropForeignKey(
                name: "FK_SpecialDivision_Division_DivisionId",
                table: "SpecialDivision");

            migrationBuilder.DropForeignKey(
                name: "FK_SpecialDivision_SoulReaper_LeaderId",
                table: "SpecialDivision");

            migrationBuilder.DropIndex(
                name: "IX_SpecialDivision_DivisionId",
                table: "SpecialDivision");

            migrationBuilder.DropIndex(
                name: "IX_SpecialDivision_LeaderId",
                table: "SpecialDivision");

            migrationBuilder.DropIndex(
                name: "IX_MissionsSoulReaper_MissionId",
                table: "MissionsSoulReaper");

            migrationBuilder.DropIndex(
                name: "IX_MissionsHollow_HollowHId",
                table: "MissionsHollow");

            migrationBuilder.DropIndex(
                name: "IX_Hollow_HollowClassificationHCId",
                table: "Hollow");

            migrationBuilder.DropIndex(
                name: "IX_Hollow_WeaponPowerId",
                table: "Hollow");

            migrationBuilder.DropIndex(
                name: "IX_Division_CaptainId",
                table: "Division");

            migrationBuilder.DropColumn(
                name: "HollowHId",
                table: "MissionsHollow");

            migrationBuilder.DropColumn(
                name: "HollowClassificationHCId",
                table: "Hollow");

            migrationBuilder.AddColumn<bool>(
                name: "HollowStatus",
                table: "MissionsHollow",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Alive",
                table: "Hollow",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
