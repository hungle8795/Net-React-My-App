using Microsoft.AspNetCore.Mvc;
using Net_React.Server.Model;
using Net_React.Server.Repository;

namespace Net_React.Server.Service
{
    public class ProductDetailRepository : IRepository
    {
        private List<ProductDetail> _products;
        public ProductDetailRepository()
        {
            _products = new List<ProductDetail>()
            {
                new ProductDetail() {
                    ProductName = "PS 1",
                    ProductDescription = "This is a PS gamepad"
                },
                new ProductDetail() {
                    ProductName = "Xbox 1",
                    ProductDescription = "This is a xbox gamepad"
                },
                new ProductDetail()
                {
                    ProductName = "HDMI Cable 1",
                    ProductDescription = "This is a cap"
                }
            };
        }

        public ActionResult<List<ProductDetail>> GetAllProductDetail()
        {

            return _products;
        }

        public async Task<ActionResult<ProductDetail>> GetByProductName(string productname)
        {
            var data = _products.Where(n => n.ProductName == productname).FirstOrDefault();
            if (data != null) return data;
            else throw new Exception("Cannot find data by this productname");
        }
    }
}
