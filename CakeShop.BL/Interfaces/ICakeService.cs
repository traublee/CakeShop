using CakeShop.Models.Models;

namespace CakeShop.BL.Interfaces
{
    public interface ICakeService
    {
        Task<IEnumerable<Cake>> GetAllCakes();
        Task<Cake> GetCakeById(Guid id);
        Task AddCake(Cake cake);
        Task UpdateCake(Cake cake);
        Task DeleteCake(Guid id);
    }
}