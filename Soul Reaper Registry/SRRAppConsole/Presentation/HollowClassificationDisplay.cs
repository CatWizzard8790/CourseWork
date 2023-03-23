using Business.Models;
using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRRAppConsole.Presentation
{
    /// <summary>
    /// Implements the CRUD methods from Display for Hollow Classification.
    /// </summary>
    public class HollowClassificationDisplay : Display
    {
        HCBusiness hCBusiness = new HCBusiness();
        public override void ShowMenu()
        {
            Console.WriteLine(new string('-', 95));
            Console.WriteLine(@"  _   _       _ _                  ____ _               _  __ _           _   _             
 | | | | ___ | | | _____      __  / ___| | __ _ ___ ___(_)/ _(_) ___ __ _| |_(_) ___  _ __  
 | |_| |/ _ \| | |/ _ \ \ /\ / / | |   | |/ _` / __/ __| | |_| |/ __/ _` | __| |/ _ \| '_ \ 
 |  _  | (_) | | | (_) \ V  V /  | |___| | (_| \__ \__ \ |  _| | (_| (_| | |_| | (_) | | | |
 |_| |_|\___/|_|_|\___/ \_/\_/    \____|_|\__,_|___/___/_|_| |_|\___\__,_|\__|_|\___/|_| |_|");
            Console.WriteLine(new string('-', 95));
            Console.WriteLine("1. List all entries");
            Console.WriteLine("2. Add new entry");
            Console.WriteLine("3. Update entry");
            Console.WriteLine("4. Fetch entry by ID");
            Console.WriteLine("5. Delete entry by ID");
            Console.WriteLine("6. Exit entry");
        }
        public override void ListAll()
        {
            Console.WriteLine(new string('-', 70));
            Console.WriteLine(@"                      __                 _                        
|_| _  |  |  _       /   |  _  _  _  o _|_ o  _  _ _|_ o  _ __  _ 
| |(_) |  | (_)\^/   \__ | (_|_> _>  |  |  | (_ (_| |_ | (_)| |_> ");
            Console.WriteLine(new string('-', 70));
            var hcs = hCBusiness.GetAll();
            foreach (var item in hcs)
            {
                Console.WriteLine($"Id: {item.HCId}| Name: {item.Name}| Description: {item.Description}|");
            }
        }
        public override void Add()
        {
            string data;
            HollowClassification hollowClassifications = new HollowClassification();

            Console.Write("Name*: ");
            hollowClassifications.Name = Console.ReadLine();            

            Console.Write("Description: ");
            data = Console.ReadLine();
            if (EmptyStringChecker(data)) hollowClassifications.Description = data;

            try
            {
                hCBusiness.Add(hollowClassifications);
                Console.WriteLine("The Hollow Classification has been added!");
            }
            catch (Exception e)
            {
                Console.WriteLine("Error! Incorrect data!");
            }
        }
        public override void Update()
        {
            string data;
            Console.Write("Id: ");
            int id = int.Parse(Console.ReadLine());
            HollowClassification hollow = hCBusiness.Get(id);
            if (hollow != null)
            {
                Console.Write("*Name: ");
                hollow.Name = Console.ReadLine();

                Console.Write("Description: ");
                data = Console.ReadLine();
                if (EmptyStringChecker(data)) hollow.Description = data;

                try
                {
                    hCBusiness.Update(hollow);
                    Console.WriteLine("The Hollow Classification has been updated!");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error! Incorrect data!");
                }
            }
            else
            {
                Console.WriteLine("Hollow Classification not found!");
            }
        }
        public override void Fetch()
        {
            Console.Write("Id: ");
            int id = int.Parse(Console.ReadLine());
            HollowClassification hcs = sRRContext.HollowClassification.Find(id);
            sRRContext.Entry(hcs).Collection(hw => hw.Hollows).Load();

            if (hcs != null)
            {
                Console.WriteLine(new string('-', 40));

                Console.WriteLine("Id: " + hcs.HCId);
                Console.WriteLine("Name: " + hcs.Name);
                Console.WriteLine("Description: " + hcs.Description);

                Console.WriteLine(new string('-', 40));

                Console.WriteLine($"Hollows with this Classification: {hcs.Hollows.Count}\n");

                int counter = 1;
                foreach (var srr in hcs.Hollows)
                {
                    Console.WriteLine($"{counter}. Id: {srr.SRId} Name: {(srr.Name == null ? " " : srr.Name)}");
                    counter++;
                }

                Console.WriteLine(new string('-', 40));
            }
            else
            {
                Console.WriteLine("Hollow Classification not found!");
            }
        }
        public override void Delete()
        {
            Console.Write("Id: ");
            int id = int.Parse(Console.ReadLine());
            HollowClassification hollow = hCBusiness.Get(id);
            if (hollow != null)
            {
                try
                {
                    hCBusiness.Delete(id);
                    Console.WriteLine("The Hollow Classification has been deleted!");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error! Cannot delete item!");
                }
            }
            else
            {
                Console.WriteLine("Hollow Classification not found!");
            }
        }

    }
}
