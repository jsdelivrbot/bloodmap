using BloodMap.Data.Context;
using BloodMap.Data.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodMap.Service.Contract
{
    public interface IBloodGroupService
    {
        IEnumerable<LookupModel> GetAll();
        L_BloodGroup Get(int id);
    }
}
