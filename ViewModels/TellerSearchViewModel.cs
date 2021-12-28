using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using TCSBanking.Models;

namespace TCSBanking.ViewModels
{
    public class TellerSearchViewModel
    {
        public List<AccountStatus> Account { get; set; }

        [Required(ErrorMessage = "Enter a 10 digit Account ID Number"), Range(999999999, int.MaxValue, ErrorMessage = "Account ID is a 10 digit number.")]
        public int AccountId { get; set; }

        [Required(ErrorMessage = "Enter a 10 digit Customer ID Number"), Range(99999999, int.MaxValue, ErrorMessage = "Customer ID is a 10 digit number.")]
        public int CustomerId { get; set; }

        public string AccountType { get; set; }

        public int Balance { get; set; }
    }
}
