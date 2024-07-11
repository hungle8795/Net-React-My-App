using System;
using System.Collections.Generic;

namespace Net_React.Server.Models;

public partial class User
{
    public int Id { get; set; }

    public string? Lastname { get; set; }

    public string Firstname { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Address { get; set; } = null!;

    public virtual ICollection<Address> Addresses { get; set; } = new List<Address>();
}
