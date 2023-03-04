
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRRAppConsole.Presentation
{
    public abstract class Display
    {
        private int closeOperationId = 6;
        private int operation = -1;
        public Display()
        {
            Input();
        }
        public virtual void ShowMenu() { }
        public void Input()
        {
            do
            {
                if (operation != closeOperationId)
                {
                    ShowMenu();
                    operation = int.Parse(Console.ReadLine());
                    switch (operation)
                    {
                        case 1:
                            ListAll();
                            break;
                        case 2:
                            Add();
                            break;
                        case 3:
                            Update();
                            break;
                        case 4:
                            Fetch();
                            break;
                        case 5:
                            Delete();
                            break;
                        case 6:
                           // StartUp.MainMenu();
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
        public virtual void ListAll() { }
        public static bool EmptyStringChecker(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                return false;
            }
            return true;
        }
        public virtual void Add() { }
        public virtual void Update() { }
        public virtual void Fetch() { }
        public virtual void Delete() { }

    }
}
