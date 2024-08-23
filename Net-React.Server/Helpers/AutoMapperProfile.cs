using AutoMapper;
using Net_React.Server.DTOs;
using Net_React.Server.DTOs.Product;
using Net_React.Server.Models;

namespace Net_React.Server.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            // Category
            CreateMap<Category, CategoryDTO>();
            CreateMap<CategoryDTO, Category>();

            // Product
            CreateMap<Product, GetProductDTO>();
            CreateMap<GetProductDTO, Product>();

            // Address
            CreateMap<Address, AddressDTO>();
            CreateMap<AddressDTO, Address>();
        }
    }
}
