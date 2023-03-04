using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    /// <summary>
    /// Intermediate table for SoulReapers and Missions, allowing the Many to Many relation.
    /// </summary>
    public class SoulReapersMissions
    {
        [Key]
        public int SRId { get; set; }
        public int MissionId { get; set; }
    }
}
