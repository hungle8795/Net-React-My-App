using Net_React.Server.Models;
using Net_React.Server.Services.Interfaces;

namespace Net_React.Server.Services.Services
{
    public class ProductDetailService : IProductDetailService
    {
        private readonly IProductDetailService _productDetailService;
        public ProductDetailService(IProductDetailService productDetailService)
        {
            _productDetailService = productDetailService;
        }
        public IEnumerable<ProductDetail> GetAllProducts() => productDetailService.GetAll();
        public ProductDetail GetByProductId(int id) => productDetailService.GetById(id);
        public ProductDetail GetByProductName(string name) => productDetailService.GetByName(name);
        public void AddProduct(ProductDetail product) => productDetailService.Add(product);
        public void UpdateProduct(ProductDetail product) => productDetailService.Update(product);
        public void DeleteByProductId(int id) => productDetailService.Delete(id);
    }
}
