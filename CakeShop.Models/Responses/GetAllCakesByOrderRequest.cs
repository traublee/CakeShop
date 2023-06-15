using CakeShop.Models.Models;

namespace CakeShop.Models.Responses
{
    public class GetAllCakesByOrderRequest
    {
        public Cake cake { get; set; }

        public IEnumerable<Order> Orders { get; set; }
    }
}
