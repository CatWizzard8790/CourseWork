using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;
using Data.Models;

namespace Business.Models
{
    /// <summary>
    /// Controller for the HollowClassification class. It allows the usage of the GetAll, Get, Add Update, Delete operations for the HollowClassification table.
    /// </summary>
    public class HCBusiness
    {
        private SRRContext sRRContext;

        public HCBusiness(SRRContext sRRContext)
        {
            this.sRRContext = sRRContext;
        }

        public HCBusiness()
        {

        }

        public List<HollowClassification> GetAll()
        {
            using (sRRContext = new SRRContext())
            {
                return sRRContext.HollowClassification.ToList();
            }
        }

        public HollowClassification Get(int id)
        {
            using (sRRContext = new SRRContext())
            {
                return sRRContext.HollowClassification.Find(id);
            }
        }

        public void Add(HollowClassification product)
        {

            using (sRRContext = new SRRContext())
            {
                sRRContext.HollowClassification.Add(product);
                sRRContext.SaveChanges();
            }
        }

        public void Update(HollowClassification product)
        {
            using (sRRContext = new SRRContext())
            {
                var item = sRRContext.HollowClassification.Find(product.HCId);
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
                var item = sRRContext.HollowClassification.Find(id);
                if (item != null)
                {
                    sRRContext.HollowClassification.Remove(item);
                    sRRContext.SaveChanges();
                }
            }

        }
    }
}
