using BloodMap.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodMap.Data.ViewModel
{
    public class SearchDonor
    {
        public Address Address { get; set; }
        public int BloodGroupId { get; set; }
    }
}
