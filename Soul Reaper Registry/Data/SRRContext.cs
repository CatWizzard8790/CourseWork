using System;
using Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class SRRContext : DbContext
    {
        public DbSet<SoulReapers> SoulReapers { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            {
                optionsBuilder.UseSqlServer(@"Server=; DataBase = SoulReaperRegistry; Integrated security = true");
            }
        }
    }
}
