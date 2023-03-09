using Business.Models;
using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRRAppConsole.Presentation
{
    public class SpecialDivisionDisplay : Display
    {
        SPDivBusiness sPDBusiness = new SPDivBusiness();
        public override void ShowMenu()
        {
            Console.WriteLine(new string('-', 40));
            Console.WriteLine(@" Special Divisions ");
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
            Console.WriteLine(@" Special Divisions ");
            Console.WriteLine(new string('-', 40));
            var SDiv = sPDBusiness.GetAll();
            foreach (var item in SDiv)
            {
                Console.WriteLine($"Special Division Id: {item.SDId}| Name: {item.Name}| Leader Id: {item.LeaderId}| Division Id: {item.DivisionId}| Description: {item.Description}|");
            }
        }
        public override void Add()
        {
            string data;
            SpecialDivision SPdiv = new SpecialDivision();

            Console.Write("Name: ");
            SPdiv.Name = Console.ReadLine();

            Console.Write("Leader Id: ");
            data = Console.ReadLine();
            if (EmptyStringChecker(data)) SPdiv.LeaderId = int.Parse(data);

            Console.Write("Division Id: ");
            data = Console.ReadLine();
            if (EmptyStringChecker(data)) SPdiv.DivisionId = int.Parse(data);

            Console.Write("Description: ");
            data = Console.ReadLine();
            if (EmptyStringChecker(data)) SPdiv.Description = data;

            sPDBusiness.Add(SPdiv);
            Console.WriteLine("The Special Division has been added!");
        }
        public override void Update()
        {
            string data;
            Console.Write("Id: ");
            int id = int.Parse(Console.ReadLine());
            SpecialDivision SPDiv = sPDBusiness.Get(id);
            if (SPDiv != null)
            {
                Console.Write("Name: ");
                SPDiv.Name = Console.ReadLine();

                Console.Write("Leader Id: ");
                data = Console.ReadLine();
                if (EmptyStringChecker(data)) SPDiv.LeaderId = int.Parse(data);

                Console.Write("Division Id: ");
                data = Console.ReadLine();
                if (EmptyStringChecker(data)) SPDiv.DivisionId = int.Parse(data);

                Console.Write("Description: ");
                data = Console.ReadLine();
                if (EmptyStringChecker(data)) SPDiv.Description = data;

                sPDBusiness.Update(SPDiv);
                Console.WriteLine("The Special Division has been updated!");
            }
            else
            {
                Console.WriteLine("Special Division not found!");
            }
        }
        public override void Fetch()
        {
            Console.Write("Id: ");
            int id = int.Parse(Console.ReadLine());
            SpecialDivision SPDs = sPDBusiness.Get(id);
            if (SPDs != null)
            {
                Console.WriteLine(new string('-', 40));

                Console.WriteLine("Special Division Id: " + SPDs.SDId);
                Console.WriteLine("Name: " + SPDs.Name);
                Console.WriteLine("Leader Id: " + SPDs.LeaderId);
                Console.WriteLine("Division Id: " + SPDs.DivisionId);
                Console.WriteLine("Description: " + SPDs.Description);

                Console.WriteLine(new string('-', 40));
            }
            else
            {
                Console.WriteLine("Special Division not found!");
            }
        }
        public override void Delete()
        {
            Console.Write("Id: ");
            int id = int.Parse(Console.ReadLine());
            SpecialDivision SPDS = sPDBusiness.Get(id);
            if (SPDS != null)
            {
                sPDBusiness.Delete(id);
                Console.WriteLine("The Special Division has been deleted!");
            }
            else
            {
                Console.WriteLine("Special Division not found!");
            }
        }
    }
}
