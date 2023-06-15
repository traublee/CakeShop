using CakeShop.Models.Models;

namespace CakeShop.DL.Interfaces
{
    public interface IOrderRepository
    {
        Task<IEnumerable<Order>> GetAllOrders();
        Task<Order> GetOrderById(Guid id);
        Task PlaceOrder(Order order);
        Task CancelOrder(Guid id);
    }
}
