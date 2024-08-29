using System.ComponentModel.DataAnnotations;

namespace Net_React.Server.Models
{
    public class Tokens : BaseModel<long>
    {
        [Key]
        public int Id { get; set; }
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }

        public DateTime RefreshExpires { get; set; }
        public int AccountId { get; set; }
        public Auth Account { get; set; }
    }
}
