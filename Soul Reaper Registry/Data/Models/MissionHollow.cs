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
    /// Intermediate table for Hollows and Missions, allowing the Many to Many relation.
    /// </summary>
    public class MissionHollow
    {
        [Key]
        public int MissionsId { get; set; }

        [ForeignKey("HollowId")]
        public int HollowsId { get; set; }
        public Hollow Hollow { get; set; }
    }
}
