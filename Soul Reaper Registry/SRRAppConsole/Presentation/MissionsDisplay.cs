using Business.Models;
using Data.Models;
using SRRAppConsole.Presentation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRRAppConsole
{
    public class MissionsDisplay : Display
    {
        MisBusiness misBusiness = new MisBusiness();
        public override void ShowMenu()
        {
            Console.WriteLine(new string('-', 40));
            Console.WriteLine(@" Missions ");
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
            Console.WriteLine(@" Missions ");
            Console.WriteLine(new string('-', 40));
            var miss = misBusiness.GetAll();
            foreach (var item in miss)
            {
                Console.WriteLine($"Id: {item.MId}| Name: {item.Name}| Date Completed: {item.DateCompleted}| Description: {item.Description}|");
            }
        }
        public override void Add()
        {
            string data;
            Missions missions = new Missions();

            Console.Write("Name: ");
            missions.Name = Console.ReadLine();

            Console.Write("Date Complete: ");
            data = Console.ReadLine();
            if (EmptyStringChecker(data)) missions.DateCompleted = DateTime.Parse(data);

            Console.Write("Description: ");
            data = Console.ReadLine();
            if (EmptyStringChecker(data)) missions.Description = data;

            misBusiness.Add(missions);
            Console.WriteLine("The Mission has been added!");
        }
        public override void Update()
        {
            string data;
            Console.Write("Id: ");
            int id = int.Parse(Console.ReadLine());
            Missions missions = misBusiness.Get(id);
            if (missions != null)
            {
                Console.Write("Name: ");
                missions.Name = Console.ReadLine();

                Console.Write("Date Complete: ");
                data = Console.ReadLine();
                if (EmptyStringChecker(data)) missions.DateCompleted = DateTime.Parse(data);

                Console.Write("Description: ");
                data = Console.ReadLine();
                if (EmptyStringChecker(data)) missions.Description = data;

                misBusiness.Update(missions);
                Console.WriteLine("The Mission has been updated!");
            }
            else
            {
                Console.WriteLine("Mission not found!");
            }
        }
        public override void Fetch()
        {
            Console.Write("Id: ");
            int id = int.Parse(Console.ReadLine());
            Missions missions = misBusiness.Get(id);
            if (missions != null)
            {
                Console.WriteLine(new string('-', 40));

                Console.WriteLine("ID: " + missions.MId);
                Console.WriteLine("Name: " + missions.Name);
                Console.WriteLine("Date Completed: " + missions.DateCompleted);
                Console.WriteLine("Description: " + missions.Description);

                Console.WriteLine(new string('-', 40));
            }
            else
            {
                Console.WriteLine("Mission not found!");
            }
        }
        public override void Delete()
        {
            Console.Write("Id: ");
            int id = int.Parse(Console.ReadLine());
            Missions missions = misBusiness.Get(id);
            if (missions != null)
            {
                misBusiness.Delete(id);
                Console.WriteLine("The Mission has been deleted!");
            }
            else
            {
                Console.WriteLine("Mission not found!");
            }
        }
    }
}
