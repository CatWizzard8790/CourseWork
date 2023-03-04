using Data.Models;
using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Models
{
    public class SPDivBusiness
    {
        private SRRContext sRRContext;

        public List<SpecialDivisions> GetAll()
        {
            using (sRRContext = new SRRContext())
            {
                return sRRContext.SpecialDivisions.ToList();
            }
        }

        public SpecialDivisions Get(int id)
        {
            using (sRRContext = new SRRContext())
            {
                return sRRContext.SpecialDivisions.Find(id);
            }
        }

        public void Add(SpecialDivisions product)
        {

            using (sRRContext = new SRRContext())
            {
                sRRContext.SpecialDivisions.Add(product);
                sRRContext.SaveChanges();
            }
        }

        public void Update(SpecialDivisions product)
        {
            using (sRRContext = new SRRContext())
            {
                var item = sRRContext.SpecialDivisions.Find(product.SDId);
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
                var item = sRRContext.SpecialDivisions.Find(id);
                if (item != null)
                {
                    sRRContext.SpecialDivisions.Remove(item);
                    sRRContext.SaveChanges();
                }
            }
        }
    }
}

