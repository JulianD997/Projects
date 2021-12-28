using System;
using System.Collections.Generic;

namespace TCSBanking.Models
{
    public partial class CustomerStatus
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int Ssnid { get; set; }
        public string Status { get; set; }
        public string Message { get; set; }
        public DateTime LastUpdated { get; set; }

        public virtual UserInfo Customer { get; set; }
    }
}
