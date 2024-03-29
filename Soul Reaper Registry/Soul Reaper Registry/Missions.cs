﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soul_Reaper_Registry
{
    /// <summary>
    /// This table contains the names and descriptions of missions, which are tasks that can be given to Soul Reapers to complete. If a DateCompleted is given, the mission will be considered done. If a hollow is involved, it updates its status.
    /// </summary>
    public class Missions
    {
        public int MId { get; set; }
        public string Name { get; set; }
        public DateTime DateCompleted { get; set; }
        public string Description { get; set; }
    }
}
