using System;
using System.Collections.Generic;

namespace ExamenFinalJulioAPI.Models;

public partial class UserStatus
{
    public int UserStatusId { get; set; }

    public string Status { get; set; } = null!;

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
