using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soul_Reaper_Registry
{
    /// <summary>
    /// Both Soul Reapers and Hollows could achieve different Weapon Powers. A Singular weapon could have up to two forms, a Hollow's second form is a "Resurreccion" and a Soul Reaper's is "Bankai"- everything else falls under the "Other" category.
    /// </summary>
    public class WeaponPowers
    {
        public int WPId { get; private set; }
        public string FirstForm { get; private set; }
        public string SecondForm { get; private set; }
        public PowerType PType { get; private set; }

    }
}
