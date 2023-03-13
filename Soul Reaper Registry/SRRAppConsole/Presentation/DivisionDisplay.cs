using Business.Models;
using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRRAppConsole.Presentation
{
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
            foreach (var item in products)
            {
                Console.WriteLine($"Id: {item.DivisionNumber}| Name: {item.Name}| Captain Id : {item.CaptainId}| Lieutenant Id :{item.LieutenantId}| Description : {item.Description}|");
            }
        }
        public override void Add()
        {
            string data;
            Division product = new Division();

            Console.Write("Name: ");
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
            Division sr = divBusiness.Get(id);
            if (sr != null)
            {
                Console.WriteLine(new string('-', 40));
                Console.WriteLine("ID: " + sr.DivisionNumber);
                Console.WriteLine("Name: " + sr.Name);
                Console.WriteLine("Captain Id: " + sr.CaptainId);
                Console.WriteLine($"LieutenantId: {sr.LieutenantId}");
                Console.WriteLine($"Description: {sr.Description}");

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
