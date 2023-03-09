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

        public List<SpecialDivision> GetAll()
        {
            using (sRRContext = new SRRContext())
            {
                return sRRContext.SpecialDivisions.ToList();
            }
        }

        public SpecialDivision Get(int id)
        {
            using (sRRContext = new SRRContext())
            {
                return sRRContext.SpecialDivisions.Find(id);
            }
        }

        public void Add(SpecialDivision product)
        {

            using (sRRContext = new SRRContext())
            {
                sRRContext.SpecialDivisions.Add(product);
                sRRContext.SaveChanges();
            }
        }

        public void Update(SpecialDivision product)
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

