using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Net_React.Server.Models;

public partial class Product : BaseModel<long>
{
    [Key]
    public int Id { get; set; }

    public string? ProductName { get; set; }
    public string? ProductImage { get; set; }
    public string? Color { get; set; }
    public string? Description { get; set; }
    public decimal Price { get; set; }
    public int Quantity { get; set; }
    //public int CategoryId { get; set; }
    //public virtual Category Category { get; set; } = null!;

}
