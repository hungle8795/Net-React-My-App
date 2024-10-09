namespace Net_React.Server.DTOs
{
    public class CategoryDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public string Image { get; set; }
    }
}