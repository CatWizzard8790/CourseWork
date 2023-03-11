using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    /// <summary>
    /// Intermediate table for SoulReapers and Missions, allowing the Many to Many relation.
    /// </summary>
    public class MissionSoulReaper
    {
        [Key]
        public int SRId { get; set; }

        [ForeignKey("MissionId")]
        public int MissionId { get; set; }
        public Mission Mission { get; set; }
    }
}
