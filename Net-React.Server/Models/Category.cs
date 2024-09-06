﻿using System;
using System.Collections.Generic;

namespace Net_React.Server.Models;

public partial class Category
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public string Image { get; set; } = null!;

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
