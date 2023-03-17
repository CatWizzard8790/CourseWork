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
    /// Hollows are a race of creatures which are born from Human souls and have a name and a class- depending on the stage that it has evolved to. Their "Alive" status can change- depending on wheither or not they were involved in the table "Missions".
    /// Not all hollows have Powers(WeaponPowerId).
    /// </summary>
    public class Hollow
    {
        [Key]
        public int HId { get; set; }

        public string Name { get; set; }

        [ForeignKey("ClassificationId")]
        public int ClassId { get; set; }
        public HollowClassification HollowClassification { get; set; }

        [ForeignKey("WeaponPowerId")]
        public int? WeaponPowerId { get; set; }
        public WeaponPower WeaponPower { get; set; }

        public string? Description { get; set; }

        [ForeignKey("SoulReaperId")]
        public int? SRId { get; set; }
        public SoulReaper SoulReaper { get; set; }
    }
}
