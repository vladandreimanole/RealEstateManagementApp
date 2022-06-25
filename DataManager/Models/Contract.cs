using System;
using System.Collections.Generic;

namespace DataManager.Models
{
    public partial class Contract
    {
        public Contract()
        {
            Bills = new HashSet<Bill>();
        }

        public int ContractId { get; set; }
        public int? PropertyId { get; set; }
        public int? TenantId { get; set; }
        public bool? Signed { get; set; }
        public string? ContractHtml { get; set; }

        public virtual Property? Property { get; set; }
        public virtual User? Tenant { get; set; }
        public virtual ICollection<Bill> Bills { get; set; }
    }
}
