using Data.Models;
using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Models
{
    /// <summary>
    /// Controller for the SpecialDivision class. It allows the usage of the GetAll, Get, Add Update, Delete operations for the SpecialDivision table.
    /// </summary>
    public class SPDivBusiness
    {
        private SRRContext sRRContext;

        public SPDivBusiness(SRRContext sRRContext)
        {
            this.sRRContext = sRRContext;
        }

        public SPDivBusiness()
        {

        }
        public List<SpecialDivision> GetAll()
        {
            using (sRRContext = new SRRContext())
            {
                return sRRContext.SpecialDivision.ToList();
            }
        }

        public SpecialDivision Get(int id)
        {
            using (sRRContext = new SRRContext())
            {
                return sRRContext.SpecialDivision.Find(id);
            }
        }

        public void Add(SpecialDivision product)
        {

            using (sRRContext = new SRRContext())
            {
                sRRContext.SpecialDivision.Add(product);
                sRRContext.SaveChanges();
            }
        }

        public void Update(SpecialDivision product)
        {
            using (sRRContext = new SRRContext())
            {
                var item = sRRContext.SpecialDivision.Find(product.SDId);
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
                var item = sRRContext.SpecialDivision.Find(id);
                if (item != null)
                {
                    sRRContext.SpecialDivision.Remove(item);
                    sRRContext.SaveChanges();
                }
            }
        }
    }
}

