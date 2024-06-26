using Net_React.Server.Model;

namespace Net_React.Server.Repository
{
    public interface IRepository
    {
        public List<ProductDetailModel> GetAll();
        public ProductDetailModel GetByName(string name);
        //public CategoryModel GetByName(string name);
        //public List<CategoryModel> GetAll();
    }
}
