using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using TCSBanking.Models;

namespace TCSBanking.ViewModels
{
    public class AccountSearchViewModel
    {
        [Required(ErrorMessage = "Please enter a Customer ID or SSN.")]
        public int CustomerId { get; set; }
        public List<AccountStatus> Accounts { get; set; }
    }
}
