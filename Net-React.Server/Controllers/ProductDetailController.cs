using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Net_React.Server.Model;
using Net_React.Server.Repository;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

namespace Net_React.Server.Controllers
{
    [Route("api/productdetails")]
    public class ProductDetailController
    {
        private readonly IRepository _repository;
        public ProductDetailController(IRepository repository)
        {
            this._repository = repository;
        }

        [HttpGet] 
        public List<ProductDetailModel> GetAllData()
        {
            var data = _repository.GetAll();
            return _repository.GetAll();
        }
    }


}
