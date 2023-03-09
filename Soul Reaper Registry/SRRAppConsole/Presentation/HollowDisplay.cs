using Business.Models;
using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRRAppConsole.Presentation
{
    public class HollowDisplay : Display
    {
        HBusiness hBusiness = new HBusiness();
        public override void ShowMenu()
        {
            Console.WriteLine(new string('-', 35));
            Console.WriteLine(@"  _   _       _ _               
 | | | | ___ | | | _____      __
 | |_| |/ _ \| | |/ _ \ \ /\ / /
 |  _  | (_) | | | (_) \ V  V / 
 |_| |_|\___/|_|_|\___/ \_/\_/  ");
            Console.WriteLine(new string('-', 35));
            Console.WriteLine("1. List all entries");
            Console.WriteLine("2. Add new entry");
            Console.WriteLine("3. Update entry");
            Console.WriteLine("4. Fetch entry by ID");
            Console.WriteLine("5. Delete entry by ID");
            Console.WriteLine("6. Exit entry");
        }
        public override void ListAll()
        {
            Console.WriteLine(new string('-', 25));
            Console.WriteLine(@"|_| _  |  |  _     _ 
| |(_) |  | (_)\^/_> ");
            Console.WriteLine(new string('-', 25));
            var hcs = hBusiness.GetAll();
            foreach (var item in hcs)
            {
                Console.WriteLine($"Id: {item.HId}| Name: {item.Name}| Class Id: {item.ClassId}| Weapon Power Id: {item.WeaponPowerId} Description: {item.Description}|");
            }
        }
        public override void Add()
        {
            string data;
            Hollow hollows = new Hollow();

            Console.Write("Name: ");
            hollows.Name = Console.ReadLine();

            Console.Write("Class Id");
            hollows.ClassId = int.Parse(Console.ReadLine());

            Console.Write("Weapon Power Id: ");
            data = Console.ReadLine();
            if (EmptyStringChecker(data)) hollows.WeaponPowerId = int.Parse(data);

            Console.Write("Description: ");
            data = Console.ReadLine();
            if (EmptyStringChecker(data)) hollows.Description = data;

            hBusiness.Add(hollows);
            Console.WriteLine("The Hollow has been added!");
        }
        public override void Update()
        {
            string data;
            Console.Write("Id: ");
            int id = int.Parse(Console.ReadLine());
            Hollow hollow = hBusiness.Get(id);
            if (hollow != null)
            {
                Console.Write("Name: ");
                hollow.Name = Console.ReadLine();

                Console.Write("Class Id");
                hollow.ClassId = int.Parse(Console.ReadLine());

                Console.Write("Weapon Power Id: ");
                data = Console.ReadLine();
                if (EmptyStringChecker(data)) hollow.WeaponPowerId = int.Parse(data);

                Console.Write("Description: ");
                data = Console.ReadLine();
                if (EmptyStringChecker(data)) hollow.Description = data;

                hBusiness.Update(hollow);
                Console.WriteLine("The Hollow has been updated!");
            }
            else
            {
                Console.WriteLine("Hollow not found!");
            }
        }
        public override void Fetch()
        {
            Console.Write("Id: ");
            int id = int.Parse(Console.ReadLine());
            Hollow hcs = hBusiness.Get(id);
            if (hcs != null)
            {
                Console.WriteLine(new string('-', 40));

                Console.WriteLine("ID: " + hcs.HId);
                Console.WriteLine("Name: " + hcs.Name);
                Console.WriteLine("Class Id: " + hcs.ClassId);
                Console.WriteLine("WeaPon Power Id: " + hcs.WeaponPowerId);
                Console.WriteLine("Description: " + hcs.Description);

                Console.WriteLine(new string('-', 40));
            }
            else
            {
                Console.WriteLine("Hollow not found!");
            }
        }
        public override void Delete()
        {
            Console.Write("Id: ");
            int id = int.Parse(Console.ReadLine());
            Hollow hollow = hBusiness.Get(id);
            if (hollow != null)
            {
                hBusiness.Delete(id);
                Console.WriteLine("The Hollow has been deleted!");
            }
            else
            {
                Console.WriteLine("Hollow not found!");
            }
        }
    }
}
