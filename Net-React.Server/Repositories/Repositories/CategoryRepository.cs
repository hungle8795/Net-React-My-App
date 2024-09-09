using Net_React.Server.Models;
using Net_React.Server.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace Net_React.Server.Repositories.Repository
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        public CategoryRepository(ECommerceSampContext context) : base(context)
        { 
        }
        public async Task<IEnumerable<Category>> GetAllByNameAsync(string name)
        {
            return await _context.Categories.Where(n => n.Name == name).ToListAsync();  
        }
    }
}
    