namespace CakeShop.Models.Requests
{
    public class CakeRequest
    {
        public string Name { get; set; }
        public string Flavor { get; set; }
        public decimal Price { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
