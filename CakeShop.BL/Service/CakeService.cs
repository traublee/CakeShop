using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CakeShop.BL.Interfaces;
using CakeShop.DL.Interfaces;
using CakeShop.Models.Models;

namespace CakeShop.BL.Services
{
    public class CakeService : ICakeService
    {
        private readonly ICakeRepository _cakeRepository;

        public CakeService(ICakeRepository cakeRepository)
        {
            _cakeRepository = cakeRepository;
        }

        public Task<IEnumerable<Cake>> GetAllCakes()
        {
            return _cakeRepository.GetAllCakes();
        }

        public Task<Cake> GetCakeById(Guid id)
        {
            return _cakeRepository.GetCakeById(id);
        }

        public Task AddCake(Cake cake)
        {
            return _cakeRepository.AddCake(cake);
        }

        public Task UpdateCake(Cake cake)
        {
            return _cakeRepository.UpdateCake(cake);
        }

        public Task DeleteCake(Guid id)
        {
            return _cakeRepository.DeleteCake(id);
        }
    }
}