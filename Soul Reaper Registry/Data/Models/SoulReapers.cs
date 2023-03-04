using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    /// <summary>
    /// This is the main entity in the Registry. It contains the name, the date it became a Soul Reaper, whether it's alive or not, where it belongs to, the name of the weapon and whether it has achieved higher power of said weapon - plus some other miscellaneous information.
    /// </summary>
    public class SoulReapers
    {
        public int SRId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime EnrollDate { get; set; }
        public bool Available { get; set; }
        public int DivisionId { get; set; }
        public int SpecialId { get; set; }
        public string WeaponName { get; set; }
        public int WeaponPowerId { get; set; }
        public string Description { get; set; }

    }
}
