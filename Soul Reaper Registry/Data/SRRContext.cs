using System;
using Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class SRRContext : DbContext
    {
        public DbSet<SoulReapers> SoulReapers { get; set; }
        public DBSet<SoulReapersMissions> SoulReapersMissions { get; set; }
        public DbSet<SpecialDivisions> SpecialDivisions { get; set; }
        public DBSet<WeaponPowers> WeaponPowers { get; set; }
        public DBSet<Divisions> Divisions { get; set; }
        public DBSet<HollowClassifications> HollowClassifications { get; set; }
        public DBSet<Hollows> Hollows { get; set; }
        public DBSet<Missions> Missions { get; set; }
        public DBSet<MissionsHollows> MissionsHollows { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            {
                optionsBuilder.UseSqlServer(@"Server=(localdb)\Jimmy; DataBase = SoulReaperRegistry; Integrated security = true");
            }
        }
    }
}
