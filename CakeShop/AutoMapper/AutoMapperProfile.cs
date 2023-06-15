using AutoMapper;
using CakeShop.Models.Requests;
using CakeShop.Models.Models;

namespace CakeShopMain.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<CakeRequest, Cake>();
            CreateMap<OrderRequest, Order>();
        }
    }
}
