using Business.Models;
using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRRAppConsole.Presentation
{
    public class MissionHollowDisplay : Display
    {
        MisHBusiness missHBusiness = new MisHBusiness();
        public override void ShowMenu()
        {
            Console.WriteLine(new string('-', 40));
            Console.WriteLine(@"  __  __ _         _                   _   _       _ _                   
 |  \/  (_)___ ___(_) ___  _ __  ___  | | | | ___ | | | _____      _____ 
 | |\/| | / __/ __| |/ _ \| '_ \/ __| | |_| |/ _ \| | |/ _ \ \ /\ / / __|
 | |  | | \__ \__ \ | (_) | | | \__ \ |  _  | (_) | | | (_) \ V  V /\__ \
 |_|  |_|_|___/___/_|\___/|_| |_|___/ |_| |_|\___/|_|_|\___/ \_/\_/ |___/");
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
            Console.WriteLine(@" |\/| o  _  _ o  _  ._   _  |_|  _  | |  _        _ 
 |  | | _> _> | (_) | | _>  | | (_) | | (_) \/\/ _> ");
            Console.WriteLine(new string('-', 40));
            var misH = missHBusiness.GetAll();
            foreach (var item in misH)
            {
                Console.WriteLine($"Mission Id: {item.MissionsId}| Hollow Id: {item.HollowsId}| Hollow Status: {item.HollowStatus}|");
            }
        }
        public override void Add()
        {
            MissionHollow missH = new MissionHollow();

            Console.Write("Mission Id: ");
            missH.MissionsId = int.Parse(Console.ReadLine());

            Console.Write("Hollow Id: ");
            missH.HollowsId = int.Parse(Console.ReadLine());

            Console.Write("Hollow Status: ");
            missH.HollowStatus = bool.Parse(Console.ReadLine());

            missHBusiness.Add(missH);
            Console.WriteLine("The Hollow Mission has been added!");
        }
        public override void Update()
        {
            Console.Write("Enter Ids: ");
            int[] ids = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int id = ids[0];
            int id2 = ids[1];
            MissionHollow Hmiss = missHBusiness.Get(id, id2 );
            if (Hmiss != null)
            {
                Console.Write("Mission Id: ");
                Hmiss.MissionsId = int.Parse(Console.ReadLine());

                Console.Write("Hollow Id: ");
                Hmiss.HollowsId = int.Parse(Console.ReadLine());

                Console.Write("Hollow Status: ");
                Hmiss.HollowStatus = bool.Parse(Console.ReadLine());

                missHBusiness.Update(Hmiss);
                Console.WriteLine("The Mission has been updated!");
            }
            else
            {
                Console.WriteLine("Mission not found!");
            }
        }
        public override void Fetch()
        {
            Console.Write("Enter Ids: ");
            int[] ids = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int id = ids[0];
            int id2 = ids[1];
            MissionHollow Hmis = missHBusiness.Get(id, id2);
            if (Hmis != null)
            {
                Console.WriteLine(new string('-', 40));

                Console.WriteLine("Mission Id: " + Hmis.MissionsId);
                Console.WriteLine("Hollow Id: " + Hmis.HollowsId);
                Console.WriteLine("Hollow Status: " + Hmis.HollowStatus);

                Console.WriteLine(new string('-', 40));
            }
            else
            {
                Console.WriteLine("Hollow Mission not found!");
            }
        }
        public override void Delete()
        {
            Console.Write("Enter Ids: ");
            int[] ids = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int id = ids[0];
            int id2 = ids[1];
            MissionHollow hmis = missHBusiness.Get(id, id2);
            if (hmis != null)
            {
                missHBusiness.Delete(id, id2);
                Console.WriteLine("The Hollow Mission has been deleted!");
            }
            else
            {
                Console.WriteLine("Hollow Mission not found!");
            }
        }
    }
}
