using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;
using Data.Models;

namespace Business.Models
{
    public class SRRBusiness
    {
        private SRRContext sRRContext;

        public List<SoulReaper> GetAll()
        {
            using (sRRContext = new SRRContext())
            {
                return sRRContext.SoulReapers.ToList();
            }
        }

        public SoulReaper Get(int id)
        {
            using (sRRContext = new SRRContext())
            {
                return sRRContext.SoulReapers.Find(id);
            }
        }

        public void Add(SoulReaper product)
        {

            using (sRRContext = new SRRContext())
            {
                sRRContext.SoulReapers.Add(product);
                sRRContext.SaveChanges();
            }
        }

        public void Update(SoulReaper product)
        {
            using (sRRContext = new SRRContext())
            {
                var item = sRRContext.SoulReapers.Find(product.SRId);
                if (item != null)
                {
                    sRRContext.Entry(item).CurrentValues.SetValues(product);
                    sRRContext.SaveChanges();
                }
            }
        }

        public void Delete(int id)
        {
            using (sRRContext = new SRRContext())
            {
                var item = sRRContext.SoulReapers.Find(id);
                if (item != null)
                {
                    sRRContext.SoulReapers.Remove(item);
                    sRRContext.SaveChanges();
                }
            }
        }
    }
}
