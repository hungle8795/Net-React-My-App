using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Net_React.Server.Models;

public partial class Category
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("name")]
    [StringLength(20)]
    public string Name { get; set; } = null!;

    [Column("description")]
    public string? Description { get; set; }

    [Column("image")]
    public string Image { get; set; } = null!;

    [Column("created_at", TypeName = "timestamp without time zone")]
    public DateTime CreatedAt { get; set; }

    [Column("updated_at", TypeName = "timestamp without time zone")]
    public DateTime UpdatedAt { get; set; }

    [InverseProperty("Category")]
    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
