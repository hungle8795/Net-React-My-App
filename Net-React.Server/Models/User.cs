using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Net_React.Server.Models;

public partial class User
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("lastname")]
    [StringLength(50)]
    public string? Lastname { get; set; }

    [Column("firstname")]
    [StringLength(50)]
    public string Firstname { get; set; } = null!;

    [Column("email")]
    [StringLength(255)]
    public string Email { get; set; } = null!;

    [Column("address")]
    [StringLength(255)]
    public string Address { get; set; } = null!;

    [Column("user_name")]
    public string UserName { get; set; } = null!;

    [Column("password_hash")]
    public string PasswordHash { get; set; } = null!;

    [Column("role")]
    public string Role { get; set; } = null!;

    [Column("created_at", TypeName = "timestamp without time zone")]
    public DateTime CreatedAt { get; set; }

    [Column("updated_at", TypeName = "timestamp without time zone")]
    public DateTime UpdatedAt { get; set; }

    [InverseProperty("User")]
    public virtual ICollection<Address> Addresses { get; set; } = new List<Address>();
}
