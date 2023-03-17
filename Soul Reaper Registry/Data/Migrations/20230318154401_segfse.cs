using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class segfse : Migration
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
                    SpecialDivisionId = table.Column<int>(type: "int", nullable: true),
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
                    HollowClassificationId = table.Column<int>(type: "int", nullable: false),
                    WeaponPowerId = table.Column<int>(type: "int", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SRId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hollow", x => x.HId);
                    table.ForeignKey(
                        name: "FK_Hollow_HollowClassification_HollowClassificationId",
                        column: x => x.HollowClassificationId,
                        principalTable: "HollowClassification",
                        principalColumn: "HCId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Hollow_SoulReaper_SRId",
                        column: x => x.SRId,
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
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpecialDivision", x => x.SDId);
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
                name: "IX_Hollow_HollowClassificationId",
                table: "Hollow",
                column: "HollowClassificationId");

            migrationBuilder.CreateIndex(
                name: "IX_Hollow_SRId",
                table: "Hollow",
                column: "SRId");

            migrationBuilder.CreateIndex(
                name: "IX_Hollow_WeaponPowerId",
                table: "Hollow",
                column: "WeaponPowerId");

            migrationBuilder.CreateIndex(
                name: "IX_SoulReaper_DivisionId",
                table: "SoulReaper",
                column: "DivisionId");

            migrationBuilder.CreateIndex(
                name: "IX_SoulReaper_SpecialDivisionId",
                table: "SoulReaper",
                column: "SpecialDivisionId");

            migrationBuilder.CreateIndex(
                name: "IX_SoulReaper_WeaponPowerId",
                table: "SoulReaper",
                column: "WeaponPowerId");

            migrationBuilder.CreateIndex(
                name: "IX_SpecialDivision_LeaderId",
                table: "SpecialDivision",
                column: "LeaderId");

            migrationBuilder.AddForeignKey(
                name: "FK_SoulReaper_Division_DivisionId",
                table: "SoulReaper",
                column: "DivisionId",
                principalTable: "Division",
                principalColumn: "DivisionNumber",
                onDelete: ReferentialAction.Restrict);

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
                name: "FK_Division_SoulReaper_CaptainId",
                table: "Division");

            migrationBuilder.DropForeignKey(
                name: "FK_Division_SoulReaper_LieutenantId",
                table: "Division");

            migrationBuilder.DropForeignKey(
                name: "FK_SpecialDivision_SoulReaper_LeaderId",
                table: "SpecialDivision");

            migrationBuilder.DropTable(
                name: "Hollow");

            migrationBuilder.DropTable(
                name: "HollowClassification");

            migrationBuilder.DropTable(
                name: "SoulReaper");

            migrationBuilder.DropTable(
                name: "Division");

            migrationBuilder.DropTable(
                name: "SpecialDivision");

            migrationBuilder.DropTable(
                name: "WeaponPower");
        }
    }
}
