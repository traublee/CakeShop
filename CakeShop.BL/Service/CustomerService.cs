using BookStore.BL.Interfaces;
using CakeShop.DL.Interfaces;
using CakeShop.Models;

namespace CakeShop.BL.Service
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<IEnumerable<Customer>> GetAllCustomers()
        {
            return await _customerRepository.GetAllCustomers();
        }

        public async Task<Customer> GetCustomerById(Guid id)
        {
            return await _customerRepository.GetCustomerById(id);
        }

        public async Task AddCustomer(Customer customer)
        {
            await _customerRepository.AddCustomer(customer);
        }

        public async Task UpdateCustomer(Customer customer)
        {
            await _customerRepository.UpdateCustomer(customer);
        }

        public async Task DeleteCustomer(Guid id)
        {
            await _customerRepository.DeleteCustomer(id);
        }
    }
}