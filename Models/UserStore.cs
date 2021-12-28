using System;
using System.Collections.Generic;

namespace TCSBanking.Models
{
    public partial class UserStore
    {
        public int UserId { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
