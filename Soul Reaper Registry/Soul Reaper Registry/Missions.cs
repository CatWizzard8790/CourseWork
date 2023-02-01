using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soul_Reaper_Registry
{
    class Missions
    {
        public int MId { get; private set; }
        public string Name { get; private set; }
        public DateTime DateCompleted { get; private set; }
        public string Description { get; private set; }
    }
}
