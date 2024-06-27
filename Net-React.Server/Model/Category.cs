using System.ComponentModel.DataAnnotations;

namespace Net_React.Server.Model
{
    public class Category
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
        [DataType(DataType.Date)]
        public DateTime CreateAt { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime UpdateAt { get; set; }
    }
}
