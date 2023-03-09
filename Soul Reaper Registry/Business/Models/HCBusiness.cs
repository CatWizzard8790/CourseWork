using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;
using Data.Models;

namespace Business.Models
{
    public class HCBusiness
    {
        private SRRContext sRRContext;

        public List<HollowClassification> GetAll()
        {
            using (sRRContext = new SRRContext())
            {
                return sRRContext.HollowClassifications.ToList();
            }
        }

        public HollowClassification Get(int id)
        {
            using (sRRContext = new SRRContext())
            {
                return sRRContext.HollowClassifications.Find(id);
            }
        }

        public void Add(HollowClassification product)
        {

            using (sRRContext = new SRRContext())
            {
                sRRContext.HollowClassifications.Add(product);
                sRRContext.SaveChanges();
            }
        }

        public void Update(HollowClassification product)
        {
            using (sRRContext = new SRRContext())
            {
                var item = sRRContext.HollowClassifications.Find(product.HCId);
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
                var item = sRRContext.HollowClassifications.Find(id);
                if (item != null)
                {
                    sRRContext.HollowClassifications.Remove(item);
                    sRRContext.SaveChanges();
                }
            }

        }
    }
}
