using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class SRRBusiness
    {
        private SRRContext sRRContext;

        public List<SoulReapers> GetAll()
        {
            using (sRRContext = new SRRContext())
            {
                return sRRContext.SoulReapers.ToList();
            }
        }

        public SoulReapers Get(int id)
        {
            using (sRRContext = new SRRContext())
            {
                return sRRContext.SoulReapers.Find(id);
            }
        }

        public void Add(SoulReapers product)
        {

            using (sRRContext = new SRRContext())
            {
                sRRContext.SoulReapers.Add(product);
                sRRContext.SaveChanges();
            }
        }

        public void Update(SoulReapers product)
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
