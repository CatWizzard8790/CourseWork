﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;
using Data.Models;

namespace Business.Models
{
    public class MisHBusiness
    {
        private SRRContext sRRContext;

        public List<MissionHollow> GetAll()
        {
            using (sRRContext = new SRRContext())
            {
                return sRRContext.MissionsHollow.ToList();
            }
        }

        public MissionHollow Get(int id1, int id2)
        {
            using (sRRContext = new SRRContext())
            {
                return sRRContext.MissionsHollow.FirstOrDefault(x => x.HollowsId == id1 && x.MissionsId == id2); ;
            }
        }

        public void Add(MissionHollow product)
        {

            using (sRRContext = new SRRContext())
            {
                sRRContext.MissionsHollow.Add(product);
                sRRContext.SaveChanges();
            }
        }

        public void Update(MissionHollow product)
        {
            using (sRRContext = new SRRContext())
            {
                var item = sRRContext.MissionsHollow.FirstOrDefault(x => x.HollowsId == product.HollowsId && x.MissionsId == product.MissionsId);
                if (item != null)
                {
                    sRRContext.Entry(item).CurrentValues.SetValues(product);
                    sRRContext.SaveChanges();
                }
            }
        }

        /*public void Delete(int id)
        {
            using (sRRContext = new SRRContext())
            {
                var item = sRRContext.MissionsHollows.FirstOrDefault(x => x.HollowsId == product.HollowsId && x.MissionsId == product.MissionsId);
                if (item != null)
                {
                    sRRContext.MissionsHollows.Remove(item);
                    sRRContext.SaveChanges();
                }
            }
        }*/

        public void Delete(int id1, int id2)
        {
            using (sRRContext = new SRRContext())
            {
                var item = sRRContext.MissionsHollow.FirstOrDefault(x => x.HollowsId == id1 && x.MissionsId == id2);
                if (item != null)
                {
                    sRRContext.MissionsHollow.Remove(item);
                    sRRContext.SaveChanges();
                }
            }
        }

    }
}
