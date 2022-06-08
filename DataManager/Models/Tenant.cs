using System;
using System.Collections.Generic;

namespace DataManager.Models
{
    public partial class Tenant
    {
        public Tenant()
        {
            Properties = new HashSet<Property>();
        }

        public int TenantId { get; set; }
        public int UserId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Address { get; set; }
        public string? PhoneNumber { get; set; }

        public virtual User User { get; set; } = null!;
        public virtual ICollection<Property> Properties { get; set; }
    }
}
