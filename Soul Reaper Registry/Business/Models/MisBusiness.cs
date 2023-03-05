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

        public List<Missions> GetAll()
        {
            using (sRRContext = new SRRContext())
            {
                return sRRContext.Missions.ToList();
            }
        }

        public Missions Get(int id)
        {
            using (sRRContext = new SRRContext())
            {
                return sRRContext.Missions.Find(id);
            }
        }

        public void Add(Missions product)
        {

            using (sRRContext = new SRRContext())
            {
                sRRContext.Missions.Add(product);
                sRRContext.SaveChanges();
            }
        }

        public void Update(Missions product)
        {
            using (sRRContext = new SRRContext())
            {
                var item = sRRContext.Missions.Find(product.MId);
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
                var item = sRRContext.Missions.Find(id);
                if (item != null)
                {
                    sRRContext.Missions.Remove(item);
                    sRRContext.SaveChanges();
                }
            }
        }
    }
}

