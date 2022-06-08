using System;
using System.Collections.Generic;

namespace DataManager.Models
{
    public partial class Contract
    {
        public int ContractId { get; set; }
        public int PropertyId { get; set; }

        public virtual Property Property { get; set; } = null!;
    }
}
