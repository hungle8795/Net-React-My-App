using System;
using System.Collections.Generic;

namespace Net_React.Server.Models;

public partial class Address
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public string Region { get; set; } = null!;

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
