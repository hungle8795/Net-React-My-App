using Net_React.Server.Models;

namespace Net_React.Server.Repositories.Interfaces
{
    public interface IAddressRepository : IRepository<Address>
    {
        IList<Address> GetAll();
        Address GetById(int id);
        Address GetByUserId(int userId);
        void Add(Address category);
        void Update(Address category);
        void Delete(int id);
    }
}
