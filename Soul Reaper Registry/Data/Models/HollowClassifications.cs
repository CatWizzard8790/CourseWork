using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    /// <summary>
    /// There are multiple types of hollows, depending on its stage of evolution. Each one has a name and different characteristics.
    /// </summary>
    public class HollowClassifications
    {
        [Key]
        public int HCId { get; set; }

        public string Name { get; set; }
        public string? Description { get; set; }
    }
}
