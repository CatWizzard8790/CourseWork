using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    /// <summary>
    /// Hollows are a race of creatures which are born from Human souls and have a name and a class- depending on the stage that it has evolved to. Their "Alive" status can change- depending on wheither or not they were involved in the table "Missions".
    /// Not all hollows have Powers(WeaponPowerId).
    /// </summary>
    public class Hollows
    {
        public int HId { get; set; }
        public string Name { get; set; }
        public int ClassId { get; set; }
        public bool Alive { get; set; }
        public int WeaponPowerId { get; set; }
        public string Description { get; set; }
    }
}
