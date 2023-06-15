using CakeShop.Models.Configurations;
using CakeShop.Models.Models;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;

namespace CakeShop.DL.Interfaces.MongoDb
{
    public class UserInfoRepository : IUserInfoRepository
    {
        private readonly IMongoCollection<UserInfo> _users;

        public UserInfoRepository(IOptionsMonitor<MongoDbConfiguration> mongoConfig)
        {
            var client = new MongoClient(mongoConfig.CurrentValue.ConnectionString);
            var database = client.GetDatabase(mongoConfig.CurrentValue.DatabaseName);
            var collectionSettings = new MongoCollectionSettings
            {
                GuidRepresentation = GuidRepresentation.Standard
            };
            _users = database.GetCollection<UserInfo>(nameof(UserInfo), collectionSettings);
        }

        public Task<UserInfo?> GetUserInfoAsync(string userName, string password)
        {
            var filterBuilder = Builders<UserInfo>.Filter;
            var filter = filterBuilder.Eq(entity => entity.Username, userName) & filterBuilder.Eq(entity => entity.Password, password);

            var item = _users.Find(filter).FirstOrDefault();
            return Task.FromResult(item);
        }

        public async Task Add(UserInfo user)
        {
            await _users.InsertOneAsync(user);
        }
    }
}
