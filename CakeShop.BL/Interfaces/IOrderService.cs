using CakeShop.Models.Models;

namespace CakeShop.BL.Interfaces
{
    public interface IOrderService
    {
        Task<IEnumerable<Order>> GetAllOrders();
        Task<Order> GetOrderById(Guid id);
        Task PlaceOrder(Order order);
        Task CancelOrder(Guid id);
    }
}