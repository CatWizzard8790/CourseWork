using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soul_Reaper_Registry
{
    /// <summary>
    /// A Special Division is a group of Soul Reapers that is different from the Thirteen Court Guard Squads(class Divisions). It contains the name of the Special Division, miscellaneous information and it could have a leader and be independent of one of the main 13 divisions. If the leader is a captain of a Division, all members fall under that Division.
    /// </summary>
    public class SpecialDivisions
    {
        public int SDId { get; private set; }
        public string Name { get; private set; }
        public int LeaderId { get; private set; }
        public string Description { get; private set; }
        public int DivisionId { get; private set; }
    }
}
