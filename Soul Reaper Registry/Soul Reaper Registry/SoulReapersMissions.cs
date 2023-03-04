using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soul_Reaper_Registry
{
    /// <summary>
    /// Intermediate table for SoulReapers and Missions, allowing the Many to Many relation.
    /// </summary>
    public class SoulReapersMissions
    {
        public int SRId { get; set; }
        public int MissionId { get; set; }
    }
}
