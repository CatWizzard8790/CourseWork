using System;
using Business.Models;
using Data.Models;
using Microsoft.EntityFrameworkCore;

namespace SRRAppConsole.Presentation
{
    public class SoulReaperDisplay : Display
    {
        SRRBusiness sRRBusiness = new SRRBusiness();
        private int endOperation = 6;

        public SoulReaperDisplay()
        {
            Input();
        }

        public override void ShowMenu()
        {
            Console.WriteLine(new string('-', 60));
            Console.WriteLine(@"  ____              _   ____                                
 / ___|  ___  _   _| | |  _ \ ___  __ _ _ __   ___ _ __ 
 \___ \ / _ \| | | | | | |_) / _ \/ _` | '_ \ / _ \ '__|
  ___) | (_) | |_| | | |  _ <  __/ (_| | |_) |  __/ |  
 |____/ \___/ \__,_|_| |_| \_\___|\__,_| .__/ \___|_|  
                                       |_|                  ");
            Console.WriteLine(new string('-', 60));
            Console.WriteLine("1. List all entries");
            Console.WriteLine("2. Add new entry");
            Console.WriteLine("3. Update entry");
            Console.WriteLine("4. Fetch entry by ID");
            Console.WriteLine("5. Delete entry by ID");
            Console.WriteLine("6. Go back to main menu");

        }
        public override void ListAll()
        {            
            Console.WriteLine(new string('-', 40));
            Console.WriteLine(@"  __              _                       
 (_   _      |   |_)  _   _. ._   _  ._ _ 
 __) (_) |_| |   | \ (/_ (_| |_) (/_ | _> 
                             |            ");
            Console.WriteLine(new string('-', 40));
            var products = sRRBusiness.GetAll();
            foreach (var item in sRRContext.SoulReaper.Include(s => s.Division).Include(s => s.SpecialDivision).Include(s => s.WeaponPowers))
            {
                Console.WriteLine($"Id: {item.SRId}| First Name: {item.FirstName}| Last Name: {item.LastName}| EnrollDate: {item.EnrollDate}| Available: {item.Available}| Division: {(item.Division == null ? " " : item.Division.Name)}| Special Division: {(item.SpecialDivision == null ? " " : item.SpecialDivision.Name)}| Weapon Name: {item.WeaponName}| Weapon Power: {(item.WeaponPowers == null ? " " : item.WeaponPowers.FirstForm)}| Description:  {item.Description}|\n" +
                    $" ");
            }
        }
        public override void Add()
        {
            string data;
            SoulReaper sr = new SoulReaper();

            Console.Write("First Name: ");
            sr.FirstName = Console.ReadLine();

            Console.Write("Last Name: ");
            sr.LastName = Console.ReadLine();

            Console.Write("Enroll Date: ");
            data = Console.ReadLine();
            if (EmptyStringChecker(data)) sr.EnrollDate = DateTime.Parse(data);

            Console.Write("Available (true or false): ");
            sr.Available = bool.Parse(Console.ReadLine());

            Console.Write("Division Id: ");
            data = Console.ReadLine();
            if (EmptyStringChecker(data)) sr.DivisionId = int.Parse(data);

            Console.Write("Special Id: ");
            data = Console.ReadLine();
            if (EmptyStringChecker(data)) sr.SpecialDivisionId = int.Parse(data);

            Console.Write("Weapon Name: ");
            sr.WeaponName = Console.ReadLine();

            Console.Write("Weapon Power Id: ");
            data = Console.ReadLine();
            if (EmptyStringChecker(data)) sr.WeaponPowerId = int.Parse(data);

            Console.Write("Description: ");
            data = Console.ReadLine();
            if (EmptyStringChecker(data)) sr.Description = data;

            try
            {
                sRRBusiness.Add(sr);
                Console.WriteLine("The Soul Reaper has been added!");

            }
            catch (Exception e)
            {
                Console.WriteLine("Error! Incorrect data!");
            }
        }
        public override void Update()
        {
            Console.Write("Id: ");
            int id = int.Parse(Console.ReadLine());
            SoulReaper sr = sRRBusiness.Get(id);
            if (sr != null)
            {
                Console.WriteLine($"Id: {sr.SRId}| First Name: {sr.FirstName}| Last Name: {sr.LastName}| EnrollDate: {sr.EnrollDate}| Available: {sr.Available}| Division Id: {sr.DivisionId}| Special Id:  {sr.SpecialDivisionId}| Weapon Name:  {sr.WeaponName}| Weapon Power Id:  {sr.WeaponPowerId}| Description:  {sr.Description}|");
                string data;

                Console.Write("First Name: ");
                sr.FirstName = Console.ReadLine();

                Console.Write("Last Name: ");
                sr.LastName = Console.ReadLine();

                Console.Write("Enroll Date: ");
                data = Console.ReadLine();
                if (EmptyStringChecker(data)) sr.EnrollDate = DateTime.Parse(data);

                Console.Write("Available: ");
                sr.Available = bool.Parse(Console.ReadLine());

                Console.Write("Division Id: ");
                data = Console.ReadLine();
                if (EmptyStringChecker(data)) sr.DivisionId = int.Parse(data);

                Console.Write("Special Id: ");
                data = Console.ReadLine();
                if (EmptyStringChecker(data)) sr.SpecialDivisionId = int.Parse(data);

                Console.Write("Weapon Name: ");
                sr.WeaponName = Console.ReadLine();

                Console.Write("Weapon Power Id: ");
                data = Console.ReadLine();
                if (EmptyStringChecker(data)) sr.WeaponPowerId = int.Parse(data);

                Console.Write("Description: ");
                data = Console.ReadLine();
                if (EmptyStringChecker(data)) sr.Description = data;

                try
                {
                    sRRBusiness.Update(sr);
                    Console.WriteLine("The Soul Reaper has been updated!");
                }
                catch(Exception ex)
                {
                    Console.WriteLine("Error! Incorrect data!");
                }
            }
            else
            {
                Console.WriteLine("Soul Reaper not found!");
            }
        }
        public override void Fetch()
        {
            Console.Write("Id: ");
            int id = int.Parse(Console.ReadLine());
            SoulReaper sr = sRRBusiness.Get(id);
            if (sr != null)
            {
                Console.WriteLine(new string('-', 40));
                Console.WriteLine("ID: " + sr.SRId);
                Console.WriteLine("First Name: " + sr.FirstName);
                Console.WriteLine("Last Name: " + sr.LastName);
                Console.WriteLine($"Enroll Date: {sr.EnrollDate}");
                Console.WriteLine($"Available: {sr.Available}");
                Console.WriteLine($"Division Id: {sr.DivisionId}");
                Console.WriteLine($"Special Id: {sr.SpecialDivisionId}");
                Console.WriteLine("Weapon Name: " + sr.WeaponName);
                Console.WriteLine("Weapon Power Id: " + sr.WeaponPowerId);
                Console.WriteLine("Description: " + sr.Description);

                Console.WriteLine(new string('-', 40));
            }
            else
            {
                Console.WriteLine("Soul Reaper not found!");
            }
        }
        public override void Delete()
        {
            Console.Write("Id: ");
            int id = int.Parse(Console.ReadLine());
            SoulReaper product = sRRBusiness.Get(id);
            if (product != null)
            {
                try
                {
                    sRRBusiness.Delete(id);
                    Console.WriteLine("The Soul Reaper has been deleted!");

                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error! Cannot delete item!");
                }
            }
            else
            {
                Console.WriteLine("Soul Reaper not found!");
            }
        }
    }
}
