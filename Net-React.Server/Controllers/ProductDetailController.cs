using Microsoft.AspNetCore.Mvc;
using Net_React.Server.Models;
using Net_React.Server.Repositories.Interface;
using Net_React.Server.Services.Interfaces;
using Net_React.Server.Services.Services;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

namespace Net_React.Server.Controllers
{

    [Route("api/productdetails")]
    public class ProductDetailController
    {
        private readonly IProductDetailService _productDetailService;
        public ProductDetailController(IProductDetailService productDetailService)
        {
            _productDetailService = productDetailService;
        }

        [HttpGet]
        public async Task<IEnumerable<ProductDetail>> GetAllProductDetail()
        {
            return _productDetailService.GetAll();
        }

        [HttpGet("name")]
        public async Task<ProductDetail> GetByName(string productName)
        {
            return _productDetailService.GetByProductDetailName(productName);
        }
        public async void AddCategory(ProductDetail productDetail)
        {
            _productDetailService.Add(productDetail);
        }
        public async void UpdateCategory(ProductDetail productDetai)
        {
            _productDetailService.Update(productDetai);
        }
        public async void DeleteById(int id)
        {
            _productDetailService.Delete(id);
        }
    }


}
