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
    public class DonorService : IDonorService
    {
        private readonly BloodMapEntities _context;

        /// <summary>
        /// Constructor
        /// </summary>
        public DonorService()
        {
            _context = new BloodMapEntities();
        }

        public IList<Donor> SearchDonors(SearchDonor searchDonor)
        {
            var primaryDonors = _context.Donors.Where(x =>
            x.Address1.Country == searchDonor.Address.Country
            && x.Address1.State == searchDonor.Address.State
            && x.Address1.City == searchDonor.Address.City
            && x.Address1.PinCode == searchDonor.Address.PinCode
            && x.L_BloodGroupId == searchDonor.BloodGroupId).Union(
                from donor in _context.Donors
                where
                donor.Address.Country == searchDonor.Address.Country
                && donor.Address.State == searchDonor.Address.State
                && donor.Address.City == searchDonor.Address.City
                && donor.Address.PinCode == searchDonor.Address.PinCode
                && donor.L_BloodGroupId == searchDonor.BloodGroupId
                select donor);

            var filteredLocal = primaryDonors.Where(where => where.Address1.Locality.Contains(searchDonor.Address.Locality) ||
            where.Address.Locality.Contains(searchDonor.Address.Locality));
            if (filteredLocal != null && filteredLocal.Count() > 0)
                return filteredLocal.ToList();
            else
                return primaryDonors.ToList();
        }
    }
}
