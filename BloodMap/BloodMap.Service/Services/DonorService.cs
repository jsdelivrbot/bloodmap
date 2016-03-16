using BloodMap.Service.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BloodMap.Data.Context;


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

        public IList<Donor> SearchDonors(Address address)
        {
            var primaryDonors = _context.Donors.Where(x =>
            x.Address1.Country == address.Country
            && x.Address1.State == address.State
            && x.Address1.City == address.City
            && x.Address1.PinCode == address.PinCode).Union(
                from donor in _context.Donors
                where
donor.Address.Country == address.Country
&& donor.Address.State == address.State
&& donor.Address.City == address.City
&& donor.Address.PinCode == address.PinCode
                select donor);

            var filteredLocal = primaryDonors.Where(where => where.Address1.Locality.Contains(address.Locality) ||
            where.Address.Locality.Contains(address.Locality));
            if (filteredLocal != null && filteredLocal.Count() > 0)
                return filteredLocal.ToList();
            else
                return primaryDonors.ToList();
        }
    }
}
