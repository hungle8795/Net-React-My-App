using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Net_React.Server.Models;

public partial class Category : BaseModel
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string CategoryName { get; set; } = null!;

    public string? Description { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
