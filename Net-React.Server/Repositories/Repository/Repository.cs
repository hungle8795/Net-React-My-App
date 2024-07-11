using Net_React.Server.Models;
using Net_React.Server.Repository.Interface;
using System.Data.Entity;

namespace Net_React.Server.Repositories.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        public IDbSet<T> _dbSet;
        private readonly EcommerceSampContext _DbContext;

    }
}
