using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Divisions",
                columns: table => new
                {
                    DivisionNumber = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CaptainId = table.Column<int>(type: "int", nullable: false),
                    LieutenantId = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Divisions", x => x.DivisionNumber);
                });

            migrationBuilder.CreateTable(
                name: "HollowClassifications",
                columns: table => new
                {
                    HCId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HollowClassifications", x => x.HCId);
                });

            migrationBuilder.CreateTable(
                name: "Hollows",
                columns: table => new
                {
                    HId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClassId = table.Column<int>(type: "int", nullable: false),
                    Alive = table.Column<bool>(type: "bit", nullable: false),
                    WeaponPowerId = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hollows", x => x.HId);
                });

            migrationBuilder.CreateTable(
                name: "Missions",
                columns: table => new
                {
                    MId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateCompleted = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Missions", x => x.MId);
                });

            migrationBuilder.CreateTable(
                name: "MissionsHollows",
                columns: table => new
                {
                    MissionsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HollowsId = table.Column<int>(type: "int", nullable: false),
                    HollowStatus = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MissionsHollows", x => x.MissionsId);
                });

            migrationBuilder.CreateTable(
                name: "SoulReapers",
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
                    table.PrimaryKey("PK_SoulReapers", x => x.SRId);
                });

            migrationBuilder.CreateTable(
                name: "SoulReapersMissions",
                columns: table => new
                {
                    SRId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MissionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SoulReapersMissions", x => x.SRId);
                });

            migrationBuilder.CreateTable(
                name: "SpecialDivisions",
                columns: table => new
                {
                    SDId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LeaderId = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DivisionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpecialDivisions", x => x.SDId);
                });

            migrationBuilder.CreateTable(
                name: "WeaponPowers",
                columns: table => new
                {
                    WPId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstForm = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecondForm = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeaponPowers", x => x.WPId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Divisions");

            migrationBuilder.DropTable(
                name: "HollowClassifications");

            migrationBuilder.DropTable(
                name: "Hollows");

            migrationBuilder.DropTable(
                name: "Missions");

            migrationBuilder.DropTable(
                name: "MissionsHollows");

            migrationBuilder.DropTable(
                name: "SoulReapers");

            migrationBuilder.DropTable(
                name: "SoulReapersMissions");

            migrationBuilder.DropTable(
                name: "SpecialDivisions");

            migrationBuilder.DropTable(
                name: "WeaponPowers");
        }
    }
}
