using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    /// <summary>
    /// Both Soul Reapers and Hollows could achieve different Weapon Powers. A Singular weapon could have up to two forms, a Hollow's second form is a "Resurreccion" and a Soul Reaper's is "Bankai"- everything else falls under the "Other" category.
    /// </summary>
    public class WeaponPower
    {
        [Key]
        public int WPId { get; set; }

        public string FirstForm { get; set; }
        public string? SecondForm { get; set; }
        public PowerType PType { get; set; }
        public string? Description { get; set; }

    }
}
