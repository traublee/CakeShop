using CakeShop.Models.Models;

namespace CakeShop.DL.Interfaces
{
    public interface IUserInfoRepository
    {
        public Task<UserInfo?> GetUserInfoAsync(string userName, string password);
        public Task Add(UserInfo user);
    }
}
