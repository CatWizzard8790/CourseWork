using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.CompilerServices;
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
            int closeOperationId = 10;

            // Reads the input and sends it to the coresponding class/method
            do
            {
                if (operation != closeOperationId)
                {
                    MainMenu();
                    Display display;
                    operation = int.Parse(Console.ReadLine());
                    Console.Beep();
                    switch (operation)
                    {
                        case 1:
                            display = new SoulReaperDisplay();
                            break;
                        case 2:
                            display = new DivisionDisplay();
                            break;
                        case 3:
                            display = new SpecialDivisionDisplay();
                            break;
                        case 4:
                            display = new WeaponPowerDisplay();
                            break;
                        case 5:
                            display = new HollowDisplay();
                            break;
                        case 6:
                            display = new HollowClassificationDisplay();
                            break;
                        case 7:
                            Environment.Exit(0);
                            break;
                        default:
                            break;
                    }
                }
                else
                {
                    Console.Clear();
                }

                if (operation != closeOperationId)
                {
                    Console.WriteLine("Press any key...");
                    Console.ReadKey();
                    Console.Clear();
                }
            } while (operation != closeOperationId);

        }

        // Shows the main user menu on the console
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
            Console.WriteLine("2. Division");
            Console.WriteLine("3. Special Division");
            Console.WriteLine("4. Weapon Powers");
            Console.WriteLine("5. Hollow");
            Console.WriteLine("6. Hollow Classifications");
            Console.WriteLine("7. Close Application");
        }
    }
}
