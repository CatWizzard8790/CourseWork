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

            modelBuilder.Entity("Data.Models.Division", b =>
                {
                    b.Property<int>("DivisionNumber")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CaptainId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("LieutenantId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DivisionNumber");

                    b.ToTable("Division");
                });

            modelBuilder.Entity("Data.Models.Hollow", b =>
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

                    b.Property<int?>("WeaponPowerId")
                        .HasColumnType("int");

                    b.HasKey("HId");

                    b.ToTable("Hollow");
                });

            modelBuilder.Entity("Data.Models.HollowClassification", b =>
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

                    b.ToTable("HollowClassification");
                });

            modelBuilder.Entity("Data.Models.Mission", b =>
                {
                    b.Property<int>("MId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("DateCompleted")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MId");

                    b.ToTable("Mission");
                });

            modelBuilder.Entity("Data.Models.MissionHollow", b =>
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

                    b.ToTable("MissionsHollow");
                });

            modelBuilder.Entity("Data.Models.MissionSoulReaper", b =>
                {
                    b.Property<int>("SRId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("MissionId")
                        .HasColumnType("int");

                    b.HasKey("SRId");

                    b.ToTable("MissionsSoulReaper");
                });

            modelBuilder.Entity("Data.Models.SoulReaper", b =>
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

                    b.HasIndex("WeaponPowerId");

                    b.ToTable("SoulReaper");
                });

            modelBuilder.Entity("Data.Models.SpecialDivision", b =>
                {
                    b.Property<int>("SDId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("DivisionId")
                        .HasColumnType("int");

                    b.Property<int?>("LeaderId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SDId");

                    b.ToTable("SpecialDivision");
                });

            modelBuilder.Entity("Data.Models.WeaponPower", b =>
                {
                    b.Property<int>("WPId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstForm")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PType")
                        .HasColumnType("int");

                    b.Property<string>("SecondForm")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("WPId");

                    b.ToTable("WeaponPower");
                });

            modelBuilder.Entity("Data.Models.SoulReaper", b =>
                {
                    b.HasOne("Data.Models.WeaponPower", "WeaponPowers")
                        .WithMany()
                        .HasForeignKey("WeaponPowerId");

                    b.Navigation("WeaponPowers");
                });
#pragma warning restore 612, 618
        }
    }
}
