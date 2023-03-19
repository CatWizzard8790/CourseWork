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
    /// Controller for the WeaponPower class. It allows the usage of the GetAll, Get, Add Update, Delete operations for the WeaponPower table.
    /// </summary>
    public class WPBusiness
    {
        private SRRContext sRRContext;

        public WPBusiness(SRRContext sRRContext)
        {
            this.sRRContext = sRRContext;
        }

        public WPBusiness()
        {

        }

        public List<WeaponPower> GetAll()
        {
            using (sRRContext = new SRRContext())
            {
                return sRRContext.WeaponPower.ToList();
            }
        }

        public WeaponPower Get(int id)
        {
            using (sRRContext = new SRRContext())
            {
                return sRRContext.WeaponPower.Find(id);
            }
        }

        public void Add(WeaponPower product)
        {

            using (sRRContext = new SRRContext())
            {
                sRRContext.WeaponPower.Add(product);
                sRRContext.SaveChanges();
            }
        }

        public void Update(WeaponPower product)
        {
            using (sRRContext = new SRRContext())
            {
                var item = sRRContext.WeaponPower.Find(product.WPId);
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
                var item = sRRContext.WeaponPower.Find(id);
                if (item != null)
                {
                    sRRContext.WeaponPower.Remove(item);
                    sRRContext.SaveChanges();
                }
            }
        }
    }
}
