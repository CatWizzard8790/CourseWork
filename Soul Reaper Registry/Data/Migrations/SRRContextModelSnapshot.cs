﻿// <auto-generated />
using System;
using Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Data.Migrations
{
    [DbContext(typeof(SRRContext))]
    partial class SRRContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Data.Models.Divisions", b =>
                {
                    b.Property<int>("DivisionNumber")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CaptainId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("LieutenantId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DivisionNumber");

                    b.ToTable("Divisions");
                });

            modelBuilder.Entity("Data.Models.HollowClassifications", b =>
                {
                    b.Property<int>("HCId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("HCId");

                    b.ToTable("HollowClassifications");
                });

            modelBuilder.Entity("Data.Models.Hollows", b =>
                {
                    b.Property<int>("HId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Alive")
                        .HasColumnType("bit");

                    b.Property<int>("ClassId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("WeaponPowerId")
                        .HasColumnType("int");

                    b.HasKey("HId");

                    b.ToTable("Hollows");
                });

            modelBuilder.Entity("Data.Models.Missions", b =>
                {
                    b.Property<int>("MId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateCompleted")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MId");

                    b.ToTable("Missions");
                });

            modelBuilder.Entity("Data.Models.MissionsHollows", b =>
                {
                    b.Property<int>("MissionsId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("HollowStatus")
                        .HasColumnType("bit");

                    b.Property<int>("HollowsId")
                        .HasColumnType("int");

                    b.HasKey("MissionsId");

                    b.ToTable("MissionsHollows");
                });

            modelBuilder.Entity("Data.Models.SoulReapers", b =>
                {
                    b.Property<int>("SRId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Available")
                        .HasColumnType("bit");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("DivisionId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("EnrollDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("SpecialId")
                        .HasColumnType("int");

                    b.Property<string>("WeaponName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("WeaponPowerId")
                        .HasColumnType("int");

                    b.HasKey("SRId");

                    b.ToTable("SoulReapers");
                });

            modelBuilder.Entity("Data.Models.SoulReapersMissions", b =>
                {
                    b.Property<int>("SRId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("MissionId")
                        .HasColumnType("int");

                    b.HasKey("SRId");

                    b.ToTable("SoulReapersMissions");
                });

            modelBuilder.Entity("Data.Models.SpecialDivisions", b =>
                {
                    b.Property<int>("SDId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("DivisionId")
                        .HasColumnType("int");

                    b.Property<int>("LeaderId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SDId");

                    b.ToTable("SpecialDivisions");
                });

            modelBuilder.Entity("Data.Models.WeaponPowers", b =>
                {
                    b.Property<int>("WPId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FirstForm")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PType")
                        .HasColumnType("int");

                    b.Property<string>("SecondForm")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("WPId");

                    b.ToTable("WeaponPowers");
                });
#pragma warning restore 612, 618
        }
    }
}
