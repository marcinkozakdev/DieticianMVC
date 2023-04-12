using DieticianMVC.Domain.Interfaces;
using DieticianMVC.Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace DieticianMVC.Infrastructure.Repositories
{
    public class AddressRepository :IAddressRepository
    {
        private readonly Context _context;
        public AddressRepository(Context context)
        {
            _context = context;
        }

        public Address GetAddressById(int addressId)
        {
            var address = _context.Addresses.FirstOrDefault(i => i.Id == addressId);
            return address;
        }

        public Address AddAddress(Address address)
        {
            _context.Addresses.Add(address);
            _context.SaveChanges();
            return address;
        }

        public Address UpdateAddress(Address address)
        {
            if (address != null)
                _context.Addresses.Update(address);
            _context.SaveChanges();

            return address;
        }

        public void DeleteAddress(int addressId)
        {
            var address = _context.Addresses.Find(addressId);
            if (address != null)
            {
                _context.Addresses.Remove(address);
                _context.SaveChanges();
            }
        }

        public IQueryable<Address> GetAddressByDietician(int dieticianId)
        {
            IQueryable<Address> addresses = null;
            var dietician = _context.Dieticianes.AsNoTracking().Where(e => e.Id == dieticianId);
            if (dietician != null)
            {
                addresses = _context.Addresses.AsNoTracking().Where(v => v.DieticianId == dieticianId);
            }
            return addresses;
        }
    }
}
