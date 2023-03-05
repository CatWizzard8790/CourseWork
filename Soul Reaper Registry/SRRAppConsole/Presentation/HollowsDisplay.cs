using Business.Models;
using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRRAppConsole.Presentation
{
    public class HollowsDisplay : Display
    {
        HBusiness hBusiness = new HBusiness();
        public override void ShowMenu()
        {
            Console.WriteLine(new string('-', 40));
            Console.WriteLine(@" Hollows ");
            Console.WriteLine(new string('-', 40));
            Console.WriteLine("1. List all entries");
            Console.WriteLine("2. Add new entry");
            Console.WriteLine("3. Update entry");
            Console.WriteLine("4. Fetch entry by ID");
            Console.WriteLine("5. Delete entry by ID");
            Console.WriteLine("6. Exit entry");
        }
        public override void ListAll()
        {
            Console.WriteLine(new string('-', 40));
            Console.WriteLine(@" Hollows ");
            Console.WriteLine(new string('-', 40));
            var hcs = hBusiness.GetAll();
            foreach (var item in hcs)
            {
                Console.WriteLine($"Id: {item.HId}| Name: {item.Name}| Class Id: {item.ClassId}| Alive: {item.Alive}| Weapon Power Id: {item.WeaponPowerId} Description: {item.Description}|");
            }
        }
        public override void Add()
        {
            string data;
            Hollows hollows = new Hollows();

            Console.Write("Name: ");
            hollows.Name = Console.ReadLine();

            Console.Write("Class Id");
            hollows.ClassId = int.Parse(Console.ReadLine());

            Console.Write("Description: ");
            data = Console.ReadLine();
            if (EmptyStringChecker(data)) hollows.Description = data;

            hBusiness.Add(hollows);
            Console.WriteLine("The Hollow has been added!");
        }
    }
}
