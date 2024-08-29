using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace Net_React.Server.Models;

public partial class User : BaseModel<long>
{
    public int Id { get; set; }
    public string? Lastname { get; set; } = string.Empty;

    public string Firstname { get; set; } = string.Empty;

    public string Email { get; set; } = null!;

    public string Address { get; set; } = null!;
    public virtual ICollection<Address>? Addresses { get; set; }

    //int GenderId { get; set; }
    //public Gender Gender { get; set; }

    public string Password { get; set; } = string.Empty;
    //public Accounts Account { get; set; }
}
