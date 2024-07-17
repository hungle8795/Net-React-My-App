using Net_React.Server.Models;
using Net_React.Server.Repositories.Interfaces;

namespace Net_React.Server.Services.Interfaces
{
    public interface IProductDetailService : IProductDetailRepository
    {
        ProductDetail GetByProductDetailName(string name);
    }
}
