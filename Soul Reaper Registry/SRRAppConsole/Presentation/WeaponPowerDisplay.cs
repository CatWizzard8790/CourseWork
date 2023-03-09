using Business.Models;
using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRRAppConsole.Presentation
{
    public class WeaponPowerDisplay : Display
    {
        WPBusiness wPBusiness = new WPBusiness();
        public override void ShowMenu()
        {
            Console.WriteLine(new string('-', 70));
            Console.WriteLine(@" __        __                             ____                        
 \ \      / /__  __ _ _ __   ___  _ __   |  _ \ _____      _____ _ __ 
  \ \ /\ / / _ \/ _` | '_ \ / _ \| '_ \  | |_) / _ \ \ /\ / / _ \ '__|
   \ V  V /  __/ (_| | |_) | (_) | | | | |  __/ (_) \ V  V /  __/ |   
    \_/\_/ \___|\__,_| .__/ \___/|_| |_| |_|   \___/ \_/\_/ \___|_|   
                     |_|                                              ");
            Console.WriteLine(new string('-', 70));
            Console.WriteLine("1. List all entries");
            Console.WriteLine("2. Add new entry");
            Console.WriteLine("3. Update entry");
            Console.WriteLine("4. Fetch entry by ID");
            Console.WriteLine("5. Delete entry by ID");
            Console.WriteLine("6. Exit entry");
        }
        public override void ListAll()
        {
            Console.WriteLine(new string('-', 50));
            Console.WriteLine(@"                             _                   
 \    / _   _. ._   _  ._   |_) _        _  ._ _ 
  \/\/ (/_ (_| |_) (_) | |  |  (_) \/\/ (/_ | _> 
               |                                 ");
            Console.WriteLine(new string('-', 50));
            var WPs = wPBusiness.GetAll();
            foreach (var item in WPs)
            {
                Console.WriteLine($"Wepon Power Id: {item.WPId}| First Form: {item.FirstForm}| Second Form: {item.SecondForm}| Power type: {item.PType}| Description: {item.Description}|");
            }
        }
        public override void Add()
        {
            string data;
            WeaponPower WPs = new WeaponPower();

            Console.Write("First Form: ");
            WPs.FirstForm = Console.ReadLine();

            Console.Write("Second Form: ");
            WPs.SecondForm = Console.ReadLine();

            Console.Write("Power Type: ");
            Console.Write("Choose one : 1.Bankai | 2.Resurreccion | 3.Other ");
            WPs.PType = (PowerType)int.Parse(Console.ReadLine()) - 1;            

            Console.Write("Description: ");
            data = Console.ReadLine();
            if (EmptyStringChecker(data)) WPs.Description = data;

            wPBusiness.Add(WPs);
            Console.WriteLine("The Weapon Power has been added!");
        }
        public override void Update()
        {
            string data;
            Console.Write("Id: ");
            int id = int.Parse(Console.ReadLine());
            WeaponPower WPs = wPBusiness.Get(id);
            if (WPs != null)
            {
                Console.Write("First Form: ");
                WPs.FirstForm = Console.ReadLine();

                Console.Write("Second Form: ");
                WPs.SecondForm = Console.ReadLine();

                Console.Write("Power Type: ");
                Console.Write("Choose one : 1.Bankai | 2.Resurreccion | 3.Other ");
                WPs.PType = (PowerType)int.Parse(Console.ReadLine()) - 1;

                Console.Write("Description: ");
                data = Console.ReadLine();
                if (EmptyStringChecker(data)) WPs.Description = data;

                wPBusiness.Update(WPs);
                Console.WriteLine("The Weapon Power has been updated!");
            }
            else
            {
                Console.WriteLine("Weapon Power not found!");
            }
        }
        public override void Fetch()
        {
            Console.Write("Id: ");
            int id = int.Parse(Console.ReadLine());
            WeaponPower WPs = wPBusiness.Get(id);
            if (WPs != null)
            {
                Console.WriteLine(new string('-', 40));

                Console.WriteLine("Weapon Power Id: " + WPs.WPId);
                Console.WriteLine("First Form: " + WPs.FirstForm);
                Console.WriteLine("Second Form: " + WPs.SecondForm);
                Console.WriteLine("Description: " + WPs.Description);

                Console.WriteLine(new string('-', 40));
            }
            else
            {
                Console.WriteLine("Weapon Power not found!");
            }
        }
        public override void Delete()
        {
            Console.Write("Id: ");
            int id = int.Parse(Console.ReadLine());
            WeaponPower WPs = wPBusiness.Get(id);
            if (WPs != null)
            {
                wPBusiness.Delete(id);
                Console.WriteLine("The Weapon Power has been deleted!");
            }
            else
            {
                Console.WriteLine("Weapon Power not found!");
            }
        }
    }
}
