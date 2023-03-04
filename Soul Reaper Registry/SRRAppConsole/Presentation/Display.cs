﻿using System;
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
            Console.WriteLine(new string('=', 40));
            Console.WriteLine(@"  __              _                       
 (_   _      |   |_)  _   _. ._   _  ._ _ 
 __) (_) |_| |   | \ (/_ (_| |_) (/_ | _> 
                             |            ");
            Console.WriteLine(new string('=', 40));
            var products = sRRBusiness.GetAll();
            foreach (var item in products)
            {
                Console.WriteLine($"{item.SRId} {item.FirstName} {item.LastName} {item.WeaponName}");
            }

        }

        private void Add()
        {
            SoulReapers sr = new SoulReapers();
            Console.Write("First Name: ");
            sr.FirstName = Console.ReadLine();
            Console.Write("Last Name: ");
            sr.LastName = Console.ReadLine();
            Console.Write("Weapon Name: ");
            sr.WeaponName = Console.ReadLine();
            sRRBusiness.Add(sr);
            Console.WriteLine("The Soul Reaper has been added!");
        }

        private void Update()
        {
            Console.Write("Id: ");
            int id = int.Parse(Console.ReadLine());
            SoulReapers product = sRRBusiness.Get(id);
            if (product != null)
            {
                Console.WriteLine($"{product.SRId} {product.FirstName} {product.LastName} {product.WeaponName}");
                Console.Write("First Name: ");
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
