using DieticianMVC.Domain.Model;

namespace DieticianMVC.Domain.Interfaces
{
    public interface IAddressRepository
    {
        Address AddAddress(Address address);
        Address GetAddressById(int addressId);
        Address UpdateAddress(Address address);
        void DeleteAddress(int addressId);
    }
}
