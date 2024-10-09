using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Net_React.Server.Models;

public partial class Product
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("name")]
    [StringLength(255)]
    public string Name { get; set; } = null!;

    [Column("price")]
    [Precision(10, 2)]
    public decimal Price { get; set; }

    [Column("quantity")]
    public int Quantity { get; set; }

    [Column("category_id")]
    public int CategoryId { get; set; }

    [Column("created_at", TypeName = "timestamp without time zone")]
    public DateTime? CreatedAt { get; set; }

    [Column("updated_at", TypeName = "timestamp without time zone")]
    public DateTime? UpdatedAt { get; set; }

    [Column("image")]
    public string Image { get; set; } = null!;

    [Column("description")]
    public string? Description { get; set; }

    [ForeignKey("CategoryId")]
    [InverseProperty("Products")]
    public virtual Category Category { get; set; } = null!;
}
