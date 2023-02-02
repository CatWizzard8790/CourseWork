using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soul_Reaper_Registry
{
    /// <summary>
    /// Intermediate table for Hollows and Missions, allowing the Many to Many relation. It also has information about whether the Hollow is dead or alive
    /// </summary>
    class MissionsHollows
    {
        public int MissionsId { get; private set; }
        public int HollowsId { get; private set; }
        public bool HollowStatus { get; private set; }
    }
}
