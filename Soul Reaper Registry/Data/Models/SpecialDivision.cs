﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    /// <summary>
    /// A Special Division is a group of Soul Reapers that is different from the Thirteen Court Guard Squads(class Divisions). It contains the name of the Special Division, miscellaneous information and it could have a leader and be independent of one of the main 13 divisions. If the leader is a captain of a Division, all members fall under that Division.
    /// </summary>
    public class SpecialDivision
    {
        [Key]
        public int SDId { get; set; }

        public string Name { get; set; }

        [ForeignKey("Leader")]
        public int? LeaderId { get; set; }
        public SoulReaper Leader{ get; set; }

        public string? Description { get; set; }

        public SpecialDivision()
        {
            this.SoulReapers = new List<SoulReaper>();
        }
        public ICollection<SoulReaper> SoulReapers { get; set; }
    }
}
