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
    /// Controller for the SoulReaper class. It allows the usage of the GetAll, Get, Add Update, Delete operations for the SoulReaper table.
    /// </summary>
    public class SRRBusiness
    {
        private SRRContext sRRContext;

        public SRRBusiness(SRRContext sRRContext)
        {
            this.sRRContext = sRRContext;
        }

        public SRRBusiness()
        {

        }

        public List<SoulReaper> GetAll()
        {
            using (sRRContext = new SRRContext())
            {
                return sRRContext.SoulReaper.ToList();
            }
        }

        public SoulReaper Get(int id)
        {
            using (sRRContext = new SRRContext())
            {
                SoulReaper sr = sRRContext.SoulReaper.Find(id);
                sRRContext.Entry(sr).Reference(d => d.Division).Load();
                return sr;
            }
        }

        public void Add(SoulReaper product)
        {

            using (sRRContext = new SRRContext())
            {
                sRRContext.SoulReaper.Add(product);
                sRRContext.SaveChanges();
            }
        }

        public void Update(SoulReaper product)
        {
            using (sRRContext = new SRRContext())
            {
                var item = sRRContext.SoulReaper.Find(product.SRId);
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
                var item = sRRContext.SoulReaper.Find(id);
                if (item != null)
                {
                    sRRContext.SoulReaper.Remove(item);
                    sRRContext.SaveChanges();
                }
            }
        }
    }
}
