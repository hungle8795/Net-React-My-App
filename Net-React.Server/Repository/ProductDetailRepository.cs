using Net_React.Server.Model;
using Net_React.Server.Repository;

namespace Net_React.Server.Service
{
    public class ProductDetailRepository: IRepository
    {
        private List<ProductDetailModel> _products = new List<ProductDetailModel>
        {
            new ProductDetailModel {
                ProductName = "PS1 ",
                ProductDescription = "This is a PS gamepad"
            },
            new ProductDetailModel {
                ProductName = "Xbox 1",
                ProductDescription = "This is a xbox gamepad"
            },
            new ProductDetailModel
            {
                ProductName = "HDMI Cap 1",
                ProductDescription = "This is a cap"
            }
        };

        public List<ProductDetailModel> GetAll()
        {
            return _products;
        }

        public ProductDetailModel GetByName(string productname)
        {
            var data = _products.Where(n => n.ProductName == productname).FirstOrDefault();
            if (data != null) return data;
            else throw new Exception("Cannot find data by this productname");
        }
    }
}
