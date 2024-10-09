using AutoMapper;
using Net_React.Server.DTOs;
using Net_React.Server.Models;

namespace Net_React.Server.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Category, CategoryDTO>();
            CreateMap<CategoryDTO, Category>();
            CreateMap<Product, ProductDTO>();
            CreateMap<ProductDTO, Product>();
            CreateMap<Address, AddressDTO>();
            CreateMap<AddressDTO, Address>();
            CreateMap<User, UserDTO>();
            CreateMap<UserDTO, User>();
        }
    }
}
