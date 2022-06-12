using System;
using System.Collections.Generic;

namespace DataManager.Models
{
    public partial class Property
    {
        public int PropertyId { get; set; }
        public string? PropertyName { get; set; }
        public string? City { get; set; }
        public string? Address { get; set; }
        public long? Value { get; set; }
        public int? TenantId { get; set; }
        public int? LandlordId { get; set; }
        public string? Images { get; set; }

        public virtual Landlord? Landlord { get; set; }
        public virtual Contract PropertyNavigation { get; set; } = null!;
        public virtual Tenant? Tenant { get; set; }
    }
}
