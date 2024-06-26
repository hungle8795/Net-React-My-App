
using Microsoft.Extensions.Options;
using Net_React.Server.Model;
using Net_React.Server.Repository;

namespace Net_React.Server.Service
{
    public class CategoryRepository: IRepository
    {
        private List<CategoryModel> _categories = new List<CategoryModel>
        {
            new CategoryModel()
            {
                Name = "Gamepad",
                Description = "This is a gamepad"
            },
            new CategoryModel()
            { 
                Name = "Keyboard",
                Description = "This is a Keyboard"
            },
            new CategoryModel()
            {
                Name = "Screen",
                Description = "This is the screen"
            },
            new CategoryModel()
            {
                Name = "HDMI Cap",
                Description = "This is the HDMI cap"
            }
        };

        public List<CategoryModel> GetAll()
        {
            return _categories;
        }

        public CategoryModel GetByName(string categoryName)
        {
            var data = _categories.Where(n => n.Name == categoryName).FirstOrDefault();
            if (data != null) return data;
            else throw new Exception("Cannot find data by categoryName.");
        }
    }
}
