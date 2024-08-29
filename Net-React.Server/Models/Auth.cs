using System.ComponentModel.DataAnnotations;

namespace Net_React.Server.Models
{
    public class Auth : BaseModel<long>
    {
        [Key]
        public int Id { get; set; }
        public string Role { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public ICollection<Tokens> Tokens { get; set; }
    }
}
