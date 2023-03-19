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
    /// Controller for the Hollows class. It allows the usage of the GetAll, Get, Add Update, Delete operations for the Hollow table.
    /// </summary>
    public class HBusiness
    {
        private SRRContext sRRContext;

        public HBusiness(SRRContext sRRContext)
        {
            this.sRRContext = sRRContext;
        }

        public HBusiness()
        {

        }

        public List<Hollow> GetAll()
        {
            using (sRRContext = new SRRContext())
            {
                return sRRContext.Hollow.ToList();
            }
        }

        public Hollow Get(int id)
        {
            using (sRRContext = new SRRContext())
            {
                return sRRContext.Hollow.Find(id);
            }
        }

        public void Add(Hollow product)
        {

            using (sRRContext = new SRRContext())
            {
                sRRContext.Hollow.Add(product);
                sRRContext.SaveChanges();
            }
        }

        public void Update(Hollow product)
        {
            using (sRRContext = new SRRContext())
            {
                var item = sRRContext.Hollow.Find(product.HId);
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
                var item = sRRContext.Hollow.Find(id);
                if (item != null)
                {
                    sRRContext.Hollow.Remove(item);
                    sRRContext.SaveChanges();
                }
            }
        }
    }
}

