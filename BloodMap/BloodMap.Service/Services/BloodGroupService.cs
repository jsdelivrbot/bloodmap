using BloodMap.Service.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BloodMap.Data.Context;
using BloodMap.Data.ViewModel;

namespace BloodMap.Service.Services
{
    public class BloodGroupService : IBloodGroupService
    {
        private readonly BloodMapEntities bloodMapContext;
        public BloodGroupService()
        {
            bloodMapContext = new BloodMapEntities();
        }

        public IEnumerable<LookupModel> GetAll()
        {
            return bloodMapContext.L_BloodGroup.Select(x => new LookupModel { Id = x.BloodGroupId, Value = x.GroupTitle }).ToList();
        }

        public L_BloodGroup Get(int id)
        {
            return bloodMapContext.L_BloodGroup.Where(x => x.BloodGroupId == id).FirstOrDefault();
        }
    }
}
