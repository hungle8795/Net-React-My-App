using System;
using System.Collections.Generic;

namespace Net_React.Server.Models;

public partial class Category : BaseModel
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
