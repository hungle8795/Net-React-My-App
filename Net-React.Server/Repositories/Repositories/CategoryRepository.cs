using Net_React.Server.Models;
using Net_React.Server.Repositories.Interface;

namespace Net_React.Server.Repositories.Repository
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        public CategoryRepository(ECommerceSampContext context) : base(context)
        { 
        }

        public Category GetByName(string name) => _context.Categories.FirstOrDefault(n => n.Name == name);
    }
}
