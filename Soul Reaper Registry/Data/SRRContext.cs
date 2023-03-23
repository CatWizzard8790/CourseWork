using System;
using Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    /// <summary>
    /// The Database Context for the project. It contains the DbSets for all of the tables/entities and allows the more complex of connection to function.
    /// </summary>
    public class SRRContext : DbContext
    {
        public SRRContext()
        {

        }

        public SRRContext(DbContextOptions<SRRContext> options) : base(options)
        {

        }

        public DbSet<SoulReaper> SoulReaper { get; set; }
        public DbSet<SpecialDivision> SpecialDivision { get; set; }
        public DbSet<WeaponPower> WeaponPower { get; set; }
        public DbSet<Division> Division { get; set; }
        public DbSet<HollowClassification> HollowClassification { get; set; }
        public DbSet<Hollow> Hollow { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            {
                optionsBuilder.UseSqlServer(@"Server = (localdb)\Jimmy; DataBase = SoulReaperRegistry; Integrated security = true");
                //DESKTOP-V015LRG\SQLEXPRESS
                //(localdb)\Jimmy
            }
        }

        //Defines the stubborn properties and connections that do not work otherwise.
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Making sure that all of the properties are required or optional.
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

            //Making the complex relation to the Soul Reaper table a reality
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

            //Defining the Special Division connections and properties.
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
