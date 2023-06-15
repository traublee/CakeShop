using BookStore.Models.Requests;
using CakeShop.Models.Models;
using CakeShop.Models.Requests;

namespace CakeShop.BL.Interfaces
{
    public interface IUserInfoService
    {
        public Task<UserInfo?> GetUserInfoAsync(string userName, string password);
        public Task Add(AddUserInfoRequest user);
    }
}
