using AutoMapper;
using Net_React.Server.DTOs.Auth;
using Net_React.Server.DTOs.Product;
using Net_React.Server.DTOs.User;
using Net_React.Server.Models;

namespace Net_React.Server
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            // Auth
            //CreateMap<Auth, RegisterDto>();
            //CreateMap<RegisterDto, Auth>();

            //CreateMap<UpdateUserDTO, User>();
            //CreateMap<AccountReqDTO, Auth>();
            CreateMap<string, AccountRespDTO>();

            // Products
            CreateMap<Product, AddProductDTO>();
            CreateMap<AddProductDTO, Product>();

            // Cart

        }
    }
}
