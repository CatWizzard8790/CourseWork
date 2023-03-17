using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class aaaaaaaa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HollowClassification",
                columns: table => new
                {
                    HCId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HollowClassification", x => x.HCId);
                });

            migrationBuilder.CreateTable(
                name: "WeaponPower",
                columns: table => new
                {
                    WPId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstForm = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecondForm = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PType = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeaponPower", x => x.WPId);
                });

            migrationBuilder.CreateTable(
                name: "SoulReaper",
                columns: table => new
                {
                    SRId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EnrollDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Available = table.Column<bool>(type: "bit", nullable: false),
                    DivisionId = table.Column<int>(type: "int", nullable: true),
                    SpecialId = table.Column<int>(type: "int", nullable: true),
                    WeaponName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WeaponPowerId = table.Column<int>(type: "int", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SoulReaper", x => x.SRId);
                    table.ForeignKey(
                        name: "FK_SoulReaper_WeaponPower_WeaponPowerId",
                        column: x => x.WeaponPowerId,
                        principalTable: "WeaponPower",
                        principalColumn: "WPId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Division",
                columns: table => new
                {
                    DivisionNumber = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CaptainId = table.Column<int>(type: "int", nullable: true),
                    LieutenantId = table.Column<int>(type: "int", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Division", x => x.DivisionNumber);
                    table.ForeignKey(
                        name: "FK_Division_SoulReaper_CaptainId",
                        column: x => x.CaptainId,
                        principalTable: "SoulReaper",
                        principalColumn: "SRId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Division_SoulReaper_LieutenantId",
                        column: x => x.LieutenantId,
                        principalTable: "SoulReaper",
                        principalColumn: "SRId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Hollow",
                columns: table => new
                {
                    HId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClassId = table.Column<int>(type: "int", nullable: false),
                    HollowClassificationHCId = table.Column<int>(type: "int", nullable: true),
                    WeaponPowerId = table.Column<int>(type: "int", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SRId = table.Column<int>(type: "int", nullable: true),
                    SoulReaperSRId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hollow", x => x.HId);
                    table.ForeignKey(
                        name: "FK_Hollow_HollowClassification_HollowClassificationHCId",
                        column: x => x.HollowClassificationHCId,
                        principalTable: "HollowClassification",
                        principalColumn: "HCId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Hollow_SoulReaper_SoulReaperSRId",
                        column: x => x.SoulReaperSRId,
                        principalTable: "SoulReaper",
                        principalColumn: "SRId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Hollow_WeaponPower_WeaponPowerId",
                        column: x => x.WeaponPowerId,
                        principalTable: "WeaponPower",
                        principalColumn: "WPId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SpecialDivision",
                columns: table => new
                {
                    SDId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LeaderId = table.Column<int>(type: "int", nullable: true),
                    DivisionId = table.Column<int>(type: "int", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpecialDivision", x => x.SDId);
                    table.ForeignKey(
                        name: "FK_SpecialDivision_Division_DivisionId",
                        column: x => x.DivisionId,
                        principalTable: "Division",
                        principalColumn: "DivisionNumber",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SpecialDivision_SoulReaper_LeaderId",
                        column: x => x.LeaderId,
                        principalTable: "SoulReaper",
                        principalColumn: "SRId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Division_CaptainId",
                table: "Division",
                column: "CaptainId");

            migrationBuilder.CreateIndex(
                name: "IX_Division_LieutenantId",
                table: "Division",
                column: "LieutenantId");

            migrationBuilder.CreateIndex(
                name: "IX_Hollow_HollowClassificationHCId",
                table: "Hollow",
                column: "HollowClassificationHCId");

            migrationBuilder.CreateIndex(
                name: "IX_Hollow_SoulReaperSRId",
                table: "Hollow",
                column: "SoulReaperSRId");

            migrationBuilder.CreateIndex(
                name: "IX_Hollow_WeaponPowerId",
                table: "Hollow",
                column: "WeaponPowerId");

            migrationBuilder.CreateIndex(
                name: "IX_SoulReaper_DivisionId",
                table: "SoulReaper",
                column: "DivisionId");

            migrationBuilder.CreateIndex(
                name: "IX_SoulReaper_WeaponPowerId",
                table: "SoulReaper",
                column: "WeaponPowerId");

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
                name: "FK_Division_SoulReaper_CaptainId",
                table: "Division");

            migrationBuilder.DropForeignKey(
                name: "FK_Division_SoulReaper_LieutenantId",
                table: "Division");

            migrationBuilder.DropTable(
                name: "Hollow");

            migrationBuilder.DropTable(
                name: "SpecialDivision");

            migrationBuilder.DropTable(
                name: "HollowClassification");

            migrationBuilder.DropTable(
                name: "SoulReaper");

            migrationBuilder.DropTable(
                name: "Division");

            migrationBuilder.DropTable(
                name: "WeaponPower");
        }
    }
}
