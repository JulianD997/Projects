using System;
using System.Collections.Generic;

namespace TCSBanking.Models
{
    public partial class AccountStatus
    {
        public int AccountId { get; set; }
        public string AccountType { get; set; }
        public string Status { get; set; }
        public string Message { get; set; }
        public DateTime LastUpdated { get; set; }
        public int Balance { get; set; }
        public int CustomerId { get; set; }

        public virtual UserInfo Customer { get; set; }
    }
}
