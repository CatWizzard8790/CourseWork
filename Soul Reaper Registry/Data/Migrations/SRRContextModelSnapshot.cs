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
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DivisionNumber");

                    b.HasIndex("CaptainId");

                    b.HasIndex("LieutenantId");

                    b.ToTable("Division");
                });

            modelBuilder.Entity("Data.Models.Hollow", b =>
                {
                    b.Property<int>("HId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("HollowClassificationId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("SRId")
                        .HasColumnType("int");

                    b.Property<int?>("WeaponPowerId")
                        .HasColumnType("int");

                    b.HasKey("HId");

                    b.HasIndex("HollowClassificationId");

                    b.HasIndex("SRId");

                    b.HasIndex("WeaponPowerId");

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
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("HCId");

                    b.ToTable("HollowClassification");
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
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("SpecialDivisionId")
                        .HasColumnType("int");

                    b.Property<string>("WeaponName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("WeaponPowerId")
                        .HasColumnType("int");

                    b.HasKey("SRId");

                    b.HasIndex("DivisionId");

                    b.HasIndex("SpecialDivisionId");

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

                    b.Property<int?>("LeaderId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SDId");

                    b.HasIndex("LeaderId");

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
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PType")
                        .HasColumnType("int");

                    b.Property<string>("SecondForm")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("WPId");

                    b.ToTable("WeaponPower");
                });

            modelBuilder.Entity("Data.Models.Division", b =>
                {
                    b.HasOne("Data.Models.SoulReaper", "Captain")
                        .WithMany()
                        .HasForeignKey("CaptainId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Data.Models.SoulReaper", "Lieutenant")
                        .WithMany()
                        .HasForeignKey("LieutenantId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("Captain");

                    b.Navigation("Lieutenant");
                });

            modelBuilder.Entity("Data.Models.Hollow", b =>
                {
                    b.HasOne("Data.Models.HollowClassification", "HollowClassification")
                        .WithMany("Hollows")
                        .HasForeignKey("HollowClassificationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Data.Models.SoulReaper", "SoulReaper")
                        .WithMany("Hollows")
                        .HasForeignKey("SRId");

                    b.HasOne("Data.Models.WeaponPower", "WeaponPower")
                        .WithMany()
                        .HasForeignKey("WeaponPowerId");

                    b.Navigation("HollowClassification");

                    b.Navigation("SoulReaper");

                    b.Navigation("WeaponPower");
                });

            modelBuilder.Entity("Data.Models.SoulReaper", b =>
                {
                    b.HasOne("Data.Models.Division", "Division")
                        .WithMany("SoulReapers")
                        .HasForeignKey("DivisionId");

                    b.HasOne("Data.Models.SpecialDivision", "SpecialDivision")
                        .WithMany("SoulReapers")
                        .HasForeignKey("SpecialDivisionId");

                    b.HasOne("Data.Models.WeaponPower", "WeaponPowers")
                        .WithMany()
                        .HasForeignKey("WeaponPowerId");

                    b.Navigation("Division");

                    b.Navigation("SpecialDivision");

                    b.Navigation("WeaponPowers");
                });

            modelBuilder.Entity("Data.Models.SpecialDivision", b =>
                {
                    b.HasOne("Data.Models.SoulReaper", "Leader")
                        .WithMany()
                        .HasForeignKey("LeaderId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("Leader");
                });

            modelBuilder.Entity("Data.Models.Division", b =>
                {
                    b.Navigation("SoulReapers");
                });

            modelBuilder.Entity("Data.Models.HollowClassification", b =>
                {
                    b.Navigation("Hollows");
                });

            modelBuilder.Entity("Data.Models.SoulReaper", b =>
                {
                    b.Navigation("Hollows");
                });

            modelBuilder.Entity("Data.Models.SpecialDivision", b =>
                {
                    b.Navigation("SoulReapers");
                });
#pragma warning restore 612, 618
        }
    }
}
