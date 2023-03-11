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

