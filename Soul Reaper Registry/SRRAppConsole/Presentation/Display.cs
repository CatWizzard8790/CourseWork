using System;
using Business;
using Data.Models;

namespace SRRAppConsole.Presentation
{
    public class Display
    {
        private int closeOperationId = 6;
        SRRBusiness sRRBusiness = new SRRBusiness();

        public Display()
        {
            Input();
        }

        private void ShowMenu()
        {
            Console.WriteLine(new string('-', 80));
            Console.WriteLine(new string(' ', 18) + "Soul Reaper Registry");
            Console.WriteLine(new string('-', 80));
            Console.WriteLine("1. List all entries");
            Console.WriteLine("2. Add new entry");
            Console.WriteLine("3. Update entry");
            Console.WriteLine("4. Fetch entry by ID");
            Console.WriteLine("5. Delete entry by ID");
            Console.WriteLine("6. Exit entry");
        }

        private void Input()
        {
            var operation = -1;
            do
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
                    default:
                        break;
                }
                Console.WriteLine("Press any key..."); Console.ReadKey(); Console.Clear();
            } while (operation != closeOperationId);
        }

        private void ListAll()
        {
            Console.WriteLine(new string('-', 40));
            Console.WriteLine(new string(' ', 18) + "PRODUCTS");
            Console.WriteLine(new string('-', 40));
            var products = sRRBusiness.GetAll();
            foreach (var item in products)
            {
                Console.WriteLine($"{item.SRId} {item.FirstName} {item.LastName} {item.WeaponName}");
            }

        }

        private void Add()
        {
            SoulReapers product = new SoulReapers();
            Console.Write("Name: ");
            product.FirstName = Console.ReadLine();
            Console.Write("Price: ");
            product.LastName = Console.ReadLine();
            Console.Write("Stock: ");
            product.WeaponName = Console.ReadLine();
            sRRBusiness.Add(product);
            Console.WriteLine("The product has been added!");
        }

        private void Update()
        {
            Console.Write("Id: ");
            int id = int.Parse(Console.ReadLine());
            SoulReapers product = sRRBusiness.Get(id);
            if (product != null)
            {
                Console.WriteLine($"{product.SRId} {product.FirstName} {product.LastName} {product.WeaponName}");
                Console.Write("Name: ");
                product.FirstName = Console.ReadLine();
                Console.Write("Last Name: ");
                product.LastName = Console.ReadLine();
                Console.Write("Weapon Name: ");
                product.WeaponName = Console.ReadLine();
                sRRBusiness.Update(product);
                Console.WriteLine("The Soul Reaper has been updated!");
            }
            else
            {
                Console.WriteLine("Soul Reaper not found!");
            }
        }

        private void Fetch()
        {
            Console.Write("Id: ");
            int id = int.Parse(Console.ReadLine());
            SoulReapers product = sRRBusiness.Get(id);
            if (product != null)
            {
                Console.WriteLine(new string('-', 40));
                Console.WriteLine("ID: " + product.SRId);
                Console.WriteLine("Name: " + product.FirstName);
                Console.WriteLine("Last Name: " + product.LastName);
                Console.WriteLine("Weapon Name: " + product.WeaponName);
                Console.WriteLine(new string('-', 40));
            }
            else
            {
                Console.WriteLine("Soul Reaper not found!");
            }
        }

        private void Delete()
        {
            Console.Write("Id: ");
            int id = int.Parse(Console.ReadLine());
            SoulReapers product = sRRBusiness.Get(id);
            if (product != null)
            {
                sRRBusiness.Delete(id);
                Console.WriteLine("The Soul Reaper has been deleted!");
            }
            else
            {
                Console.WriteLine("Soul Reaper not found!");
            }
        }
    }
}
