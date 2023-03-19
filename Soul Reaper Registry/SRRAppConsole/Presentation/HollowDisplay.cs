using Business.Models;
using Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRRAppConsole.Presentation
{
    /// <summary>
    /// Implements the CRUD methods from Display for Hollow.
    /// </summary>
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
            Console.WriteLine(new string('-', 20));
            Console.WriteLine(@"|_| _  |  |  _     _ 
| |(_) |  | (_)\^/_> ");
            Console.WriteLine(new string('-', 20));
            var hcs = hBusiness.GetAll();
            foreach (var item in sRRContext.Hollow.Include(s => s.HollowClassification).Include(s => s.WeaponPower))
            {
                Console.WriteLine($"Id: {item.HId}| Name: {item.Name}| Class: { item.HollowClassification.Name}| Weapon Power: {(item.WeaponPower == null ? " " : item.WeaponPower.FirstForm)} Description: {item.Description}|");
            }
        }
        public override void Add()
        {
            string data;
            Hollow hollows = new Hollow();

            Console.Write("Name: ");
            hollows.Name = Console.ReadLine();

            Console.Write("Class Id: ");
            hollows.HollowClassificationId = int.Parse(Console.ReadLine());

            Console.Write("Weapon Power Id: ");
            data = Console.ReadLine();
            if (EmptyStringChecker(data)) hollows.WeaponPowerId = int.Parse(data);

            Console.Write("Soul Reaper Id: ");
            data = Console.ReadLine();
            if (EmptyStringChecker(data)) hollows.SRId = int.Parse(data);

            Console.Write("Description: ");
            data = Console.ReadLine();
            if (EmptyStringChecker(data)) hollows.Description = data;

            try
            {
                hBusiness.Add(hollows);
                Console.WriteLine("The Hollow has been added!");

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                Console.WriteLine("Error! Incorrect data!");
            }
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
                hollow.HollowClassificationId = int.Parse(Console.ReadLine());

                Console.Write("Weapon Power Id: ");
                data = Console.ReadLine();
                if (EmptyStringChecker(data)) hollow.WeaponPowerId = int.Parse(data);

                Console.Write("Soul Reaper Id: ");
                data = Console.ReadLine();
                if (EmptyStringChecker(data)) hollow.SRId = int.Parse(data);

                Console.Write("Description: ");
                data = Console.ReadLine();
                if (EmptyStringChecker(data)) hollow.Description = data;

                try
                {
                    hBusiness.Update(hollow);
                    Console.WriteLine("The Hollow has been updated!");

                }
                catch (Exception)
                {
                    Console.WriteLine("Error! Incorrect data!");
                }
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
                Console.WriteLine("Class Id: " + hcs.HollowClassificationId);
                Console.WriteLine("Weapon Power Id: " + hcs.WeaponPowerId);
                Console.WriteLine("Soul Reaper Id: " + hcs.SRId);
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
                try
                {
                    hBusiness.Delete(id);
                    Console.WriteLine("The Hollow has been deleted!");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error! Cannot delete item!");
                }
            }
            else
            {
                Console.WriteLine("Hollow not found!");
            }
        }
    }
}
