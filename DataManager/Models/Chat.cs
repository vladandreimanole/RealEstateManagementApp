using System;
using System.Collections.Generic;

namespace DataManager.Models
{
    public partial class Chat
    {
        public Chat()
        {
            ChatLogs = new HashSet<ChatLog>();
        }

        public int ChatId { get; set; }
        public int? TenantId { get; set; }
        public int? LandlordId { get; set; }

        public virtual User? Landlord { get; set; }
        public virtual User? Tenant { get; set; }
        public virtual ICollection<ChatLog>? ChatLogs { get; set; }
    }
}
