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

        public List<Division> GetAll()
        {
            using (sRRContext = new SRRContext())
            {
                return sRRContext.Division.ToList();
            }
        }

        public Division Get(int id)
        {
            using (sRRContext = new SRRContext())
            {
                return sRRContext.Division.Find(id);
            }
        }

        public void Add(Division product)
        {

            using (sRRContext = new SRRContext())
            {
                sRRContext.Division.Add(product);
                sRRContext.SaveChanges();
            }
        }

        public void Update(Division product)
        {
            using (sRRContext = new SRRContext())
            {
                var item = sRRContext.Division.Find(product.DivisionNumber);
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
                var item = sRRContext.Division.Find(id);
                if (item != null)
                {
                    sRRContext.Division.Remove(item);
                    sRRContext.SaveChanges();
                }
            }
        }
    }
}
