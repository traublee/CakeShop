namespace CakeShop.Models.Models
{
    public class Cake
    {
        public Guid Id { get; set; }
        public string CakeName { get; set; }
        public decimal Price { get; set; }
        public string CakeDescription { get; set; }
    }
}
