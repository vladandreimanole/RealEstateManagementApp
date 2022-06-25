using System;
using System.Collections.Generic;

namespace DataManager.Models
{
    public partial class Bill
    {
        public int BillId { get; set; }
        public int? ContractId { get; set; }
        public string? BillPdf { get; set; }

        public virtual Contract? Contract { get; set; }
    }
}
