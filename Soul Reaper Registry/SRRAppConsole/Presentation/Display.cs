
using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRRAppConsole.Presentation
{
    /// <summary>
    /// The main Display class that every other Display class inherits. It supports all of the CRUD opertaions and it also defines the InputMethod class that is necessary for the connection between the console app and the Business classes.
    /// </summary>
    public abstract class Display
    {
        private int closeOperationId = 6;
        private int operation = -1;
        public SRRContext sRRContext;

        public Display()
        {
            sRRContext = new SRRContext();
            Input();
        }

        //Shows the user menu of the given entity on the console
        public virtual void ShowMenu() { }
        // Reads the Input from the console
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
        /// <summary>
        /// Returns all of the records in the given entity
        /// </summary>
        public virtual void ListAll() { }

        // Checks whether or not the given string in empty. If so it returns true; otherwise fa1se.
        public static bool EmptyStringChecker(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                return false;
            }
            return true;
        }
        /// <summary>
        /// Adds a record to the given entity
        /// </summary>
        public virtual void Add() { }
        /// <summary>
        /// Updates a record to the given entity by accesing it by its primary key
        /// </summary>
        public virtual void Update() { }
        /// <summary>
        /// Returns a singular record in the given entity by its primary key
        /// </summary>
        public virtual void Fetch() { }

        /// <summary>
        /// Deletes a singular record in the given entity by its primary key.
        /// Thows an error if the operation is unsuccesful.
        /// </summary>
        public virtual void Delete() { }

    }
}
