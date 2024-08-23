using System.ComponentModel.DataAnnotations;

namespace Net_React.Server.Models
{
    public class Tokens : BaseModel
    {
        [Key]
        public int Id { get; set; }
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }

        public DateTime RefreshExpires { get; set; }
        public int AccountId { get; set; }
        public Accounts Account { get; set; }
    }
}
