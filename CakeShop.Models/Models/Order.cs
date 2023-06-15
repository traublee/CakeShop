namespace CakeShop.Models.Models
{
    public class Order
    {
        public Guid Id { get; set; }
        public DateTime OrderDate { get; set; }
        public Customer Customer { get; set; }
    }
}
