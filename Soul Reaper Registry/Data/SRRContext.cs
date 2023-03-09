using System;
using Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class SRRContext : DbContext
    {
        public DbSet<SoulReaper> SoulReaper { get; set; }
        public DbSet<MissionSoulReaper> MissionsSoulReaper { get; set; }
        public DbSet<SpecialDivision> SpecialDivision { get; set; }
        public DbSet<WeaponPower> WeaponPower { get; set; }
        public DbSet<Division> Division { get; set; }
        public DbSet<HollowClassification> HollowClassification { get; set; }
        public DbSet<Hollow> Hollow { get; set; }
        public DbSet<Mission> Mission { get; set; }
        public DbSet<MissionHollow> MissionsHollow { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            {
                optionsBuilder.UseSqlServer(@"Server=(localdb)\Jimmy; DataBase = SoulReaperRegistry; Integrated security = true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Division>()
                .HasOne(d => d.Captain)
                .WithMany()
                .HasForeignKey(d => d.CaptainId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Division>()
                .HasOne(d => d.Lieutenant)
                .WithMany()
                .HasForeignKey(d => d.LieutenantId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
