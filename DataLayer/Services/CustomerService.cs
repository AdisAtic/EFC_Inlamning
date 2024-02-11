using DataLayer.Entities;
using DataLayer.Repositories;

namespace DataLayer.Services
{
    public class CustomerService
    {
        private readonly CustomerRepository _customerRepository;
        private readonly AddressService _addressService;
        private readonly RoleService _roleService;

        public CustomerService(CustomerRepository customerRepository, AddressService addressService, RoleService roleService)
        {
            _customerRepository = customerRepository;
            _addressService = addressService;
            _roleService = roleService;
        }


        public CustomerEntity CreateCustomer(string firstName, string lastName, string email, string roleName, string streetName, string postalCode, string city)
        {
            var roleModel = _roleService.CreateRole(roleName);
            var addressModel = _addressService.CreateAddress(streetName, postalCode, city);

            var customerModel = new CustomerEntity
            {
                FirstName = firstName,
                LastName = lastName,
                Email = email,
                RoleId = roleModel.Id,
                AddressId = addressModel.Id,
            };

            customerModel = _customerRepository.Create(customerModel);

            return customerModel;
        }


        public CustomerEntity GetCustomerById(string email)
        {
            var CustomerModel = _customerRepository.Get(x => x.Email == email);
            return CustomerModel;
        }

        public IEnumerable<CustomerEntity> GetCustomers()
        {
            var customers = _customerRepository.GetAll();
            return customers;
        }

        public CustomerEntity UpdateCustomer(CustomerEntity customerModel)
        {
            var updatedCustomerModel = _customerRepository.Update(x => x.Id == customerModel.Id, customerModel);
            return updatedCustomerModel;
        }

        public void DeleteCustomer(int id)
        {
            _customerRepository.Delete(x => x.Id == id);
        }

    }
}
