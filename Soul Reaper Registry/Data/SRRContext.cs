using System;
using Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class SRRContext : DbContext
    {
        public DbSet<SoulReaper> SoulReapers { get; set; }
        public DbSet<MissionSoulReaper> MissionsSoulReapers { get; set; }
        public DbSet<SpecialDivision> SpecialDivisions { get; set; }
        public DbSet<WeaponPower> WeaponPowers { get; set; }
        public DbSet<Division> Divisions { get; set; }
        public DbSet<HollowClassification> HollowClassifications { get; set; }
        public DbSet<Hollow> Hollows { get; set; }
        public DbSet<Mission> Missions { get; set; }
        public DbSet<MissionHollow> MissionsHollows { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            {
                optionsBuilder.UseSqlServer(@"Server=(localdb)\Jimmy; DataBase = SoulReaperRegistry; Integrated security = true");
            }
        }
    }
}
