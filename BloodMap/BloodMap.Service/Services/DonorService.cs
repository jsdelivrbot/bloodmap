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

        //public IList<Donor> SearchDonors(Address address)
        //{
        //    var primaryDonors = _context.Donors.Where(x => 
        //    x.PrimaryAddress.Country == address.Country
        //    && x.PrimaryAddress.State == address.State
        //    && x.PrimaryAddress.City == address.City 
        //    && x.PrimaryAddress.PinCode == address.PinCode).Union(
        //        from donor in _context.Donors where 
        //    donor.SecondaryAddress.Country == address.Country
        //    && donor.SecondaryAddress.State == address.State
        //    && donor.SecondaryAddress.City == address.City
        //    && donor.SecondaryAddress.PinCode == address.PinCode select donor);

        //    var filteredLocal = primaryDonors.Where(where => where.PrimaryAddress.Locality.Contains(address.Locality) || 
        //    where.SecondaryAddress.Locality.Contains(address.Locality));
        //    if (filteredLocal != null && filteredLocal.Count() > 0)
        //        return filteredLocal.ToList();
        //    else
        //        return primaryDonors.ToList();
        //}
    }
}
