using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using TCSBanking.Models;

namespace TCSBanking.ViewModels
{
    public class DepWitViewModel
    {
        public int AccountId { get; set; }

        public AccountStatus Account { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Must Deposit / Withdraw atleast $1.")]
        public int Ammount { get; set; }
    }
}
