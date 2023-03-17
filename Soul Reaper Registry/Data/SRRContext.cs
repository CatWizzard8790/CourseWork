using System;
using Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class SRRContext : DbContext
    {
        public DbSet<SoulReaper> SoulReaper { get; set; }
        public DbSet<SpecialDivision> SpecialDivision { get; set; }
        public DbSet<WeaponPower> WeaponPower { get; set; }
        public DbSet<Division> Division { get; set; }
        public DbSet<HollowClassification> HollowClassification { get; set; }
        public DbSet<Hollow> Hollow { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            {
                optionsBuilder.UseSqlServer(@"Server=(localdb)\Jimmy; DataBase = SoulReaperRegistry; Integrated security = true");
                //DESKTOP-V015LRG\SQLEXPRESS
                //(localdb)\Jimmy
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

            modelBuilder.Entity<SpecialDivision>()
                .HasOne(d => d.Leader)
                .WithMany()
                .HasForeignKey(d => d.LeaderId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<SoulReaper>()
                .HasMany(h => h.Hollows);

            modelBuilder.Entity<Division>()
                .HasMany(s => s.SoulReapers);

            modelBuilder.Entity<SpecialDivision>()
                .HasMany(s => s.SoulReapers);

            modelBuilder.Entity<HollowClassification>()
                .HasMany(h => h.Hollows);


            //modelBuilder.Entity<MissionHollow>()
            //    .HasKey(mh => new { mh.HollowsId, mh.MissionsId });
            //modelBuilder.Entity<MissionSoulReaper>()
            //    .HasKey(msr => new { msr.MissionId, msr.SRId });

            //modelBuilder.Entity<Hollow>()
            //    .HasMany<Mission>(h => h.Missions)
            //    .WithMany(m => m.Hollows)
            //    .HasForeignKey(mh => mh.Missions )
        }
    }
}
