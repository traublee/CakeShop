using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CakeShop.Models.Models;

namespace CakeShop.DL.Interfaces
{
    public interface ICakeRepository
    {
        Task<IEnumerable<Cake>> GetAllCakes();
        Task<Cake> GetCakeById(Guid id);
        Task AddCake(Cake cake);
        Task UpdateCake(Cake cake);
        Task DeleteCake(Guid id);
    }
}