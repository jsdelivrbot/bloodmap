using BloodMap.Service.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BloodMap.Data.Context;


namespace BloodMap.Service.Services
{
    public class BloodGroupService : IBloodGroupService
    {
        private readonly BloodMapEntities bloodMapContext;
        public BloodGroupService()
        {
            bloodMapContext = new BloodMapEntities();
        }

        public IEnumerable<L_BloodGroup> Get()
        {
            return bloodMapContext.L_BloodGroup.ToList();
        }

        public L_BloodGroup Get(int id)
        {
            return bloodMapContext.L_BloodGroup.Where(x => x.BloodGroupId == id).FirstOrDefault();        }
    }
}
