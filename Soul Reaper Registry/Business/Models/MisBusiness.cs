using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;
using Data.Models;

namespace Business.Models
{
    public class MisBusiness
    {


        private SRRContext sRRContext;

        public List<Mission> GetAll()
        {
            using (sRRContext = new SRRContext())
            {
                return sRRContext.Mission.ToList();
            }
        }

        public Mission Get(int id)
        {
            using (sRRContext = new SRRContext())
            {
                return sRRContext.Mission.Find(id);
            }
        }

        public void Add(Mission product)
        {

            using (sRRContext = new SRRContext())
            {
                sRRContext.Mission.Add(product);
                sRRContext.SaveChanges();
            }
        }

        public void Update(Mission product)
        {
            using (sRRContext = new SRRContext())
            {
                var item = sRRContext.Mission.Find(product.MId);
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
                var item = sRRContext.Mission.Find(id);
                if (item != null)
                {
                    sRRContext.Mission.Remove(item);
                    sRRContext.SaveChanges();
                }
            }
        }
    }
}

