using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    /// <summary>
    /// Intermediate table for Hollows and Missions, allowing the Many to Many relation. It also has information about whether the Hollow is dead or alive
    /// </summary>
    public class MissionsHollows
    {
        [Key]
        public int MissionsId { get; set; }

        public int HollowsId { get; set; }
        public bool HollowStatus { get; set; }
    }
}
