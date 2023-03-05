using System;
using Business;
using Data.Models;

namespace SRRAppConsole.Presentation
{
    public class SoulReaperDisplay : Display
    {
        SRRBusiness sRRBusiness = new SRRBusiness();

        public SoulReaperDisplay()
        {
            Input();
        }

        public override void ShowMenu()
        {
            Console.WriteLine(new string('-', 40));
            Console.WriteLine(@"  __              _                       
 (_   _      |   |_)  _   _. ._   _  ._ _ 
 __) (_) |_| |   | \ (/_ (_| |_) (/_ | _> 
                             |            ");
            Console.WriteLine(new string('-', 40));
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
            foreach (var item in products)
            {
                Console.WriteLine($"Id: { item.SRId}| First Name: { item.FirstName}| Last Name: { item.LastName}| EnrollDate: { item.EnrollDate}| Available: {item.Available}| Division Id: {item.DivisionId}| Special Id:  {item.SpecialId}| Weapon Name:  {item.WeaponName}| Weapon Power Id:  {item.WeaponPowerId}| Description:  {item.Description}|");
            }

        }
        public override void Add()
        {
            string data;
            SoulReapers sr = new SoulReapers();

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
            if (EmptyStringChecker(data)) sr.SpecialId = int.Parse(data);

            Console.Write("Weapon Name: ");
            sr.WeaponName = Console.ReadLine();

            Console.Write("Weapon Power Id: ");
            data = Console.ReadLine();
            if (EmptyStringChecker(data)) sr.WeaponPowerId = int.Parse(data);

            Console.Write("Description: ");
            data = Console.ReadLine();
            if (EmptyStringChecker(data)) sr.Description = data;

            sRRBusiness.Add(sr);
            Console.WriteLine("The Soul Reaper has been added!");
        }
        public override void Update()
        {
            Console.Write("Id: ");
            int id = int.Parse(Console.ReadLine());
            SoulReapers sr = sRRBusiness.Get(id);
            if (sr != null)
            {
                Console.WriteLine($"Id: { sr.SRId}| First Name: { sr.FirstName}| Last Name: { sr.LastName}| EnrollDate: { sr.EnrollDate}| Available: {sr.Available}| Division Id: {sr.DivisionId}| Special Id:  {sr.SpecialId}| Weapon Name:  {sr.WeaponName}| Weapon Power Id:  {sr.WeaponPowerId}| Description:  {sr.Description}|");
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
                if (EmptyStringChecker(data)) sr.SpecialId = int.Parse(data);

                Console.Write("Weapon Name: ");
                sr.WeaponName = Console.ReadLine();

                Console.Write("Weapon Power Id: ");
                data = Console.ReadLine();
                if (EmptyStringChecker(data)) sr.WeaponPowerId = int.Parse(data);

                Console.Write("Description: ");
                data = Console.ReadLine();
                if (EmptyStringChecker(data)) sr.Description = data;

                sRRBusiness.Update(sr);
                Console.WriteLine("The Soul Reaper has been updated!");
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
            SoulReapers sr = sRRBusiness.Get(id);
            if (sr != null)
            {
                Console.WriteLine(new string('-', 40));
                Console.WriteLine("ID: " + sr.SRId);
                Console.WriteLine("First Name: " + sr.FirstName);
                Console.WriteLine("Last Name: " + sr.LastName);
                Console.WriteLine($"Enroll Date: {sr.EnrollDate}");
                Console.WriteLine($"Available: {sr.Available}");
                Console.WriteLine($"Division Id: {sr.DivisionId}");
                Console.WriteLine($"Special Id: {sr.SpecialId}");
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
            SoulReapers product = sRRBusiness.Get(id);
            if (product != null)
            {
                sRRBusiness.Delete(id);
                Console.WriteLine("The Soul Reaper has been deleted!");
            }
            else
            {
                Console.WriteLine("Soul Reaper not found!");
            }
        }
    }
}
