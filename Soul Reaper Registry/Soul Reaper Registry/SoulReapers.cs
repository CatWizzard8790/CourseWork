using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soul_Reaper_Registry
{
    /// <summary>
    /// This is the main entity in the Registry. It contains the name, the date it became a Soul Reaper, whether it's alive or not, where it belongs to, the name of the weapon and whether it has achieved higher power of said weapon - plus some other miscellaneous information.
    /// </summary>
    class SoulReapers
    {
        public int SRId { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public DateTime EnrollDate { get; private set; }
        public bool Available { get; private set; }
        public int DivisionId { get; private set; }
        public int SpecialId { get; private set; }
        public string WeaponName { get; private set; }
        public int WeaponPowerId { get; private set; }
        public string Description { get; private set; }

    }
}
