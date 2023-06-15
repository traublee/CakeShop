using BookStore.Models.Requests;
using CakeShop.BL.Interfaces;
using CakeShop.DL.Interfaces;
using CakeShop.Models.Models;
using CakeShop.Models.Requests;

namespace CakeShop.BL.Service
{
    public class UserInfoService : IUserInfoService
    {
        private readonly IUserInfoRepository _userInfoRepository;
        public UserInfoService(IUserInfoRepository userInfoRepository)
        {
            _userInfoRepository = userInfoRepository;
        }

        public Task<UserInfo?> GetUserInfoAsync(string userName, string password)
        {
            return _userInfoRepository.GetUserInfoAsync(userName, password);
        }

        public async Task Add(AddUserInfoRequest user)
        {
            await _userInfoRepository.Add(new UserInfo()
            {
                Id = Guid.NewGuid(),
                Username = user.Email,
                Password = user.Password,
            });
        }
    }
}
