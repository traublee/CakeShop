using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CakeShop.DL.Interfaces;
using CakeShop.Models.Models;
using CakeShop.Models.Requests;
using MongoDB.Driver;

namespace CakeShop.BL.Repositories
{
    public class CakeMongoRepository : ICakeRepository
    {
        private readonly IMongoCollection<Cake> _cakes;

        public CakeMongoRepository(IMongoDatabase database)
        {
            _cakes = database.GetCollection<Cake>("cakes");
        }

        public async Task<IEnumerable<Cake>> GetAllCakes()
        {
            return await _cakes.Find(_ => true).ToListAsync();
        }

        public async Task<Cake> GetCakeById(Guid id)
        {
            return await _cakes.Find(c => c.Id == id).FirstOrDefaultAsync();
        }

        public async Task AddCake(Cake cake)
        {
            await _cakes.InsertOneAsync(cake);
        }

        public async Task UpdateCake(Cake cake)
        {
            await _cakes.ReplaceOneAsync(c => c.Id == cake.Id, cake);
        }

        public async Task DeleteCake(Guid id)
        {
            await _cakes.DeleteOneAsync(c => c.Id == id);
        }
    }
}