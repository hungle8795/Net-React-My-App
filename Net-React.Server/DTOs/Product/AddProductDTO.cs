using Net_React.Server.Models;
using System.ComponentModel.DataAnnotations;

namespace Net_React.Server.DTOs.Product
{
    public class AddProductDTO
    {
        [Required]
        [MaxLength(50)]
        public string? Title { get; set; }
        //public int? ProductDetailId { get; set; }

        [Required]
        public decimal? Price { get; set; }

        [Required]
        public string? Description { get; set; }

        [Required]
        [MaxLength(50)]
        public string? Image { get; set; }
        //public int CategoryId { get; set; }
        //public string? CategoryName { get; set; }
    }
}
