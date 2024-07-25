using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Net_React.Server.Models;

public partial class Address
{
    [Key] //DataAnnotations
    public int Id { get; set; }

    public int UserId { get; set; }

    public string Region { get; set; } = null!;
    //[Key] CodeFirstConvention
    public string? LastName { get; set; }

    public string FirstName { get; set; } = null!;

    public int PhoneNumber { get; set; }

    public string ZipCode { get; set; } = null!;

    public string Province { get; set; } = null!;

    public string City { get; set; } = null!;

    public string ChromeStreetaddress { get; set; } = null!;

    public int RoomNumber { get; set; }

    public virtual User User { get; set; } = null!;
}
