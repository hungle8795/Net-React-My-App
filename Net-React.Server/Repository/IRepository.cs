using Microsoft.AspNetCore.Mvc;
using Net_React.Server.Model;

namespace Net_React.Server.Repository
{
    public interface IRepository
    {
        ActionResult<List<ProductDetail>> GetAllProductDetail();
        Task<ActionResult<ProductDetail>> GetByProductName(string productName);
        //List<CategoryModel> GetAllCategory();
        //Task<CategoryModel> GetByCategoryName(string categoryName);
    }
}
