using Business.Models;
using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRRAppConsole.Presentation
{
    public class MissionSoulReaperDisplay : Display
    {
        MisSRBusiness misSRBusiness = new MisSRBusiness();
        public override void ShowMenu()
        {
            Console.WriteLine(new string('-', 40));
            Console.WriteLine(@" Mission Soul Reapers ");
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
            Console.WriteLine(@" Mission Soul Reapers ");
            Console.WriteLine(new string('-', 40));
            var misSR = misSRBusiness.GetAll();
            foreach (var item in misSR)
            {
                Console.WriteLine($"Soul Reaper Id: {item.SRId}| Mission Id: {item.MissionId}|");
            }
        }
        public override void Add()
        {
            MissionSoulReaper missSR = new MissionSoulReaper();

            Console.Write("Soul Reaper Id: ");
            missSR.SRId = int.Parse(Console.ReadLine());

            Console.Write("Mission Id: ");
            missSR.MissionId = int.Parse(Console.ReadLine());

            misSRBusiness.Add(missSR);
            Console.WriteLine("The Soul Reaper Mission has been added!");
        }
        public override void Update()
        {
            Console.Write("Enter Ids: ");
            int[] ids = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int id = ids[0];
            int id2 = ids[1];
            MissionSoulReaper SRmiss = misSRBusiness.Get(id, id2);
            if (SRmiss != null)
            {
                Console.Write("Soul Reaper Id: ");
                SRmiss.SRId = int.Parse(Console.ReadLine());

                Console.Write("Mission Id: ");
                SRmiss.MissionId = int.Parse(Console.ReadLine());

                misSRBusiness.Update(SRmiss);
                Console.WriteLine("The Soul Reaper Mission has been updated!");
            }
            else
            {
                Console.WriteLine("Soul Reaper Mission not found!");
            }
        }
        public override void Fetch()
        {
            Console.Write("Enter Ids: ");
            int[] ids = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int id = ids[0];
            int id2 = ids[1];
            MissionSoulReaper SRMis = misSRBusiness.Get(id, id2);
            if (SRMis != null)
            {
                Console.WriteLine(new string('-', 40));

                Console.WriteLine("Soul Reaper Id: " + SRMis.SRId);
                Console.WriteLine("Mission Id: " + SRMis.MissionId);

                Console.WriteLine(new string('-', 40));
            }
            else
            {
                Console.WriteLine("Soul Reaper Mission not found!");
            }
        }
        public override void Delete()
        {
            Console.Write("Enter Ids: ");
            int[] ids = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int id = ids[0];
            int id2 = ids[1];
            MissionSoulReaper SRMis = misSRBusiness.Get(id, id2);
            if (SRMis != null)
            {
                misSRBusiness.Delete(id, id2);
                Console.WriteLine("The Soul Reaper Mission has been deleted!");
            }
            else
            {
                Console.WriteLine("Soul Reaper Mission not found!");
            }
        }
    }
}
