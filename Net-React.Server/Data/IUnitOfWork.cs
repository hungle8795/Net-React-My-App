using Net_React.Server.Repositories.Interface;
using Net_React.Server.Repositories.Interfaces;

namespace Net_React.Server.Data
{
    public class IUnitOfWork : IDisposable
    {
        ICategoryRepository Categories { get; }
        IProductDetailRepository Product { get; }
        Task<int> CompleteAsync();
    }
}
