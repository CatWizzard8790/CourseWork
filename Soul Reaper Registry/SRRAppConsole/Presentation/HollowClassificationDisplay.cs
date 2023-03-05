using Business.Models;
using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRRAppConsole.Presentation
{
    public class HollowClassificationDisplay : Display
    {
        HCBusiness hCBusiness = new HCBusiness();
        public override void ShowMenu()
        {
            Console.WriteLine(new string('-', 40));
            Console.WriteLine(@"                         _                 _                        
 |_|  _  | |  _         /  |  _.  _  _ o _|_ o  _  _. _|_ o  _  ._  
 | | (_) | | (_) \/\/   \_ | (_| _> _> |  |  | (_ (_|  |_ | (_) | | ");
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
            Console.WriteLine(@"                         _                 _                        
 |_|  _  | |  _         /  |  _.  _  _ o _|_ o  _  _. _|_ o  _  ._  
 | | (_) | | (_) \/\/   \_ | (_| _> _> |  |  | (_ (_|  |_ | (_) | | ");
            Console.WriteLine(new string('-', 40));
            var hcs = hCBusiness.GetAll();
            foreach (var item in hcs)
            {
                Console.WriteLine($"Id: {item.HCId}| Name: {item.Name}| Description: {item.Description}|");
            }
        }
        public override void Add()
        {
            string data;
            HollowClassifications hollowClassifications = new HollowClassifications();

            Console.Write("Name: ");
            hollowClassifications.Name = Console.ReadLine();            

            Console.Write("Description: ");
            data = Console.ReadLine();
            if (EmptyStringChecker(data)) hollowClassifications.Description = data;

            hCBusiness.Add(hollowClassifications);
            Console.WriteLine("The Hollow Classification has been added!");
        }
        public override void Update()
        {
            string data;
            Console.Write("Id: ");
            int id = int.Parse(Console.ReadLine());
            HollowClassifications hollow = hCBusiness.Get(id);
            if (hollow != null)
            {
                Console.Write("Name: ");
                hollow.Name = Console.ReadLine();

                Console.Write("Description: ");
                data = Console.ReadLine();
                if (EmptyStringChecker(data)) hollow.Description = data;

                hCBusiness.Update(hollow);
                Console.WriteLine("The Hollow Classification has been updated!");
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
            HollowClassifications hcs = hCBusiness.Get(id);
            if (hcs != null)
            {
                Console.WriteLine(new string('-', 40));

                Console.WriteLine("Id: " + hcs.HCId);
                Console.WriteLine("Name: " + hcs.Name);
                Console.WriteLine("Description: " + hcs.Description);

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
            HollowClassifications hollow = hCBusiness.Get(id);
            if (hollow != null)
            {
                hCBusiness.Delete(id);
                Console.WriteLine("The Hollow Classification has been deleted!");
            }
            else
            {
                Console.WriteLine("Hollow Classification not found!");
            }
        }

    }
}
