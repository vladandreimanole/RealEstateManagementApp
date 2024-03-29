﻿using System;
using System.Collections.Generic;

namespace DataManager.Models
{
    public partial class User
    {
        public User()
        {
            ChatLandlords = new HashSet<Chat>();
            ChatTenants = new HashSet<Chat>();
            Contracts = new HashSet<Contract>();
            Properties = new HashSet<Property>();
        }

        public int UserId { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Address { get; set; }
        public int RoleId { get; set; }
        public string? PhoneNumber { get; set; }
        public string? PassResetToken { get; set; }

        public virtual Role? Role { get; set; } = null!;
        public virtual ICollection<Chat>? ChatLandlords { get; set; }
        public virtual ICollection<Chat>? ChatTenants { get; set; }
        public virtual ICollection<Contract>? Contracts { get; set; }
        public virtual ICollection<Property>? Properties { get; set; }
    }
}
