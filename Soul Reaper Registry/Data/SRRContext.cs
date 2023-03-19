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
                optionsBuilder.UseSqlServer(@"Server = DESKTOP-V015LRG\SQLEXPRESS; DataBase = SoulReaperRegistry; Integrated security = true");
                //DESKTOP-V015LRG\SQLEXPRESS
                //(localdb)\Jimmy
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Hollow>()
                .Property(n => n.Name)
                .IsRequired(true);

            modelBuilder.Entity<HollowClassification>()
                .Property(n => n.Name)
                .IsRequired(true);

            modelBuilder.Entity<HollowClassification>()
                .HasMany(h => h.Hollows);

            modelBuilder.Entity<SoulReaper>()
                .Property(fn => fn.FirstName)
                .IsRequired(true);

            modelBuilder.Entity<SoulReaper>()
                .Property(wpn => wpn.WeaponName)
                .IsRequired(true);

            modelBuilder.Entity<SoulReaper>()
                .HasMany(h => h.Hollows);

            modelBuilder.Entity<WeaponPower>()
                .Property(ff => ff.FirstForm)
                .IsRequired(true);

            modelBuilder.Entity<Division>()
                .Property(n => n.Name)
                .IsRequired(true);

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

            modelBuilder.Entity<Division>()
                .HasMany(s => s.SoulReapers);

            modelBuilder.Entity<SpecialDivision>()
                .HasOne(d => d.Leader)
                .WithMany()
                .HasForeignKey(d => d.LeaderId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<SpecialDivision>()
                .HasMany(s => s.SoulReapers);

            modelBuilder.Entity<SpecialDivision>()
                .Property(n => n.Name)
                .IsRequired(true);



        }
    }
}
