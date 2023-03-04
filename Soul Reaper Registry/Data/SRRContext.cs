using System;
using Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class SRRContext : DbContext
    {
        public DbSet<SoulReapers> SoulReapers { get; set; }
        public DbSet<SoulReapersMissions> SoulReapersMissions { get; set; }
        public DbSet<SpecialDivisions> SpecialDivisions { get; set; }
        public DbSet<WeaponPowers> WeaponPowers { get; set; }
        public DbSet<Divisions> Divisions { get; set; }
        public DbSet<HollowClassifications> HollowClassifications { get; set; }
        public DbSet<Hollows> Hollows { get; set; }
        public DbSet<Missions> Missions { get; set; }
        public DbSet<MissionsHollows> MissionsHollows { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            {
                optionsBuilder.UseSqlServer(@"Server=(localdb)\Jimmy; DataBase = SoulReaperRegistry; Integrated security = true");
            }
        }
    }
}
