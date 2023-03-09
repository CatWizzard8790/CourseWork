using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;
using Data.Models;

namespace Business.Models
{
    public class HBusiness
    {
        private SRRContext sRRContext;

        public List<Hollow> GetAll()
        {
            using (sRRContext = new SRRContext())
            {
                return sRRContext.Hollows.ToList();
            }
        }

        public Hollow Get(int id)
        {
            using (sRRContext = new SRRContext())
            {
                return sRRContext.Hollows.Find(id);
            }
        }

        public void Add(Hollow product)
        {

            using (sRRContext = new SRRContext())
            {
                sRRContext.Hollows.Add(product);
                sRRContext.SaveChanges();
            }
        }

        public void Update(Hollow product)
        {
            using (sRRContext = new SRRContext())
            {
                var item = sRRContext.Hollows.Find(product.HId);
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
                var item = sRRContext.Hollows.Find(id);
                if (item != null)
                {
                    sRRContext.Hollows.Remove(item);
                    sRRContext.SaveChanges();
                }
            }
        }
    }
}

