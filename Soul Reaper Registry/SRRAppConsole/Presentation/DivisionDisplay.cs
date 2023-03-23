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
    /// Implements the CRUD methods from Display for Divison.
    /// </summary>
    public class DivisionDisplay : Display
    {
        DivBusiness divBusiness = new DivBusiness();
        public override void ShowMenu()
        {
            Console.WriteLine(new string('-', 35));
            Console.WriteLine(@"  ____  _       _     _             
 |  _ \(_)_   _(_)___(_) ___  _ __  
 | | | | \ \ / / / __| |/ _ \| '_ \ 
 | |_| | |\ V /| \__ \ | (_) | | | |
 |____/|_| \_/ |_|___/_|\___/|_| |_|");
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
            Console.WriteLine(new string('-', 30));
            Console.WriteLine(@"  _                         
 | \ o    o  _ o  _  ._   _ 
 |_/ | \/ | _> | (_) | | _> ");
            Console.WriteLine(new string('-', 30));
            var products = divBusiness.GetAll();
            foreach (var item in sRRContext.Division.Include(s => s.Captain).Include(l => l.Lieutenant))
            {

                Console.WriteLine($"Id: {item.DivisionNumber}| Name: {item.Name}| Captain : {(item.Captain == null ? " " : item.Captain.FirstName)} {(item.Captain == null ? " " : item.Captain.LastName)} | Lieutenant : {(item.Lieutenant == null ? " " : item.Lieutenant.FirstName)} {(item.Lieutenant == null ? " " : item.Lieutenant.LastName)} | Description : {(item.Description == null ? " " : item.Description)}|\n" +
                    $" ");

            }
        }
        public override void Add()
        {
            string data;
            Division product = new Division();

            Console.Write("Name*: ");
            product.Name = Console.ReadLine();

            Console.Write("Captain Id: ");
            data = Console.ReadLine();
            if (EmptyStringChecker(data)) product.CaptainId = int.Parse(data); ;

            Console.Write("Lieutenant Id: ");
            data = Console.ReadLine();
            if (EmptyStringChecker(data)) product.LieutenantId = int.Parse(data);

            Console.Write("Description: ");
            data = Console.ReadLine();
            if (EmptyStringChecker(data)) product.Description = data;

            try
            {
                divBusiness.Add(product);
                Console.WriteLine("The Division has been added!");

            }
            catch (Exception ex)
            {

                Console.WriteLine("Error! Incorrect data!");
            }
        }
        public override void Update()
        {
            Console.Write("Id: ");
            int id = int.Parse(Console.ReadLine());
            Division sr = divBusiness.Get(id);
            if (sr != null)
            {
                Console.WriteLine($"Id: {sr.DivisionNumber}| Name: {sr.Name}| Captain Id : {sr.CaptainId}| Lieutenant Id :{sr.LieutenantId}| Description : {sr.Description}|");
                string data;

                Console.Write("Name: ");
                sr.Name = Console.ReadLine();

                Console.Write("Captain Id: ");
                data = Console.ReadLine();
                if (EmptyStringChecker(data)) sr.CaptainId = int.Parse(data); ;

                Console.Write("Lieutenant Id: ");
                data = Console.ReadLine();
                if (EmptyStringChecker(data)) sr.LieutenantId = int.Parse(data);

                Console.Write("Description: ");
                data = Console.ReadLine();
                if (EmptyStringChecker(data)) sr.Description = data;

                try
                {
                    divBusiness.Update(sr);
                    Console.WriteLine("The Division has been updated!");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Incorrect data!");
                }
            }
            else
            {
                Console.WriteLine("Division not found!");
            }
        }
        public override void Fetch()
        {
            Console.Write("Id: ");
            int id = int.Parse(Console.ReadLine());
            Division sr = sRRContext.Division.Find(id);
            sRRContext.Entry(sr).Reference(c => c.Captain).Load();
            sRRContext.Entry(sr).Reference(l => l.Lieutenant).Load();
            sRRContext.Entry(sr).Collection(sr => sr.SoulReapers).Load();

            if (sr != null)
            {
                Console.WriteLine(new string('-', 40));
                Console.WriteLine("ID: " + sr.DivisionNumber);
                Console.WriteLine("Name: " + sr.Name);
                Console.WriteLine("Captain Id: " + sr.CaptainId + $"| {(sr.Captain == null ? " " : sr.Captain.FirstName)} {(sr.Captain == null ? " " : sr.Captain.LastName)}");
                Console.WriteLine($"LieutenantId: {sr.LieutenantId}" + $"| {(sr.Lieutenant == null ? " " : sr.Lieutenant.FirstName)} {(sr.Lieutenant == null ? " " : sr.Lieutenant.LastName)}");
                Console.WriteLine($"Description: {sr.Description}");

                Console.WriteLine(new string('-', 40));

                Console.WriteLine("Division Members: \n");
                int counter = 1;
                
                foreach (var srr in sr.SoulReapers)
                {
                    Console.WriteLine($"{counter}. {(srr.FirstName == null ? " " : srr.FirstName)} {(srr.LastName == null ? " " : srr.LastName)} \n");
                    counter++;
                }

                Console.WriteLine(new string('-', 40));
            }
            else
            {
                Console.WriteLine("Division not found!");
            }
        }
        public override void Delete()
        {
            Console.Write("Id: ");
            int id = int.Parse(Console.ReadLine());
            Division product = divBusiness.Get(id);
            if (product != null)
            {
                try
                {
                    divBusiness.Delete(id);
                    Console.WriteLine("The Division has been deleted!");

                }
                catch (Exception)
                {
                    Console.WriteLine("Error! Item could not be deleted!");

                }
            }
            else
            {
                Console.WriteLine("Division not found!");
            }
        }

    }
}
