using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soul_Reaper_Registry
{
    /// <summary>
    /// The Thirteen Court Guard Squads, or the 13 Divisions is the primary military branch of the Soul Society. It is also the main military organization that most Soul Reapers join. The exception being Squad 0 which is composed of 5 captain level Soul Reapers.
    ///All Divisions have a name, a Captain and a Lieutenant, plus some miscellaneous information.
    /// </summary>
    public class Divisions
    {
        public int DivisionNumber { get; set; }
        public string Name { get; set; }
        public int CaptainId { get; set; }
        public int LieutenantId { get; set; }
        public string Description { get; set; }

    }
}
