using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SRRAppConsole.Presentation;

namespace SRRAppConsole
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var operation = -1;
            int closeOperationId = 9;
            do
            {
                MainMenu();
                Display display;
                operation = int.Parse(Console.ReadLine());
                switch (operation)
                {
                    case 1:
                        display = new SoulReaperDisplay();
                        break;
                    case 2:
                        display = new DivisionDisplay();
                        break;
                    case 3:
                         display = new SpecialDivisionsDisplay(); 
                        break;
                    case 4:
                        
                        break;
                    case 5:
                        display = new HollowsDisplay();
                        break;
                    case 6:
                        display = new HollowClassificationDisplay();
                        break;
                    case 7:
//                        display = ;
                        break;
                    case 8:
                       // display = ;
                        break;
                    case 9:
                        display = new MissionsDisplay();
                        break;
                    default:
                        break;
                }
                Console.WriteLine("Press any key..."); Console.ReadKey(); Console.Clear();
            } while (operation != closeOperationId);
        }


        SoulReaperDisplay display = new SoulReaperDisplay();

        public static void MainMenu()
        {
            Console.WriteLine(new string('=', 100));
            Console.WriteLine(@"   _____             _   _____                              _____            _     _              
  / ____|           | | |  __ \                            |  __ \          (_)   | |             
 | (___   ___  _   _| | | |__) |___  __ _ _ __   ___ _ __  | |__) |___  __ _ _ ___| |_ _ __ _   _ 
  \___ \ / _ \| | | | | |  _  // _ \/ _` | '_ \ / _ | '__| |  _  // _ \/ _` | / __| __| '__| | | |
  ____) | (_) | |_| | | | | \ |  __| (_| | |_) |  __| |    | | \ |  __| (_| | \__ | |_| |  | |_| |
 |_____/ \___/ \__,_|_| |_|  \_\___|\__,_| .__/ \___|_|    |_|  \_\___|\__, |_|___/\__|_|   \__, |
                                         | |                            __/ |                __/ |
                                         |_|                           |___/                |___/ ");
            Console.WriteLine(new string('=', 100));
            Console.WriteLine("1. Soul Reapers");
            Console.WriteLine("2. Divisions");
            Console.WriteLine("3. Special Divisions");
            Console.WriteLine("4. Weapon Powers");
            Console.WriteLine("5. Hollows");
            Console.WriteLine("6. Hollow Classification");
            Console.WriteLine("7. Soul Reapers Missions");
            Console.WriteLine("8. Hollows Missions");
            Console.WriteLine("9. Missions");
        }
    }
}
