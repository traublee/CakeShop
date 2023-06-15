using CakeShop.BL.Interfaces;
using CakeShop.DL.Interfaces;
using CakeShop.Models.Models;

namespace CakeShop.BL.Service
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;

        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public Task<IEnumerable<Order>> GetAllOrders()
        {
            return _orderRepository.GetAllOrders();
        }

        public Task<Order> GetOrderById(Guid id)
        {
            return _orderRepository.GetOrderById(id);
        }

        public Task PlaceOrder(Order order)
        {
            return _orderRepository.PlaceOrder(order);
        }

        public Task CancelOrder(Guid id)
        {
            return _orderRepository.CancelOrder(id);
        }
    }
}
