using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soul_Reaper_Registry
{
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
        public string Descriptiong { get; private set; }

    }
}
