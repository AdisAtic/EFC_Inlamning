using DataLayer.Entities;
using DataLayer.Repositories;

namespace DataLayer.Services
{
    public class AddressService
    {
        private readonly AddressRepository _addressRepository;

        public AddressService(AddressRepository addressRepository)
        {
            _addressRepository = addressRepository;
        }

        public AddressEntity CreateAddress(string streetName, string postalCode, string city)
        {
            var addressModel = _addressRepository.Get(x => x.StreetName == streetName && x.PostalCode == postalCode && x.City == city);
            addressModel ??= _addressRepository.Create(new AddressEntity { StreetName = streetName, PostalCode = postalCode, City = city });

            return addressModel;
        }

        public AddressEntity GetAddress(string streetName, string postalCode, string city)
        {
            var addressModel = _addressRepository.Get(x => x.StreetName == streetName && x.PostalCode == postalCode && x.City == city);
            return addressModel;
        }

        public AddressEntity GetAddressById(int id)
        {
            var addressModel = _addressRepository.Get(x => x.Id == id);
            return addressModel;
        }

        public IEnumerable<AddressEntity> GetAddresses()
        {
            var addresses = _addressRepository.GetAll();
            return addresses;  //59:41//
        }

        public AddressEntity UpdateAddress(AddressEntity addressModel)
        {
            var updatedAddressModel = _addressRepository.Update(x => x.Id == addressModel.Id, addressModel);
            return updatedAddressModel;
        }

        public void DeleteAddress(int id)
        {
            _addressRepository.Delete(x => x.Id == id);
        }
    }
}
