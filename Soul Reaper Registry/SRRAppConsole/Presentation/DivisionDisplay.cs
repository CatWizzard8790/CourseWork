using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRRAppConsole.Presentation
{
    public class DivisionDisplay : Display
    {
        public override void ShowMenu()
        {
            Console.WriteLine(new string('-', 40));
            Console.WriteLine(@"  _                         
 | \ o    o  _ o  _  ._   _ 
 |_/ | \/ | _> | (_) | | _> ");
            Console.WriteLine(new string('-', 40));
            Console.WriteLine("1. List all entries");
            Console.WriteLine("2. Add new entry");
            Console.WriteLine("3. Update entry");
            Console.WriteLine("4. Fetch entry by ID");
            Console.WriteLine("5. Delete entry by ID");
            Console.WriteLine("6. Exit entry");

        }
    }
}
