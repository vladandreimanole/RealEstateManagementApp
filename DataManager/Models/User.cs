using System;
using System.Collections.Generic;

namespace DataManager.Models
{
    public partial class User
    {
        public int UserId { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }

        public virtual Landlord? Landlord { get; set; }
        public virtual Tenant Tenant { get; set; } = null!;
    }
}
