using Data.Models;
using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Models
{
    public class DivBusiness
    {
        private SRRContext sRRContext;

        public List<Divisions> GetAll()
        {
            using (sRRContext = new SRRContext())
            {
                return sRRContext.Divisions.ToList();
            }
        }

        public Divisions Get(int id)
        {
            using (sRRContext = new SRRContext())
            {
                return sRRContext.Divisions.Find(id);
            }
        }

        public void Add(Divisions product)
        {

            using (sRRContext = new SRRContext())
            {
                sRRContext.Divisions.Add(product);
                sRRContext.SaveChanges();
            }
        }

        public void Update(Divisions product)
        {
            using (sRRContext = new SRRContext())
            {
                var item = sRRContext.Divisions.Find(product.DivisionNumber);
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
                var item = sRRContext.Divisions.Find(id);
                if (item != null)
                {
                    sRRContext.Divisions.Remove(item);
                    sRRContext.SaveChanges();
                }
            }
        }
    }
}
