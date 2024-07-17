using Net_React.Server.Repositories.Interface;

namespace Net_React.Server.Repositories.Interfaces
{
    public class IUnitOfWork : IDisposable
    {
        ICategoryRepository Categories {  get; }
        IProductDetailRepository ProductDetails { get; }
        Task<int> CompleteAsync();
    }
}
