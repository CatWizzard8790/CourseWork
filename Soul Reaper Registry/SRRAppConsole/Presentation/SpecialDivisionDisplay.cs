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
    public class SpecialDivisionDisplay : Display
    {
        SPDivBusiness sPDBusiness = new SPDivBusiness();
        public override void ShowMenu()
        {
            Console.WriteLine(new string('-', 70));
            Console.WriteLine(@"  ____                  _       _   ____  _       _     _             
 / ___| _ __   ___  ___(_) __ _| | |  _ \(_)_   _(_)___(_) ___  _ __  
 \___ \| '_ \ / _ \/ __| |/ _` | | | | | | \ \ / / / __| |/ _ \| '_ \ 
  ___) | |_) |  __/ (__| | (_| | | | |_| | |\ V /| \__ \ | (_) | | | |
 |____/| .__/ \___|\___|_|\__,_|_| |____/|_| \_/ |_|___/_|\___/|_| |_|
       |_|                                                            ");
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
            Console.WriteLine(@"  __                      _                         
 (_  ._   _   _ o  _. |  | \ o    o  _ o  _  ._   _ 
 __) |_) (/_ (_ | (_| |  |_/ | \/ | _> | (_) | | _> 
     |                                              ");
            Console.WriteLine(new string('-', 50));
            var SDiv = sPDBusiness.GetAll();
            foreach (var item in sRRContext.SpecialDivision.Include(s => s.SoulReapers))
            {
                Console.WriteLine($"Special Division Id: {item.SDId}| Name: {item.Name}| Leader: {(item.Leader == null ? " " : item.Leader.FirstName)} {(item.Leader == null ? " " : item.Leader.LastName)}| Description: {item.Description}|");
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

            Console.Write("Description: ");
            data = Console.ReadLine();
            if (EmptyStringChecker(data)) SPdiv.Description = data;

            try
            {
                sPDBusiness.Add(SPdiv);
                Console.WriteLine("The Special Division has been added!");

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
            SpecialDivision SPDiv = sPDBusiness.Get(id);
            if (SPDiv != null)
            {
                Console.Write("Name: ");
                SPDiv.Name = Console.ReadLine();

                Console.Write("Leader Id: ");
                data = Console.ReadLine();
                if (EmptyStringChecker(data)) SPDiv.LeaderId = int.Parse(data);


                Console.Write("Description: ");
                data = Console.ReadLine();
                if (EmptyStringChecker(data)) SPDiv.Description = data;

                try
                {
                    sPDBusiness.Update(SPDiv);
                    Console.WriteLine("The Special Division has been updated!");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error! Incorrect data!");
                }
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
                try
                {
                    sPDBusiness.Delete(id);
                    Console.WriteLine("The Special Division has been deleted!");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error! Cannot delete item!");
                }
            }
            else
            {
                Console.WriteLine("Special Division not found!");
            }
        }
    }
}
