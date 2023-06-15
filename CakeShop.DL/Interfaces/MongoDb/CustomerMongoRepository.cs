using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CakeShop.DL.Interfaces;
using CakeShop.Models;
using MongoDB.Driver;

namespace CakeShop.DL.Repositories
{
    public class CustomerMongoRepository : ICustomerRepository
    {
        private readonly IMongoCollection<Customer> _customers;

        public CustomerMongoRepository(IMongoDatabase database)
        {
            _customers = database.GetCollection<Customer>("customers");
        }

        public async Task<IEnumerable<Customer>> GetAllCustomers()
        {
            return await _customers.Find(_ => true).ToListAsync();
        }

        public async Task<Customer> GetCustomerById(Guid id)
        {
            return await _customers.Find(customer => customer.Id == id).FirstOrDefaultAsync();
        }

        public async Task AddCustomer(Customer customer)
        {
            await _customers.InsertOneAsync(customer);
        }

        public async Task UpdateCustomer(Customer customer)
        {
            await _customers.ReplaceOneAsync(c => c.Id == customer.Id, customer);
        }

        public async Task DeleteCustomer(Guid id)
        {
            await _customers.DeleteOneAsync(customer => customer.Id == id);
        }
    }
}