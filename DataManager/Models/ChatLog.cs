using System;
using System.Collections.Generic;

namespace DataManager.Models
{
    public partial class ChatLog
    {
        public int Id { get; set; }
        public int? ChatId { get; set; }
        public string? ChatMessage { get; set; }
        public DateTime SentTime { get; set; }
        public int? SentByUserId { get; set; }

        public virtual Chat? Chat { get; set; }
    }
}
