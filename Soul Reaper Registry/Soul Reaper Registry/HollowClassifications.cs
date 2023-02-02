using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soul_Reaper_Registry
{
    /// <summary>
    /// There are multiple types of hollows, depending on its stage of evolution. Each one has a name and different characteristics.
    /// </summary>
    class HollowClassifications
    {
        public int HCId { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
    }
}
