using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    /// <summary>
    /// This is the main entity in the Registry. It contains the name, the date it became a Soul Reaper, whether it's alive or not, where it belongs to, the name of the weapon and whether it has achieved higher power of said weapon - plus some other miscellaneous information.
    /// </summary>
    public class SoulReaper
    {
        [Key]
        public int SRId { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? EnrollDate { get; set; }
        public bool Available { get; set; }

        [ForeignKey("DivisionId")]
        public int? DivisionId { get; set; }
        public Division Division { get; set; }

        [ForeignKey("SpecialDivision")]
        public int? SpecialDivisionId { get; set; }
        public SpecialDivision SpecialDivision { get; set; }

        public string WeaponName { get; set; }

        [ForeignKey("WeaponPower")]
        public int? WeaponPowerId { get; set; }
        public WeaponPower WeaponPowers { get; set; }

        public string? Description { get; set; }


        public SoulReaper()
        {
            this.Hollows = new List<Hollow>();
        }
        public ICollection<Hollow> Hollows { get; set; }

    }
}
