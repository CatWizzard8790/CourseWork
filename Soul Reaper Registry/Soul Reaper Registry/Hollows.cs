using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soul_Reaper_Registry
{
    /// <summary>
    /// Hollows are a race of creatures which are born from Human souls and have a name and a class- depending on the stage that it has evolved to. Their "Alive" status can change- depending on wheither or not they were involved in the table "Missions".
    /// Not all hollows have Powers(WeaponPowerId).
    /// </summary>
    class Hollows
    {
        public int HId { get; private set; }
        public string Name { get; private set; }
        public int ClassId { get; private set; }
        public bool Alive { get; private set; }
        public int WeaponPowerId { get; private set; }
        public string Description { get; private set; }
    }
}
