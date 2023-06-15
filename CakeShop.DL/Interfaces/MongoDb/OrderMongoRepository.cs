using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CakeShop.DL.Interfaces;
using CakeShop.Models.Models;
using CakeShop.Models.Requests;
using MongoDB.Driver;

namespace CakeShop.BL.Repositories
{
    public class OrderMongoRepository : IOrderRepository
    {
        private readonly IMongoCollection<Order> _orders;

        public OrderMongoRepository(IMongoDatabase database)
        {
            _orders = database.GetCollection<Order>("orders");
        }

        public async Task<IEnumerable<Order>> GetAllOrders()
        {
            return await _orders.Find(_ => true).ToListAsync();
        }

        public async Task<Order> GetOrderById(Guid id)
        {
            return await _orders.Find(o => o.Id == id).FirstOrDefaultAsync();
        }

        public async Task PlaceOrder(Order order)
        {
            await _orders.InsertOneAsync(order);
        }

        public async Task CancelOrder(Guid id)
        {
            await _orders.DeleteOneAsync(o => o.Id == id);
        }
    }
}