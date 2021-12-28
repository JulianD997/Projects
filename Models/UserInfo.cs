using System;
using System.Collections.Generic;

namespace TCSBanking.Models
{
    public partial class UserInfo
    {
        public UserInfo()
        {
            AccountStatus = new HashSet<AccountStatus>();
            CustomerStatus = new HashSet<CustomerStatus>();
        }

        public int CustomerId { get; set; }
        public int Ssnid { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int Age { get; set; }

        public virtual ICollection<AccountStatus> AccountStatus { get; set; }
        public virtual ICollection<CustomerStatus> CustomerStatus { get; set; }
    }
}
