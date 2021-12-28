using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TCSBanking.Models;

namespace TCSBanking.ViewModels
{
    public class AccountDeleteViewModel : AccountCreateViewModel
    {
        public int AccountId { get; set; }
        public string Status { get; set; }
        public string Message { get; set; }
        public DateTime LastUpdated { get; set; }
    }
}
