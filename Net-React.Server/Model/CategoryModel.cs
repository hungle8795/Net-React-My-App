namespace Net_React.Server.Model
{
    public class CategoryModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime CreateAt { get; set; }
        public DateTime UpdateAt { get; set; }
    }
}
