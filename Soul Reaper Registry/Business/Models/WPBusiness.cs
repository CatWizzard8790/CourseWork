using Data.Models;
using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Models
{
    public class WPBusiness
    {
        private SRRContext sRRContext;

        public List<WeaponPowers> GetAll()
        {
            using (sRRContext = new SRRContext())
            {
                return sRRContext.WeaponPowers.ToList();
            }
        }

        public WeaponPowers Get(int id)
        {
            using (sRRContext = new SRRContext())
            {
                return sRRContext.WeaponPowers.Find(id);
            }
        }

        public void Add(WeaponPowers product)
        {

            using (sRRContext = new SRRContext())
            {
                sRRContext.WeaponPowers.Add(product);
                sRRContext.SaveChanges();
            }
        }

        public void Update(WeaponPowers product)
        {
            using (sRRContext = new SRRContext())
            {
                var item = sRRContext.WeaponPowers.Find(product.WPId);
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
                var item = sRRContext.WeaponPowers.Find(id);
                if (item != null)
                {
                    sRRContext.WeaponPowers.Remove(item);
                    sRRContext.SaveChanges();
                }
            }
        }
    }
}
