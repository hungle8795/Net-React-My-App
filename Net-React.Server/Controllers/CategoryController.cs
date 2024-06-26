using Net_React.Server.Repository;

namespace Net_React.Server.Controllers
{

    public class CategoryController
    {
        private readonly IRepository _repository;
        public CategoryController(IRepository repository)  
        {  
            this._repository = repository; 
        }


    }
}
