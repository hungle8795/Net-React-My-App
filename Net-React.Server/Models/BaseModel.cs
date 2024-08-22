namespace Net_React.Server.Models
{
    public class BaseModel
    {
        public int Id { get; set; }
        public DateTime CreatedDateTime { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedDateTime { get; set; } = DateTime.UtcNow;
    }
}
