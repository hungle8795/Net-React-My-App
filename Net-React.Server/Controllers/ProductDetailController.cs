using Net_React.Server.Repositories.Interface;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

namespace Net_React.Server.Controllers
{
    [Route("api/productdetails")]
    public class ProductDetailController
    {
        //private readonly IRepository _repository;
        //public ProductDetailController(IRepository repository)
        //{
        //    this._repository = repository;
        //}

        //[HttpGet] 
        //public ActionResult<List<ProductDetail>> GetAll()
        //{
        //    return _repository.GetAllProductDetail();
        //}

        //[HttpGet("name")]
        //public async Task<ActionResult<ProductDetail>> GetByName(string productName)
        //{
        //    return await _repository.GetByProductName(productName);
        //}
    }


}
