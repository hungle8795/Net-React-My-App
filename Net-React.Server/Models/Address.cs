using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Net_React.Server.Models;

public partial class Address
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("user_id")]
    public int UserId { get; set; }

    [Column("region")]
    [StringLength(50)]
    public string Region { get; set; } = null!;

    [Column("last_name")]
    [StringLength(50)]
    public string? LastName { get; set; }

    [Column("first_name")]
    [StringLength(50)]
    public string FirstName { get; set; } = null!;

    [Column("phone_number")]
    public int PhoneNumber { get; set; }

    [Column("zip_code")]
    [StringLength(20)]
    public string ZipCode { get; set; } = null!;

    [Column("province")]
    [StringLength(20)]
    public string Province { get; set; } = null!;

    [Column("city")]
    [StringLength(20)]
    public string City { get; set; } = null!;

    [Column("chrome_streetaddress")]
    [StringLength(20)]
    public string ChromeStreetaddress { get; set; } = null!;

    [Column("room_number")]
    public int RoomNumber { get; set; }

    [Column("created_at", TypeName = "timestamp without time zone")]
    public DateTime CreatedAt { get; set; }

    [Column("updated_at", TypeName = "timestamp without time zone")]
    public DateTime UpdatedAt { get; set; }

    [ForeignKey("UserId")]
    [InverseProperty("Addresses")]
    public virtual User User { get; set; } = null!;
}
