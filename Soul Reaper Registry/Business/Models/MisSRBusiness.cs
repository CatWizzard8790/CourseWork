using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;
using Data.Models;

namespace Business.Models
{
    public class MisSRBusiness
    {
        private SRRContext sRRContext;

        public List<MissionsSoulReapers> GetAll()
        {
            using (sRRContext = new SRRContext())
            {
                return sRRContext.MissionsSoulReapers.ToList();
            }
        }

        public MissionsSoulReapers Get(int id1, int id2)
        {
            using (sRRContext = new SRRContext())
            {
                return sRRContext.MissionsSoulReapers.FirstOrDefault(x => x.SRId == id1 && x.MissionId == id2);
            }
        }

        public void Add(MissionsSoulReapers product)
        {

            using (sRRContext = new SRRContext())
            {
                sRRContext.MissionsSoulReapers.Add(product);
                sRRContext.SaveChanges();
            }
        }

        public void Update(MissionsSoulReapers product)
        {
            using (sRRContext = new SRRContext())
            {
                var item = sRRContext.MissionsSoulReapers.FirstOrDefault(x => x.SRId == product.SRId && x.MissionId == product.MissionId); ;
                if (item != null)
                {
                    sRRContext.Entry(item).CurrentValues.SetValues(product);
                    sRRContext.SaveChanges();
                }
            }
        }

        public void Delete(int id1, int id2)
        {
            using (sRRContext = new SRRContext())
            {
                var item = sRRContext.MissionsSoulReapers.FirstOrDefault(x => x.SRId == id1 && x.MissionId == id2);
                if (item != null)
                {
                    sRRContext.MissionsSoulReapers.Remove(item);
                    sRRContext.SaveChanges();
                }
            }
        }
    }
}

